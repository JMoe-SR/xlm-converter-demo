using System.Xml;
using static AwesomeXmlConverter.LineValidator;

namespace AwesomeXmlConverter;

public class PeopleParser
{
    private readonly JsonLineParser _jsonLineParser = new();

    public class PeopleObject(List<Person> people)
    {
        public List<Person> People { get; } = people;
    }

    public PeopleObject ParseLines(List<string> validatedLines)
    {
        // filter out invalid lines
        validatedLines = validatedLines.Where(ValidateLine).ToList();
        
        // parse lines into Person objects
        var people = new PeopleObject([]);
        var peopleDictionary = GroupLinesIntoPeople(validatedLines);
        foreach (var person in peopleDictionary)
        {
            people.People.Add(ParsePerson(person.Value));
        }

        return people;
    }

    private Person ParsePerson(List<string> validatedLines)
    {
        // Create Person Object from FullName line
        var person = _jsonLineParser.ParseFullName(validatedLines[0]);
        FamilyMember? currentFamilyMember = null;
        
        // Parse the rest of the lines
        foreach (var line in validatedLines)
        {
            switch (LineTypeHelper.GetLineType(line))
            {
                case LineTypeHelper.LineType.Phone:
                    if(currentFamilyMember is not null)
                    {
                        currentFamilyMember.Phone = _jsonLineParser.ParsePhone(line);
                    }
                    else
                    {
                        person.Phone = _jsonLineParser.ParsePhone(line);
                    }
                    break;
                case LineTypeHelper.LineType.Address:
                    if(currentFamilyMember is not null)
                    {
                        currentFamilyMember.Address = _jsonLineParser.ParseAddress(line);
                    }
                    else
                    {
                        person.Address = _jsonLineParser.ParseAddress(line);
                    }
                    break;
                case LineTypeHelper.LineType.Family:
                    if (currentFamilyMember is not null)
                    {
                        if (person.Family != null)
                        {
                            person.Family.Add(currentFamilyMember);
                        }
                        else
                        {
                            person.Family = [currentFamilyMember];
                        }
                    }
                    currentFamilyMember = _jsonLineParser.ParseFamilyMember(line);
                    break;
            }
        }

        // Add the last family member to the person
        if (currentFamilyMember is not null)
        {
            if (person.Family != null)
            {
                person.Family.Add(currentFamilyMember);
            }
            else
            {
                person.Family = [currentFamilyMember];
            }
        }

        return person;
    }

    private static Dictionary<int, List<string>> GroupLinesIntoPeople(List<string> lines)
    {
        var people = new Dictionary<int, List<string>>();
        
        // Person 0 catches lines before the first FullName line
        var currentPerson = 0;
        foreach (var line in lines)
        {
            var lineType = LineTypeHelper.GetLineType(line);
            if (lineType == LineTypeHelper.LineType.FullName)
            {
                currentPerson++;
                people.Add(currentPerson, new List<string>());
            }

            people[currentPerson].Add(line);
        }
        
        // Remove Person 0
        people.Remove(0);

        return people;
    }
}