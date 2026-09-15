using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms.Algorithms;

public class MergeSort
{
    private readonly ContactComparer _comparer;

    public long MoveCount { get; private set; }

    public MergeSort(ContactComparer comparer)
    {
        _comparer = comparer;
    }

    /// <summary>
    /// Sorts the contact array using Merge Sort.
    /// Time complexity: O(n log n).
    /// Additional space: O(n) for the temporary array.
    /// A move is counted when a contact is copied
    /// from the temporary array back to the main array.
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

        if (contacts.Length <= 1)
        {
            return;
        }

        Contact[] temp =
            new Contact[contacts.Length];

        SortRecursive(
            contacts,
            temp,
            0,
            contacts.Length - 1,
            field,
            order);
    }

    private void SortRecursive(
        Contact[] contacts,
        Contact[] temp,
        int left,
        int right,
        Field field,
        SortOrder order)
    {
        if (left >= right)
        {
            return;
        }

        int middle =
            left + (right - left) / 2;

        SortRecursive(
            contacts,
            temp,
            left,
            middle,
            field,
            order);

        SortRecursive(
            contacts,
            temp,
            middle + 1,
            right,
            field,
            order);

        Merge(
            contacts,
            temp,
            left,
            middle,
            right,
            field,
            order);
    }

    private void Merge(
        Contact[] contacts,
        Contact[] temp,
        int left,
        int middle,
        int right,
        Field field,
        SortOrder order)
    {
        int i = left;
        int j = middle + 1;
        int k = left;

        while (i <= middle && j <= right)
        {
            int comparison =
                _comparer.CompareContacts(
                    contacts[i],
                    contacts[j],
                    field);

            bool takeLeft =
                order == SortOrder.Ascending
                    ? comparison <= 0
                    : comparison >= 0;

            if (takeLeft)
            {
                temp[k] = contacts[i];
                i++;
            }
            else
            {
                temp[k] = contacts[j];
                j++;
            }

            k++;
        }

        while (i <= middle)
        {
            temp[k] = contacts[i];
            i++;
            k++;
        }

        while (j <= right)
        {
            temp[k] = contacts[j];
            j++;
            k++;
        }

        for (int index = left;
             index <= right;
             index++)
        {
            contacts[index] = temp[index];
            MoveCount++;
        }
    }
}