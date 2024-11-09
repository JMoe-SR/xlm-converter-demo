namespace AwesomeXmlConverter;

public class XmlConverter : IXmlConverter
{
    private void ParseLine(string input)
    {
        LineTypeHelper.LineType? lineType = LineTypeHelper.GetLineType(input);
        if (lineType == null)
        {
            return;
        }

        switch (lineType)
        {
            case LineTypeHelper.LineType.FullName:
                ConvertFullName(input);
                break;
            case LineTypeHelper.LineType.Phone:
                ConvertPhone(input);
                break;
            case LineTypeHelper.LineType.Address:
                ConvertAddress(input);
                break;
            case LineTypeHelper.LineType.DateOfBirth:
                ConvertDateOfBirth(input);
                break;
            case null:
                throw new NotImplementedException();
        }
    }

    public string ConvertDateOfBirth(string input)
    {
        List<string> split = input.Split('|').ToList();
        string name = $"<name>{split[1]}</name>";
        string year = $"<year>{split[2]}</year>";
        return $"<dateofbirth>\n{name}\n{year}\n</dateofbirth>";
    }

    public string ConvertAddress(string input)
    {
        List<string> split = input.Split('|').ToList();
        string street = $"<street>{split[1]}</street>";
        string city = $"<city>{split[2]}</city>";
        string zip = $"<zip>{split[3]}</zip>";
        return $"<address>\n{street}\n{city}\n{zip}\n</address>";
    }

    public string ConvertPhone(string input)
    {
        List<string> split = input.Split('|').ToList();
        string mobile = $"<mobile>{split[1]}</mobile>";
        string landline = $"<landline>{split[2]}</landline>";
        return $"<phone>\n{mobile}\n{landline}\n</phone>";
    }

    public string ConvertFullName(string input)
    {
        List<string> split = input.Split('|').ToList();

        string firstname = $"<firstname>{split[1]}</firstname>";
        string lastname = $"<lastname>{split[2]}</lastname>";
        return $"{firstname}\n{lastname}";
    }
}