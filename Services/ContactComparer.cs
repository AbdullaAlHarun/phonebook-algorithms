using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;

namespace PhonebookAlgorithms.Services;

/// <summary>
/// Provides field-based, case-insensitive comparison of contacts
/// and counts the number of value comparisons performed.
/// </summary>
public class ContactComparer
{
    public long ComparisonCount { get; private set; }

    /// <summary>
    /// Resets the comparison counter to zero.
    /// </summary>
    public void ResetCount()
    {
        ComparisonCount = 0;
    }

    /// <summary>
    /// Returns the value of the selected searchable field
    /// from a contact.
    /// </summary>
    public string GetFieldValue(
        Contact contact,
        Field field)
    {
        return field switch
        {
            Field.FirstName => contact.FirstName,
            Field.LastName => contact.LastName,
            Field.Mobile => contact.Mobile,
            _ => throw new ArgumentOutOfRangeException(
                nameof(field))
        };
    }

    /// <summary>
    /// Compares two string values without considering letter case
    /// and increases the comparison counter by one.
    /// </summary>
    public int CompareValues(
        string firstValue,
        string secondValue)
    {
        ComparisonCount++;

        return string.Compare(
            firstValue,
            secondValue,
            StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Compares two contacts using the selected field.
    /// The comparison is case-insensitive.
    /// </summary>
    public int CompareContacts(
        Contact first,
        Contact second,
        Field field)
    {
        return CompareValues(
            GetFieldValue(first, field),
            GetFieldValue(second, field));
    }
}