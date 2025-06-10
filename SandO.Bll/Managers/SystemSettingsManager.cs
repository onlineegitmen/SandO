using Microsoft.EntityFrameworkCore;
using SandO.Bll.BllClasses;
using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Entities.Enums;

namespace SandO.Bll.Managers;

public class SystemSettingsManager
{
    public DatabaseConnectionInfo DatabaseConnectionInfo { get; set; }
    public int UserId { get; set; }
    public SystemSettingsManager()
    {
        DatabaseConnectionInfo = GlobalVariables.DatabaseConnectionInfo;
        UserId = GlobalVariables.LoggedInUserId;
    }

    public SystemSettingsManager(DatabaseConnectionInfo databaseConnectionInfo, int userId)
    {
        DatabaseConnectionInfo = databaseConnectionInfo;
        UserId = userId;
    }

    public QueryResult<T> GetSystemSettingValue<T>(SystemSettingType settingType)
    {
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        SystemSetting? systemSetting = context.SystemSettings.FirstOrDefault(s => s.SystemSettingType == settingType);
        if (systemSetting == null)
        {
            return new QueryResult<T>(false, $"Sistem ayarı bulunamadı. Ayar adı: {settingType.ToFriendlyString()}");
        }

        try
        {
            T changeType = (T)Convert.ChangeType(systemSetting.Value, typeof(T));
            return new QueryResult<T>(true, changeType);
        }
        catch (Exception e)
        {
            return new QueryResult<T>(false, $"Sistem ayarı okunurken hata oluştu. Ayar adı: {settingType.ToFriendlyString()}. Hata: {e.Message}");
        }
    }

    public async Task<ProgressResult> SetSystemSettingValue<T>(SystemSettingType settingType, T value)
    {
        if (value == null)
        {
            return new ProgressResult(false, "Değer boş olamaz.");
        }

        await using SandOContext context = new(GlobalVariables.DbContextOptions);
        SystemSetting? systemSetting = context.SystemSettings.FirstOrDefault(s => s.SystemSettingType == settingType);
        if (systemSetting == null)
        {
            return new ProgressResult(false, $"Sistem ayarı bulunamadı. Ayar adı: {settingType.ToFriendlyString()}");
        }

        if (!systemSetting.Editable)
        {
            return new ProgressResult(false, $"Bu sistem ayarı uygulama tarafından düzenlenemez. Ayar adı: {settingType.ToFriendlyString()}");
        }

        systemSetting.Value = value.ToString();
        bool saveChanges = context.SaveChangesSafe();
        return saveChanges ? new ProgressResult(true, $"Sistem ayarı başarıyla güncellendi. Ayar adı: {settingType.ToFriendlyString()}") : new ProgressResult(false, $"Sistem ayarı güncellenirken hata oluştu. Ayar adı: {settingType.ToFriendlyString()}");
    }

    public async Task<ProgressResult> RestoreSystemSettings(bool overrideIfExists)
    {
        await using SandOContext context = new(GlobalVariables.DbContextOptions);

        foreach (SystemSettingType systemSettingType in Enum.GetValues<SystemSettingType>())
        {
            SystemSetting systemSetting = new()
            {
                SystemSettingType = systemSettingType,
                Value = systemSettingType.DefaultValue()
            };

            SystemSetting? systemSettingOnDb = context.SystemSettings.FirstOrDefault(s => s.SystemSettingType == systemSettingType);
            if (systemSettingOnDb != null)
            {
                if (!overrideIfExists)
                {
                    continue;
                }
                systemSettingOnDb.Value = systemSetting.Value;
            }
            else
            {
                context.SystemSettings.Add(systemSetting);
            }
        }

        bool saveChanges = context.SaveChangesSafe();
        return saveChanges ? new ProgressResult(true, "Sistem ayarları başarıyla geri yüklendi.") : new ProgressResult(false, "Sistem ayarları geri yüklenirken hata oluştu.");
    }

    public ProgressResult TimeDifferenceIsTolerable()
    {
        QueryResult<int> queryResult = GetSystemSettingValue<int>(SystemSettingType.TolerableTimeInSecond);
        if (!queryResult.Result)
        {
            return new ProgressResult(false, queryResult.Message);
        }

        // get current time from sql server
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        DateTime serverDateTime = context.Database.SqlQueryRaw<DateTime>("SELECT GETDATE()").FirstOrDefault();

        if (Math.Abs((serverDateTime - DateTime.Now).TotalSeconds) > queryResult.ResultObject)
        {
            return new ProgressResult(false, "Sistem saati ile sunucu saati arasındaki fark tolerans sınırlarının dışındadır.");
        }

        return new ProgressResult(true, "Sistem saati ile sunucu saati arasındaki fark tolerans sınırları içindedir.");
    }

    public static DateTime GetServerDateTime()
    {
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        using var connection = context.Database.GetDbConnection();
        connection.OpenAsync();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT GETDATE()";

        object result = command.ExecuteScalar();
        DateTime dateTime = (DateTime)result;
        return dateTime;
    }
}