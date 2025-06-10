namespace SandO.Extensions;

public static class DateTimeExtensions
{
    // is after now
    public static bool IsAfterNow(this DateTime dateTime)
    {
        return dateTime > DateTime.Now;
    }

    // is before now
    public static bool IsBeforeNow(this DateTime dateTime)
    {
        return dateTime < DateTime.Now;
    }
}