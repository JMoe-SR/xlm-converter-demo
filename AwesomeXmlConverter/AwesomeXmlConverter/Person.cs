namespace AwesomeXmlConverter;

public class Person(
    string firstname,
    string lastname,
    Address? address,
    Phone? phone,
    List<FamilyMember>? family)
{
    public string Firstname { get; } = firstname;
    public string Lastname { get; } = lastname;
    public Address? Address { get; set; } = address;
    public Phone? Phone { get; set; } = phone;
    public List<FamilyMember>? Family { get; set; } = family;
}

public class Address(string street, string city, string? zip)
{
    public string Street { get; } = street;
    public string City { get; } = city;
    public string? Zip { get; } = zip;
}

public class Phone(string mobile, string? landline)
{
    public string Mobile { get; } = mobile;
    public string? Landline { get; } = landline;
}

public class FamilyMember(string name, string born, Address? address, Phone? phone)
{
    public string Name { get; } = name;
    public string Born { get; } = born;
    public Address? Address { get; set; } = address;
    public Phone? Phone { get; set; } = phone;
}

