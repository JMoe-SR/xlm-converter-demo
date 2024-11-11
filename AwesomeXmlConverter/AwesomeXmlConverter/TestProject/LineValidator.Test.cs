using AwesomeXmlConverter;

namespace TestProject;

public class LineValidatorTests
{
    [Test]
    public void CanAssessLineFit()
    {
        var result1 = LineValidator.ValidateLine(TestData.GetValidFullNameLine);
        var result2 = LineValidator.ValidateLine(TestData.GetInvalidFullName);
        var result3 = LineValidator.ValidateLine(TestData.GetValidAddressLine);
        var result4 = LineValidator.ValidateLine(TestData.GetValidAddressLineNoZip);
        var result5 = LineValidator.ValidateLine(TestData.GetInvalidAddressLine);
        var result6 = LineValidator.ValidateLine(TestData.GetValidPhoneLine);
        var result7 = LineValidator.ValidateLine(TestData.GetValidPhoneLineNoLandline);
        var result8 = LineValidator.ValidateLine(TestData.GetInvalidPhoneLine);
        var result9 = LineValidator.ValidateLine(TestData.GetValidFamilyMemberLine);
        var result10 = LineValidator.ValidateLine(TestData.GetInvalidFamilyMemberLine);
        var result11 = LineValidator.ValidateLine(TestData.GetInvalidLineType);
        var result12 = LineValidator.ValidateLine(TestData.GetInvalidLineNoSeparators);
        var result13 = LineValidator.ValidateLine(TestData.GetInvalidLineEmpty);
        var result14 = LineValidator.ValidateLine(TestData.GetInvalidLineEmpty2);
        var result15 = LineValidator.ValidateLine(TestData.GetInvalidLineEmpty3);
        var result16 = LineValidator.ValidateLine(TestData.GetInvalidLineTooManyValues);
        
        Assert.That(result1, Is.True);
        Assert.That(result2, Is.False);
        Assert.That(result3, Is.True);
        Assert.That(result4, Is.True);
        Assert.That(result5, Is.False);
        Assert.That(result6, Is.True);
        Assert.That(result7, Is.True);
        Assert.That(result8, Is.False);
        Assert.That(result9, Is.True);
        Assert.That(result10, Is.False);
        Assert.That(result11, Is.False);
        Assert.That(result12, Is.False);
        Assert.That(result13, Is.False);
        Assert.That(result14, Is.False);
        Assert.That(result15, Is.False);
        Assert.That(result16, Is.False);
    }
}