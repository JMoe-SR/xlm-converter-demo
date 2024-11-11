using AwesomeXmlConverter;

namespace TestProject;

public class JsonLineParserTest
{
    private readonly JsonLineParser _parser = new();
    
    [Test]
    public void CanParseFullName()
    {
        var result = _parser.ParseFullName("P|Carl Gustaf|Bernadotte");
        Assert.That(result.Firstname, Is.EqualTo("Carl Gustaf"));
        Assert.That(result.Lastname, Is.EqualTo("Bernadotte"));
    }
    
    [Test]
    public void CanParsePhone()
    {
        var result = _parser.ParsePhone(TestData.GetValidPhoneLine);
        Assert.That(result.Mobile, Is.EqualTo("0701234567"));
        Assert.That(result.Landline, Is.EqualTo("092012345"));
    }
    
    [Test]
    public void CanParsePhoneWithoutLandline()
    {
        var result = _parser.ParsePhone(TestData.GetValidPhoneLineNoLandline);
        Assert.That(result.Mobile, Is.EqualTo("0701234567"));
        Assert.That(result.Landline, Is.Null);
    }
    
    [Test]
    public void CanParseAddress()
    {
        var result = _parser.ParseAddress(TestData.GetValidAddressLine);
        Assert.That(result.Street, Is.EqualTo("Kantgatan"));
        Assert.That(result.City, Is.EqualTo("Luleå"));
        Assert.That(result.Zip, Is.EqualTo("97436"));
    }
    
    [Test]
    public void CanParseAddressWithoutZip()
    {
        var result = _parser.ParseAddress(TestData.GetValidAddressLineNoZip);
        Assert.That(result.Street, Is.EqualTo("Kantgatan"));
        Assert.That(result.City, Is.EqualTo("Luleå"));
        Assert.That(result.Zip, Is.Null);
    }
    
    [Test]
    public void CanParseFamily()
    {
        var result = _parser.ParseFamilyMember(TestData.GetValidFamilyMemberLine);
        Assert.That(result.Name, Is.EqualTo("Kalle Anka"));
        Assert.That(result.Born, Is.EqualTo("1934-06-09"));
        Assert.That(result.Address, Is.Null);
        Assert.That(result.Phone, Is.Null);
    }
}