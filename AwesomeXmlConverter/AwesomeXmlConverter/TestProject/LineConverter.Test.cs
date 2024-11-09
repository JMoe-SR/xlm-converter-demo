using AwesomeXmlConverter;

namespace TestProject;

public class LineConverterTests
{
    private string input1 = "P|Carl Gustaf|Bernadotte";
    private string input2 = "T|0768-101801|08-101801";
    private string input3 = "A|Drottningholms slott|Stockholm|10001";
    private string input4 = "F|Victoria|1977";
    
    private readonly LineConverter _converter = new ();
    
    [Test]
    public void CanParseFullName()
    {
        var result = _converter.ConvertFullName(input1);
        Assert.That(result, Is.EqualTo("<firstname>Carl Gustaf</firstname>\n<lastname>Bernadotte</lastname>"));
    }
    
    [Test]
    public void CanParsePhone()
    {
        var result = _converter.ConvertPhone(input2);
        Assert.That(result, Is.EqualTo(
            "<phone>\n" +
            "\t<mobile>0768-101801</mobile>\n" +
            "\t<landline>08-101801</landline>\n" +
            "</phone>"));
    }
    
    [Test]
    public void CanParseAddress()
    {
        var result = _converter.ConvertAddress(input3);
        Assert.That(result, Is.EqualTo(
            "<address>\n" +
            "\t<street>Drottningholms slott</street>\n" +
            "\t<city>Stockholm</city>\n" +
            "\t<zip>10001</zip>\n" +
            "</address>"));
    }
    
    [Test]
    public void CanParseFamily()
    {
        var result = _converter.ConvertFamily(input4);
        Assert.That(result, Is.EqualTo(
            "<family>\n" +
            "\t<name>Victoria</name>\n" +
            "\t<born>1977</born>\n"));
    }
}