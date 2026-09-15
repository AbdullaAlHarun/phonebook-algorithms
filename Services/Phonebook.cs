using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;

namespace PhonebookAlgorithms.Services;

public class Phonebook
{
    private readonly Contact[] _contacts;
    private long _comparisonCount;

    private Phonebook(Contact[] contacts)
    {
        _contacts = contacts;
    }

    public int Count
    {
        get { return _contacts.Length; }
    }

    public long ComparisonCount
    {
        get { return _comparisonCount; }
    }

    private string GetFieldValue(Contact contact, Field field)
    {
        return field switch
        {
            Field.FirstName => contact.FirstName,
            Field.LastName => contact.LastName,
            Field.Mobile => contact.Mobile,
            _ => throw new ArgumentOutOfRangeException(nameof(field))
        };
    }

    private int CompareValues(string firstValue, string secondValue)
    {
        _comparisonCount++;

        return string.Compare(
            firstValue,
            secondValue,
            StringComparison.OrdinalIgnoreCase);
    }

    private int CompareContacts(Contact first, Contact second, Field field)
    {
        return CompareValues(
            GetFieldValue(first, field),
            GetFieldValue(second, field));
    }

    /// <summary>
    /// Performs a case-insensitive linear search and returns all matches.
    /// Time complexity: O(n). Additional space: O(n).
    /// </summary>
    public Contact[] LinearSearch(Field field, string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        _comparisonCount = 0;

        Contact[] matches = new Contact[_contacts.Length];
        int matchCount = 0;

        for (int i = 0; i < _contacts.Length; i++)
        {
            string contactValue = GetFieldValue(_contacts[i], field);

            if (CompareValues(contactValue, value) == 0)
            {
                matches[matchCount] = _contacts[i];
                matchCount++;
            }
        }

        Contact[] result = new Contact[matchCount];

        for (int i = 0; i < matchCount; i++)
        {
            result[i] = matches[i];
        }

        return result;
    }

    /// <summary>
    /// Loads contacts from the supplied CSV file.
    /// </summary>
    public static Phonebook Load(string csvPath)
    {
        if (!File.Exists(csvPath))
        {
            throw new FileNotFoundException(
                "The phonebook CSV file could not be found.",
                csvPath);
        }

        string[] lines = File.ReadAllLines(csvPath);

        if (lines.Length < 2)
        {
            throw new FormatException(
                "The CSV file does not contain any contacts.");
        }

        Contact[] contacts = new Contact[lines.Length - 1];

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');

            if (values.Length != 6)
            {
                throw new FormatException(
                    $"Invalid data on line {i + 1}.");
            }

            contacts[i - 1] = new Contact
            {
                FirstName = values[0],
                LastName = values[1],
                Mobile = values[2],
                Birthday = values[3],
                Street = values[4],
                City = values[5]
            };
        }

        return new Phonebook(contacts);
    }
}