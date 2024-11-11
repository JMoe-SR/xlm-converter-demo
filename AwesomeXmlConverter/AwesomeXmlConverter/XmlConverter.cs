using System.Xml;
using Newtonsoft.Json;
using People = AwesomeXmlConverter.PeopleParser.PeopleObject;

namespace AwesomeXmlConverter;

public class XmlConverter
{
    // @TODO: Add tests for this class if needed
    public XmlDocument? ConvertJsonToXml(People people)
    {
        // Configure JSON serialization settings to ignore null values
        // and use camelCase property names
        var jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
        };
        
        string jsonString = JsonConvert.SerializeObject(people, jsonSettings);

        return JsonConvert.DeserializeXmlNode(jsonString, "people");  
    }

    public void WriteXml(XmlDocument? result, string filepath)
    {
        if (result != null)
        {
            result.Save(filepath);
            Console.WriteLine($"XML file saved to {filepath}");
        }
        else
        {
            Console.WriteLine("Failed to convert lines to XML.");
        }
    }
}