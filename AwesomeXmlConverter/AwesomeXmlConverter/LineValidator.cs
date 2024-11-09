using static AwesomeXmlConverter.LineTypeHelper;

namespace AwesomeXmlConverter;

public class LineValidator
{
    private static int _minValuesPerLine = 2;
    private static int _maxValuesPerLine = 3;
    
     public static bool ValidateLine(string input)
    {
        // check for correct number of values
        List<string> split = input.Split('|').ToList();
        if (split.Count < _minValuesPerLine || split.Count > _maxValuesPerLine)
        {
            return false;
        }

        // check line type
        if (!IsValidLineType(input)) return false;

        return true;
    }
}