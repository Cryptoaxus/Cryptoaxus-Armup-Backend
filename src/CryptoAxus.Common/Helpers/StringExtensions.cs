namespace CryptoAxus.Common.Helpers;

public static class StringExtensions
{
    public static bool NotNullAndEquals(this string? value, string valueToMatch)
    {
        if (value is not null && value.Equals(valueToMatch))
            return true;
        return false;
    }

    public static bool NotNullAndEquals(this StringSegment? value, string valueToMatch)
    {
        if (value is not null && value.Value.Equals(valueToMatch))
            return true;
        return false;
    }

    public static ObjectId ToObjectId(this string? value)
    {
        return new ObjectId(value);
    }
}