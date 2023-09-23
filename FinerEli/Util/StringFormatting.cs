namespace FinerEli.Util;

public static class StringFormatting
{
    public static string ToSentenceCase(string input)
    {
        var lower = input.ToLower();
        return char.ToUpper(lower[0]) + lower[1..];
    }
}