using PhonebookAlgorithms.Algorithms;
using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;

namespace PhonebookAlgorithms.Services;

public class Phonebook
{
    private readonly Contact[] _contacts;
    private readonly ContactComparer _comparer;

    private Phonebook(Contact[] contacts)
    {
        _contacts = contacts;
        _comparer = new ContactComparer();
    }

    public int Count
    {
        get { return _contacts.Length; }
    }

    public long ComparisonCount
    {
        get { return _comparer.ComparisonCount; }
    }

    /// <summary>
    /// Performs a linear search on the selected field.
    /// Time complexity: O(n). Additional space: O(n).
    /// </summary>
    public Contact[] LinearSearch(Field field, string value)
    {
        LinearSearch search = new LinearSearch(_comparer);
        return search.Search(_contacts, field, value);
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