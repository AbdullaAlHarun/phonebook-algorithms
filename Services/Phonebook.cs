using PhonebookAlgorithms.Models;

namespace PhonebookAlgorithms.Services;

public class Phonebook
{
    private readonly Contact[] _contacts;

    private Phonebook(Contact[] contacts)
    {
        _contacts = contacts;
    }

    public int Count
    {
        get { return _contacts.Length; }
    }
    
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
                "The phonebook CSV file does not contain any contacts.");
        }

        Contact[] contacts = new Contact[lines.Length - 1];

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');

            if (values.Length != 6)
            {
                throw new FormatException(
                    $"Invalid CSV data on line {i + 1}. Expected 6 columns.");
            }

            Contact contact = new Contact
            {
                FirstName = values[0],
                LastName = values[1],
                Mobile = values[2],
                Birthday = values[3],
                Street = values[4],
                City = values[5]
            };

            contacts[i - 1] = contact;
        }

        return new Phonebook(contacts);
    }
}