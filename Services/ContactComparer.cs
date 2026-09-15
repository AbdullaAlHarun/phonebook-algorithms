using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;

namespace PhonebookAlgorithms.Services;

public class ContactComparer
{
    public long ComparisonCount { get; private set; }

    public void ResetCount()
    {
        ComparisonCount = 0;
    }

    public string GetFieldValue(Contact contact, Field field)
    {
        return field switch
        {
            Field.FirstName => contact.FirstName,
            Field.LastName => contact.LastName,
            Field.Mobile => contact.Mobile,
            _ => throw new ArgumentOutOfRangeException(nameof(field))
        };
    }

    public int CompareValues(string firstValue, string secondValue)
    {
        ComparisonCount++;

        return string.Compare(
            firstValue,
            secondValue,
            StringComparison.OrdinalIgnoreCase);
    }

    public int CompareContacts(Contact first, Contact second, Field field)
    {
        return CompareValues(
            GetFieldValue(first, field),
            GetFieldValue(second, field));
    }
}