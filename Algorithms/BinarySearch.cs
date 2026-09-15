using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms.Algorithms;

public class BinarySearch
{
    private readonly ContactComparer _comparer;

    public BinarySearch(ContactComparer comparer)
    {
        _comparer = comparer;
    }

    /// <summary>
    /// Searches a contact array that is sorted in ascending order
    /// by the selected field.
    /// Returns the lowest matching index, or -1 if no match is found.
    /// Time complexity: O(log n).
    /// Additional space: O(1).
    /// </summary>
    public int Search(
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

        int left = 0;
        int right = contacts.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int middle =
                left + (right - left) / 2;

            string middleValue =
                _comparer.GetFieldValue(
                    contacts[middle],
                    field);

            int comparison =
                _comparer.CompareValues(
                    middleValue,
                    value);

            if (comparison == 0)
            {
                result = middle;

                // Continue to the left to find
                // the first occurrence of a duplicate.
                right = middle - 1;
            }
            else if (comparison < 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return result;
    }
}