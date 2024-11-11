namespace AwesomeXmlConverter;

public class JsonLineParser
{
    public Person ParseFullName(string line)
    {
        List<string> split = line.Split('|').ToList();
        return new Person(
            firstname: split[1],
            lastname: split[2],
            null,
            null,
            null);
    }
    
    public Address ParseAddress(string line)
    {
        List<string> split = line.Split('|').ToList();
        return new Address(
            street: split[1], 
            city: split[2],
            zip: split.Count > 3 ? split[3] : null);
    }
    
    public Phone ParsePhone(string line)
    {
        List<string> split = line.Split('|').ToList();
        return new Phone(
            mobile: split[1],
            landline: split.Count > 2 ? split[2] : null);
    }
    
    public FamilyMember ParseFamilyMember(string line)
    {
        List<string> split = line.Split('|').ToList();
        return new FamilyMember(
            name: split[1],
            born: split[2],
            null,
            null);
    }
}