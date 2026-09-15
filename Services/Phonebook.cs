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

    public long MoveCount { get; private set; }

    /// <summary>
    /// Performs a linear search on the selected field.
    /// Returns all contacts whose field matches the search value.
    /// </summary>
    public Contact[] LinearSearch(Field field, string value)
    {
        LinearSearch search = new LinearSearch(_comparer);

        return search.Search(
            _contacts,
            field,
            value);
    }

    /// <summary>
    /// Sorts the phonebook using Insertion Sort.
    /// </summary>
    public void InsertionSort(Field field, SortOrder order)
    {
        PhonebookAlgorithms.Algorithms.InsertionSort sorter =
            new PhonebookAlgorithms.Algorithms.InsertionSort(_comparer);

        sorter.Sort(
            _contacts,
            field,
            order);

        MoveCount = sorter.MoveCount;
    }

    /// <summary>
    /// Sorts the phonebook using Merge Sort.
    /// </summary>
    public void MergeSort(Field field, SortOrder order)
    {
        PhonebookAlgorithms.Algorithms.MergeSort sorter =
            new PhonebookAlgorithms.Algorithms.MergeSort(_comparer);

        sorter.Sort(
            _contacts,
            field,
            order);

        MoveCount = sorter.MoveCount;
    }

    /// <summary>
    /// Performs Binary Search on a phonebook that is already
    /// sorted in ascending order by the selected field.
    /// Returns the lowest matching index, or -1 if not found.
    /// </summary>
    public int BinarySearch(Field field, string value)
    {
        PhonebookAlgorithms.Algorithms.BinarySearch search =
            new PhonebookAlgorithms.Algorithms.BinarySearch(_comparer);

        return search.Search(
            _contacts,
            field,
            value);
    }

    /// <summary>
    /// Returns the contact stored at the specified index.
    /// </summary>
    public Contact GetContact(int index)
    {
        if (index < 0 || index >= _contacts.Length)
        {
            throw new ArgumentOutOfRangeException(
                nameof(index));
        }

        return _contacts[index];
    }

    /// <summary>
    /// Creates a Phonebook from an existing contact array.
    /// A copy of the array is stored internally.
    /// This method is used for edge-case testing.
    /// </summary>
    public static Phonebook FromContacts(Contact[] contacts)
    {
        if (contacts == null)
        {
            throw new ArgumentNullException(
                nameof(contacts));
        }

        Contact[] copy =
            new Contact[contacts.Length];

        for (int i = 0; i < contacts.Length; i++)
        {
            copy[i] = contacts[i];
        }

        return new Phonebook(copy);
    }

    /// <summary>
    /// Loads exactly 200 contacts from the supplied CSV file.
    /// The first line is treated as the CSV header.
    /// </summary>
    public static Phonebook Load(string csvPath)
    {
        if (!File.Exists(csvPath))
        {
            throw new FileNotFoundException(
                "The phonebook CSV file could not be found.",
                csvPath);
        }

        string[] lines =
            File.ReadAllLines(csvPath);

        if (lines.Length < 2)
        {
            throw new FormatException(
                "The CSV file does not contain any contacts.");
        }

        int contactCount = lines.Length - 1;

        if (contactCount != 200)
        {
            throw new FormatException(
                $"Expected exactly 200 contacts, " +
                $"but found {contactCount}.");
        }

        Contact[] contacts =
            new Contact[contactCount];

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values =
                lines[i].Split(',');

            if (values.Length != 6)
            {
                throw new FormatException(
                    $"Invalid data on line {i + 1}. " +
                    "Expected 6 fields.");
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