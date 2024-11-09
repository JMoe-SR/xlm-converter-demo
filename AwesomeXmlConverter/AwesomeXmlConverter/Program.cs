// See https://aka.ms/new-console-template for more information

using AwesomeXmlConverter;

Console.WriteLine("Hello, World!");


List<string> _input = [
    "P|Carl Gustaf|Bernadotte",
    "T|0768-101801|08-101801",
    "A|Drottningholms slott|Stockholm|10001",
    // "F|Victoria|1977",
    // "A|Haga Slott|Stockholm|10002",
    // "F|Carl Philip|1979",
    // "T|0768-101802|08-101802",
    // "P|Barack|Obama",
    // "A|1600 Pennsylvania Avenue|Washington, D.C"
];

XmlConverter converter = new XmlConverter();

var result = converter.ConvertLinesToXml(_input);
Console.Write(result);
