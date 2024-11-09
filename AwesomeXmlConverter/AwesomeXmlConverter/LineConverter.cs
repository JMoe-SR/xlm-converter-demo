namespace AwesomeXmlConverter;

public class LineConverter
{
    public string ConvertFullName(string line)
    {
        List<string> split = line.Split('|').ToList();

        string firstname = $"<firstname>{split[1]}</firstname>";
        string lastname = $"<lastname>{split[2]}</lastname>";
        return $"{firstname}\n{lastname}";
    }
    
    public string ConvertPhone(string line)
    {
        List<string> split = line.Split('|').ToList();
        string mobile = $"\t<mobile>{split[1]}</mobile>";
        string landline = $"\t<landline>{split[2]}</landline>";
        return $"<phone>\n{mobile}\n{landline}\n</phone>";
    }

    public string ConvertAddress(string line)
    {
        List<string> split = line.Split('|').ToList();
        string street = $"<street>{split[1]}</street>";
        string city = $"<city>{split[2]}</city>";
        string zip = $"<zip>{split[3]}</zip>";
        return $"<address>\n\t{street}\n\t{city}\n\t{zip}\n</address>";
    }
    
    public string ConvertFamily(string line)
    {
        List<string> split = line.Split('|').ToList();
        string name = $"\t<name>{split[1]}</name>";
        string year = $"\t<born>{split[2]}</born>";
        return $"<family>\n{name}\n{year}\n";
    }
}