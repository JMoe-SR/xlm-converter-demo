using static AwesomeXmlConverter.LineTypeHelper;

namespace AwesomeXmlConverter;

public abstract class LineValidator
{
    private class LineMinMaxValues
    {
        public int Min { get; init; }
        public int Max { get; init; }
    }
    
    private static readonly Dictionary<LineType, LineMinMaxValues> LineTypeValues = new()
    {
        {LineType.FullName, new LineMinMaxValues {Min = 3, Max = 3}},
        {LineType.Address, new LineMinMaxValues {Min = 3, Max = 4}},
        {LineType.Phone, new LineMinMaxValues {Min = 2, Max = 3}},
        {LineType.Family, new LineMinMaxValues {Min = 3, Max = 3}},
    };

    public static bool ValidateLine(string input)
    {
        // Check LineType
        List<string> split = input.Split('|').ToList();
        LineType? lineType = GetLineType(split[0]);
        if(lineType is not { } nonNullLineType) return false;
        
        // Check number of values
        if(!LineTypeValues.TryGetValue(nonNullLineType, out var values)) return false;
        return split.Count >= values.Min && split.Count <= values.Max;
    }
}