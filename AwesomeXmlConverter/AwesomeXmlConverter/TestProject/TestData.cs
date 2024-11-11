namespace TestProject;

public abstract class TestData
{
    public static string GetValidFullNameLine => "P|Kalle|Anka";
    public static string GetInvalidFullName => "P|Kalle";
    
    public static string GetValidAddressLine => "A|Kantgatan|Luleå|97436";
    public static string GetValidAddressLineNoZip => "A|Kantgatan|Luleå";
    public static string GetInvalidAddressLine => "A|Kantgatan";
    
    public static string GetValidPhoneLine => "T|0701234567|092012345";
    public static string GetValidPhoneLineNoLandline => "T|0701234567";
    public static string GetInvalidPhoneLine => "T|0701234567|092012345|0701234567";
    
    public static string GetValidFamilyMemberLine => "F|Kalle Anka|1934-06-09";
    public static string GetInvalidFamilyMemberLine => "F|Kalle Anka";
    
    public static string GetInvalidLineType => "K|Kalle Anka";
    public static string GetInvalidLineNoSeparators => "Kalle Anka";
    public static string GetInvalidLineEmpty => "";
    public static string GetInvalidLineEmpty2 => " ";
    public static string GetInvalidLineEmpty3 => "|";
    public static string GetInvalidLineTooManyValues => "P| | | | | ";
}