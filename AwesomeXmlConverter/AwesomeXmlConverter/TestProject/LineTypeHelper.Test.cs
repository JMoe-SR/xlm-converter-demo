using AwesomeXmlConverter;

namespace TestProject;

public class LineTypeHelperTest
{
    [Test]
    public void CanAssignLineType()
    {
        var resultP = LineTypeHelper.GetLineType(TestData.GetValidFullNameLine);
        var resultT = LineTypeHelper.GetLineType(TestData.GetValidPhoneLine);
        var resultA = LineTypeHelper.GetLineType(TestData.GetValidAddressLine);
        var resultF = LineTypeHelper.GetLineType(TestData.GetValidFamilyMemberLine);

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
        var result1 = LineTypeHelper.GetLineType(TestData.GetInvalidLineType);
        var result2 = LineTypeHelper.GetLineType(TestData.GetInvalidLineNoSeparators);
        var result3 = LineTypeHelper.GetLineType(TestData.GetInvalidLineEmpty);
        var result4 = LineTypeHelper.GetLineType(TestData.GetInvalidLineEmpty2);
        var result5 = LineTypeHelper.GetLineType(TestData.GetInvalidLineEmpty3);
        
        Assert.That(result1, Is.EqualTo(null));
        Assert.That(result2, Is.EqualTo(null));
        Assert.That(result3, Is.EqualTo(null));
        Assert.That(result4, Is.EqualTo(null));
        Assert.That(result5, Is.EqualTo(null));
    }
}