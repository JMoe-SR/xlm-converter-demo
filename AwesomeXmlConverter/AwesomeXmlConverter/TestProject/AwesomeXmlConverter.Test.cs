using AwesomeXmlConverter;

using NUnit.Framework;

namespace TestProject;

public class AwesomeXmlConverterTests
{
    private string input1 = "P|Carl Gustaf|Bernadotte";
    private string input2 = "T|0768-101801|08-101801";
    private string input3 = "A|Drottningholms slott|Stockholm|10001";
    private string input4 = "F|Victoria|1977";
    private string input5 = "A|Haga Slott|Stockholm|10002";
    private string input6 = "F|Carl Philip|1979";
    private string input7 = "T|0768-101802|08-101802";
    private string input8 = "P|Barack|Obama";
    private string input9 = "A|1600 Pennsylvania Avenue|Washington, D.C";
    
    private string input10 = "K|Carl Gustaf|Bernadotte";
    private string input11 = "½";
    
    private readonly XmlConverter _converter = new XmlConverter();

    [Test]
    public void CanAssignLineType()
    {
        var resultP = LineTypeHelper.GetLineType(input1);
        var resultT = LineTypeHelper.GetLineType(input2);
        var resultA = LineTypeHelper.GetLineType(input3);
        var resultF = LineTypeHelper.GetLineType(input4);

        var expectedP = LineTypeHelper.LineType.FullName;
        var expectedT = LineTypeHelper.LineType.Phone;
        var expectedA = LineTypeHelper.LineType.Address;
        var expectedF = LineTypeHelper.LineType.DateOfBirth;
        
        Assert.That(resultP, Is.EqualTo(expectedP));
        Assert.That(resultT, Is.EqualTo(expectedT));
        Assert.That(resultA, Is.EqualTo(expectedA));
        Assert.That(resultF, Is.EqualTo(expectedF));
    } 
    
    [Test]
    public void CanDetectInvalidLineType()
    {
        var result11 = LineTypeHelper.GetLineType(input11);
        Assert.That(result11, Is.EqualTo(null));
    }
    
    [Test]
    public void CanAssessLineFit()
    {
        var result1 = LineValidator.ValidateLine(input1);
        var result12 = LineValidator.ValidateLine(input11);
        Assert.That(result1, Is.True);
        Assert.That(result12, Is.False);
    }
    
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
        Assert.That(result, Is.EqualTo("<phone>\n<mobile>0768-101801</mobile>\n<landline>08-101801</landline>"));
    }
    
    [Test]
    public void CanParseAddress()
    {
        var result = _converter.ConvertAddress(input3);
        Assert.That(result, Is.EqualTo("<address>\n<street>Drottningholms slott</street>\n<city>Stockholm</city>\n<zip>10001</zip>\n</address>"));
    }
    
    [Test]
    public void CanParseDateOfBirth()
    {
        var result = _converter.ConvertDateOfBirth(input4);
        Assert.That(result, Is.EqualTo("<dateofbirth>\n<name>Victoria</name>\n<year>1977</year>\n</dateofbirth>"));
    }

}