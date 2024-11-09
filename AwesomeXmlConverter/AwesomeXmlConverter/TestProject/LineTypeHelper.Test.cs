using AwesomeXmlConverter;

namespace TestProject;

public class LineTypeHelperTest
{
    private string input1 = "P|Carl Gustaf|Bernadotte";
    private string input2 = "T|0768-101801|08-101801";
    private string input3 = "A|Drottningholms slott|Stockholm|10001";
    private string input4 = "F|Victoria|1977";
    private string input11 = "½";
    
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
        var expectedF = LineTypeHelper.LineType.Family;
        
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
}