using AwesomeXmlConverter;

namespace TestProject;

public class LineValidatorTests
{
    private readonly LineValidator _lineValidator = new ();
    
    private string input1 = "P|Carl Gustaf|Bernadotte";
    
    private string input10 = "K|Carl Gustaf|Bernadotte";
    private string input11 = "½";
    private string input12 = "P|Calle|Gurra|Dutte|Berra";
    

    [Test]
    public void CanAssessLineFit()
    {
        var result1 = _lineValidator.ValidateLine(input1);
        var result10 = _lineValidator.ValidateLine(input10);
        var result11 = _lineValidator.ValidateLine(input11);
        var result12 = _lineValidator.ValidateLine(input12);
        Assert.That(result1, Is.True);
        Assert.That(result10, Is.False);
        Assert.That(result11, Is.False);
        Assert.That(result12, Is.False);
    }
}