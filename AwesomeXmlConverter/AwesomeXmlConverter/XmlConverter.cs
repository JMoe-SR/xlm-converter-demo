using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using People = AwesomeXmlConverter.PeopleParser.PeopleObject;

namespace AwesomeXmlConverter;

public class XmlConverter
{
    public XmlDocument? ConvertJsonToXml(People people)
    {
        // Configure JSON serialization settings to ignore null values
        var jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };
        
        string jsonString = JsonConvert.SerializeObject(people, jsonSettings);

        return JsonConvert.DeserializeXmlNode(jsonString, "People");  }

    public void WriteXml(XmlDocument? result, string filename)
    {
        if (result != null)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output", filename);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            result.Save(filePath);
            Console.WriteLine($"XML file saved to {filePath}");
        }
        else
        {
            Console.WriteLine("Failed to convert lines to XML.");
        }
    }
}