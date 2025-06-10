namespace SandO.Entities.AppClasses;

public class QueryResult<T>
{
    public QueryResult(bool result, string message)
    {
        Result = result;
        Message = message;
    }

    public QueryResult(bool result, string message, T resultObject)
    {
        Result = result;
        Message = message;
        ResultObject = resultObject;
    }

    public QueryResult(bool result, T resultObject)
    {
        Result = result;
        ResultObject = resultObject;
    }

    public bool Result { get; set; }
    public T? ResultObject { get; set; }
    public string Message { get; set; }
}