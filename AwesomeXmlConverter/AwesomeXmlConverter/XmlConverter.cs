namespace AwesomeXmlConverter;

public class XmlConverter : IXmlConverter
{
    private int _minValuesPerLine = 3;
    public enum LineType
    {
        FullName = 'P',
        Phone = 'T',
        Address = 'A',
        DateOfBirth = 'F',
        Unknown
    }
    
    public LineType GetLineType(string input)
    {
        return (LineType)input[0];
    }
    
    public bool ValidateLine(string input)
    {
        // check for correct number of values
        List<string> split = input.Split('|').ToList();
        if (split.Count < _minValuesPerLine)
        {
            return false;
        }

        return true;
    }
}