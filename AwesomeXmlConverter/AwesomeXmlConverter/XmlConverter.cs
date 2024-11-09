using System.Text;

namespace AwesomeXmlConverter;

public class XmlConverter
{
    private readonly LineValidator _lineValidator = new();
    private readonly LineConverter _lineConverter = new();

    public string ConvertLinesToXml(List<string> lines)
    {
        // filter out invalid lines
        lines = lines.Where(line => _lineValidator.ValidateLine(line)).ToList();

        var result = new StringBuilder();
        result.Append("<people>\n");

        // group lines into people and parse each person individually
        var people = GroupLinesIntoPeople(lines);
        foreach (var person in people)
        {
            result.Append(ParsePerson(person.Value));
        }

        result.Append("</people>");
        return result.ToString();
    }

    private Dictionary<int, List<string>> GroupLinesIntoPeople(List<string> lines)
    {
        var people = new Dictionary<int, List<string>>();
        int currentPerson = 0;
        foreach (var line in lines)
        {
            var lineType = LineTypeHelper.GetLineType(line);
            if (lineType == LineTypeHelper.LineType.FullName)
            {
                currentPerson++;
                people.Add(currentPerson, new List<string>());
            }

            people[currentPerson].Add(line);
        }

        return people;
    }

    private string ParsePerson(List<string> lines)
    {
        var result = new StringBuilder();
        result.Append("\t<person>\n");
        var hasFamily = false;

        foreach (var line in lines)
        {
            {
                switch (LineTypeHelper.GetLineType(line)) {
                    case LineTypeHelper.LineType.FullName:
                        result.Append(_lineConverter.ConvertFullName(line));
                        break;
                    case LineTypeHelper.LineType.Phone:
                        result.Append(_lineConverter.ConvertPhone(line));
                        break;
                    case LineTypeHelper.LineType.Address:
                        result.Append(_lineConverter.ConvertAddress(line));
                        break;
                    case LineTypeHelper.LineType.Family:
                        if (hasFamily)
                        {
                            result.Append("</family>\n");
                        }                        
                        result.Append(_lineConverter.ConvertFamily(line));
                        hasFamily = true;
                        break;
                }
            }
        }

        if (hasFamily)
        {
            result.Append("</family>\n");
        }
        result.Append("\t</person>\n");
        return result.ToString();
    }
}