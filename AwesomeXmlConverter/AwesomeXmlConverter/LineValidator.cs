using static AwesomeXmlConverter.LineTypeHelper;

namespace AwesomeXmlConverter;

public class LineValidator
{
    private const int MinValuesPerLine = 2;
    private const int MaxValuesPerLine = 3;

    public bool ValidateLine(string input)
    {
        if (!HasCorrectAmountOfValues(input)) return false;

        if (!IsValidLineType(input)) return false;

        return true;
    }
    
    public bool HasCorrectAmountOfValues(string input)
    {
        List<string> split = input.Split('|').ToList();
        return split.Count >= MinValuesPerLine && split.Count <= MaxValuesPerLine;
    }
}