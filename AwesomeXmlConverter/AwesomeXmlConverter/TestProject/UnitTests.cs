using AwesomeXmlConverter;

namespace TestProject;

public class Tests
{
    private string input1 = "P|Carl Gustaf|Bernadotte";
    private string input2 = "T|0768-101801|08-101801";
    private string input3 = "A|Drottningholms slott|Stockholm|10001";
    private string input4 = "P|Carl Gustaf|Bernadotte";
    private string input5 = "F|Victoria|1977";
    private string input6 = "A|Haga Slott|Stockholm|10002";
    private string input7 = "F|Carl Philip|1979";
    private string input8 = "T|0768-101802|08-101802";
    private string input9 = "P|Barack|Obama";
    private string input10 = "A|1600 Pennsylvania Avenue|Washington, D.C";
    
    private string input11 = "K|Carl Gustaf|Bernadotte";
    private string input12 = "½";
    
    private readonly XmlConverter _converter = new XmlConverter();

    [Test]
    public void CanAssignLineType()
    {
        var resultP = _converter.GetLineType(input1);
        var resultT = _converter.GetLineType(input2);
        var resultA = _converter.GetLineType(input3);
        var resultF = _converter.GetLineType(input4);
        var resultK = _converter.GetLineType(input11);

        var expectedP = XmlConverter.LineType.FullName;
        var expectedT = XmlConverter.LineType.Phone;
        var expectedA = XmlConverter.LineType.Address;
        var expectedF = XmlConverter.LineType.DateOfBirth;
        var expectedK = XmlConverter.LineType.Unknown;
        
        Assert.That(resultP, Is.EqualTo(expectedP));
        Assert.That(resultT, Is.EqualTo(expectedT));
        Assert.That(resultA, Is.EqualTo(expectedA));
        Assert.That(resultF, Is.EqualTo(expectedF));
        Assert.That(resultK, Is.EqualTo(expectedK));
    } 
    
    [Test]
    public void CanAssessLineFit()
    {
        var result1 = _converter.ValidateLine(input1);
        var result2 = _converter.ValidateLine(input2);
        Assert.Pass();
    }   
    
    [Test]
    public void CanParsePartialLine()
    {
        Assert.Pass();
    }   
    
    [Test]
    public void FailsToParseNonsense()
    {
        Assert.Pass();
    }
}