namespace SandO.Extensions;

public static class StringExtensions
{
    // Not null or empty or whitespace
    public static bool IsNotNullOrEmptyOrWhiteSpace(this string value)
    {
        return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
    }

    // is null or empty or whitespace
    public static bool IsNullOrEmptyOrWhiteSpace(this string value)
    {
        return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }

    // max length
    public static bool IsMaxLength(this string value, int maxLength)
    {
        return value.Length <= maxLength;
    }

    // more than max length
    public static bool IsMoreThanMaxLength(this string value, int maxLength)
    {
        if (value.IsNullOrEmptyOrWhiteSpace())
        {
            return false;
        }

        return value.Length > maxLength;
    }

    /// <summary>
    /// Checks if the string is not null or empty or whitespace and has a length greater than the specified length.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static bool IsLength(this string value, int length)
    {
        return value.Length == length;
    }

    /// <summary>
    /// Checks if the string is a valid email address or empty.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsValidEmailOrEmpty(this string value)
    {
        if (value.IsNullOrEmptyOrWhiteSpace())
        {
            return true;
        }
        try
        {
            var mail = new System.Net.Mail.MailAddress(value);
            return mail.Address == value;
        }
        catch
        {
            return false;
        }
    }
}