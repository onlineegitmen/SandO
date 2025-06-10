using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SandO.Bll.Managers;
using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using Module = SandO.Entities.Enums.Module;

namespace SandO.Bll.Helpers;

public static class NewtonJsonHelper
{
    private static string Serialize<T>(T obj)
    {
        string serializeObject;
        try
        {
            serializeObject = JsonConvert.SerializeObject(obj);
        }
        catch (Exception e)
        {
#if DEBUG
            throw new Exception("Json serileştirme hatası: " + e.Message);
#endif
        }
        return serializeObject;
    }

    public static void SaveLog<T>(string recordGuid, ActionType actionType, T? oldValues, T? newValues) where T : class
    {
        RecordLog log = new RecordLog
        {
            ActionType = actionType,
            RecordGuid = recordGuid,
            UserId = GlobalVariables.LoggedInUserId
        };

        log.CreatedAt = SystemSettingsManager.GetServerDateTime();

        string? OldJson = oldValues != null
            ? Serialize(oldValues)
            : null;

        string? NewJson = newValues != null
            ? Serialize(newValues)
            : null;

        List<LogValue> logValues = GetDifferences(OldJson, NewJson);
        log.DifferenceJson = Serialize(logValues);

        SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        context.RecordLogs.Add(log);
        context.SaveChangesSafe();
    }

    public static List<LogValue> GetDifferences(string? oldJson, string? newJson)
    {
        var differences = new List<LogValue>();

        if (newJson == null)
        {
            return differences;
        }

        var oldObj = JsonConvert.DeserializeObject<JObject>(oldJson ?? String.Empty);
        var newObj = JsonConvert.DeserializeObject<JObject>(newJson);


        if (newObj == null)
            return differences;

        var allKeys = new HashSet<string>(newObj.Properties().Select(p => p.Name)
            .Concat(newObj.Properties().Select(p => p.Name)));

        foreach (var key in allKeys)
        {
            var oldVal = oldJson == null ? String.Empty : oldObj[key]?.ToString();
            var newVal = newObj[key]?.ToString();

            if (oldVal != newVal)
            {
                LogValue logValue = new LogValue
                {
                    Propertname = key,
                    PropertyDesc = key,
                    OldValue = oldVal ?? String.Empty,
                    NewValue = newVal ?? String.Empty
                };

                #region Enum değerleri

                if (logValue.Propertname == "RecordState")
                {
                    if (Int32.TryParse(logValue.OldValue, out int i))
                    {
                        RecordState oldState = (RecordState)i;
                        logValue.OldValue = oldState.ToDescription();
                    }

                    if (Int32.TryParse(logValue.NewValue, out i))
                    {
                        RecordState newState = (RecordState)i;
                        logValue.NewValue = newState.ToDescription();
                    }
                }
                else if (logValue.Propertname == "GroupModule")
                {
                    if (Int32.TryParse(logValue.OldValue, out int i))
                    {
                        Module oldState = (Module)i;
                        logValue.OldValue = oldState.ToFriendlyString();
                    }

                    if (Int32.TryParse(logValue.NewValue, out i))
                    {
                        Module newState = (Module)i;
                        logValue.NewValue = newState.ToFriendlyString();
                    }
                }

                #endregion Enum değerleri

                differences.Add(logValue);
            }
        }

        return differences;
    }



    public static QueryResult<List<LogView>> GetRecordLogs(string recordGuid)
    {
        //TODO: Yetki kontrolü yapılacak

        using SandOContext context = new(GlobalVariables.DbContextOptions);
        List<LogView> logViews = context.RecordLogs
            .Where(x => x.RecordGuid == recordGuid)
            .Join(context.Users, // Join with Users table
                  log => log.UserId,
                  user => user.Id,
                  (log, user) => new LogView
                  {
                      Id = log.Id,
                      ActionType = log.ActionType,
                      DateTime = log.CreatedAt,
                      UserFullname = user.Fullname, // Assuming FullName exists in Users table
                      Username = user.Username // Assuming Username exists in Users table
                  })
            .OrderBy(l => l.Id)
            .ToList();

        if (logViews.Count == 0)
        {
            return new QueryResult<List<LogView>>(false, "Kayıt bulunamadı.", null);
        }

        return new QueryResult<List<LogView>>(true, "Kayıt bulundu.", logViews);
    }

    public static QueryResult<List<LogValue>> GetLogJsons(int logId, Type tableType)
    {
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        RecordLog? log = context.RecordLogs
            .FirstOrDefault(x => x.Id == logId);

        if (log == null)
        {
            return new QueryResult<List<LogValue>>(false, "Kayıt bulunamadı.", null);
        }

        List<LogValue>? logValues = JsonConvert.DeserializeObject<List<LogValue>>(log.DifferenceJson);
        if (logValues == null)
        {
            return new QueryResult<List<LogValue>>(false, "Kayıt bulunamadı.", null);
        }

        Dictionary<string, string> columnDescriptions = GetColumnDescriptions(tableType);

        foreach (var logValue in logValues)
        {
            if (columnDescriptions.TryGetValue(logValue.Propertname, out var description))
            {
                if (String.IsNullOrWhiteSpace(description))
                {
                    logValue.PropertyDesc = logValue.Propertname;
                }
                else
                {
                    logValue.PropertyDesc = description;
                }
            }
        }

        return new QueryResult<List<LogValue>>(true, "Kayıt bulundu.", logValues);
    }

    private static Dictionary<string, string> GetColumnDescriptions(Type tableType)
    {
        TableAttribute? customAttribute = tableType.GetCustomAttribute<TableAttribute>();
        string? tableName = customAttribute?.Name ?? null;
        if (tableName == null)
        {
            return new Dictionary<string, string>();
        }

        using SandOContext context = new(GlobalVariables.DbContextOptions);
        Dictionary<string, string> dictionary = context.ColumnDescriptions.Where(t => t.TableName == tableName).ToDictionary(t => t.ColumnName, t => t.Description);
        return dictionary;
    }

    public static bool RestoreColumnDescription()
    {
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        List<ColumnDescription> columnDescriptions = context.Set<ColumnDescription>()
            .FromSqlRaw(
                "select TABLE_NAME TableName , COLUMN_NAME ColumnName, SPACE(1) Description from INFORMATION_SCHEMA.COLUMNS order by TableName")
            .ToList();

        foreach (ColumnDescription columnDescription in columnDescriptions)
        {
            if (!context.ColumnDescriptions.Any(c => c.TableName == columnDescription.TableName && c.ColumnName == columnDescription.ColumnName))
            {
                context.ColumnDescriptions.Add(columnDescription);
            }
        }

        return context.SaveChangesSafe();
    }
}