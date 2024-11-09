using AwesomeXmlConverter;

namespace TestProject;

public class LineValidatorTests
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
    private string input12 = "P|Calle|Gurra|Dutte|Berra";
    

    [Test]
    public void CanAssessLineFit()
    {
        var result1 = LineValidator.ValidateLine(input1);
        var result10 = LineValidator.ValidateLine(input10);
        var result11 = LineValidator.ValidateLine(input11);
        var result12 = LineValidator.ValidateLine(input12);
        Assert.That(result1, Is.True);
        Assert.That(result10, Is.False);
        Assert.That(result11, Is.False);
        Assert.That(result12, Is.False);
    }
}