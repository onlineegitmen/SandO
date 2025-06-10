namespace SandO.Extensions;

public static class GuidExtensions
{
    // is empty or null
    public static bool IsEmpty(this Guid guid)
    {
        return guid == Guid.Empty;
    }

    /// <summary>
    /// Generates a new Guid and returns it as a string without dashes.
    /// </summary>
    /// <returns></returns>
    public static string GetNewGuid()
    {
        return Guid.NewGuid().ToString("N");
    }
}