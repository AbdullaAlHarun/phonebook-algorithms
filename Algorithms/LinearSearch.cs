using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms.Algorithms;

public class LinearSearch
{
    private readonly ContactComparer _comparer;

    public LinearSearch(ContactComparer comparer)
    {
        _comparer = comparer;
    }

    /// <summary>
    /// Performs a case-insensitive linear search on the selected field
    /// and returns all matching contacts.
    /// Time complexity: O(n).
    /// Additional space: O(n) for storing the matches.
    /// </summary>
    public Contact[] Search(
        Contact[] contacts,
        Field field,
        string value)
    {
        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts));
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        _comparer.ResetCount();

        Contact[] matches =
            new Contact[contacts.Length];

        int matchCount = 0;

        for (int i = 0; i < contacts.Length; i++)
        {
            string contactValue =
                _comparer.GetFieldValue(
                    contacts[i],
                    field);

            if (_comparer.CompareValues(
                    contactValue,
                    value) == 0)
            {
                matches[matchCount] = contacts[i];
                matchCount++;
            }
        }

        Contact[] result =
            new Contact[matchCount];

        for (int i = 0; i < matchCount; i++)
        {
            result[i] = matches[i];
        }

        return result;
    }
}