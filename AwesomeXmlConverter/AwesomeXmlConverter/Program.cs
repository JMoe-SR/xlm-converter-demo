// See https://aka.ms/new-console-template for more information

using System.Xml;
using AwesomeXmlConverter;
using People = AwesomeXmlConverter.PeopleParser.PeopleObject;

List<string> input = [
    "P|Carl Gustaf|Bernadotte",
    "T|0768-101801|08-101801",
    "A|Drottningholms slott|Stockholm|10001",
    "F|Victoria|1977",
    "A|Haga Slott|Stockholm|10002",
    "F|Carl Philip|1979",
    "T|0768-101802|08-101802",
    "P|Barack|Obama",
    "A|1600 Pennsylvania Avenue|Washington, D.C"
];

PeopleParser converter = new PeopleParser();
XmlConverter xmlConverter = new XmlConverter();

// Convert input to JSON
People people = converter.ParseLines(input);

// Convert JSON to XML
XmlDocument? result = xmlConverter.ConvertJsonToXml(people);

// Write XML to file
xmlConverter.WriteXml(result, "result.xml");