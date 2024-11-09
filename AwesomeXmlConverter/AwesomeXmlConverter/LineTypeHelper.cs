namespace AwesomeXmlConverter;

public static class LineTypeHelper
{
    public enum LineType
    {
        FullName = 'P',
        Phone = 'T',
        Address = 'A',
        DateOfBirth = 'F',
    }
    
    public static bool IsValidLineType(string input)
    {
        return !string.IsNullOrEmpty(input) && input.Length > 0 && Enum.IsDefined(typeof(LineType), (int)input[0]);
    }

    public static LineType? GetLineType(string input)
    {
        if (IsValidLineType(input))
        {
            return (LineType)input[0];
        }
        return null;
    }
}