using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms.Algorithms;

public class InsertionSort
{
    private readonly ContactComparer _comparer;

    public long MoveCount { get; private set; }

    public InsertionSort(ContactComparer comparer)
    {
        _comparer = comparer;
    }

    /// <summary>
    /// Sorts the contact array using Insertion Sort.
    /// Best case: O(n).
    /// Average and worst case: O(n²).
    /// Additional space: O(1).
    /// A move is counted when a contact is shifted
    /// to another position in the array.
    /// </summary>
    public void Sort(
        Contact[] contacts,
        Field field,
        SortOrder order)
    {
        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts));
        }

        _comparer.ResetCount();
        MoveCount = 0;

        for (int i = 1; i < contacts.Length; i++)
        {
            Contact current = contacts[i];
            int j = i - 1;

            while (j >= 0)
            {
                int comparison =
                    _comparer.CompareContacts(
                        contacts[j],
                        current,
                        field);

                bool shouldMove =
                    order == SortOrder.Ascending
                        ? comparison > 0
                        : comparison < 0;

                if (!shouldMove)
                {
                    break;
                }

                contacts[j + 1] = contacts[j];
                MoveCount++;

                j--;
            }

            contacts[j + 1] = current;
        }
    }
}