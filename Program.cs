using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("=== Phonebook Algorithms ===");
            Console.WriteLine();

            TestInsertionSort(
                Field.FirstName,
                SortOrder.Ascending);

            TestInsertionSort(
                Field.FirstName,
                SortOrder.Descending);

            TestInsertionSort(
                Field.LastName,
                SortOrder.Ascending);

            TestInsertionSort(
                Field.LastName,
                SortOrder.Descending);

            TestInsertionSort(
                Field.Mobile,
                SortOrder.Ascending);

            TestInsertionSort(
                Field.Mobile,
                SortOrder.Descending);

            TestEmptyArray();
            TestSingleElement();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Data error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    private static void TestInsertionSort(
        Field field,
        SortOrder order)
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.InsertionSort(field, order);

        bool sorted = IsSorted(phonebook, field, order);

        Console.WriteLine(
            $"Insertion Sort | {field} | {order}");

        Console.WriteLine(
            $"Result: {(sorted ? "PASS" : "FAIL")}");

        Console.WriteLine(
            $"Comparisons: {phonebook.ComparisonCount}");

        Console.WriteLine(
            $"Moves: {phonebook.MoveCount}");

        Console.WriteLine();
    }

    private static bool IsSorted(
        Phonebook phonebook,
        Field field,
        SortOrder order)
    {
        for (int i = 1; i < phonebook.Count; i++)
        {
            string previous =
                GetFieldValue(phonebook.GetContact(i - 1), field);

            string current =
                GetFieldValue(phonebook.GetContact(i), field);

            int comparison = string.Compare(
                previous,
                current,
                StringComparison.OrdinalIgnoreCase);

            if (order == SortOrder.Ascending && comparison > 0)
            {
                return false;
            }

            if (order == SortOrder.Descending && comparison < 0)
            {
                return false;
            }
        }

        return true;
    }

    private static string GetFieldValue(
        Contact contact,
        Field field)
    {
        return field switch
        {
            Field.FirstName => contact.FirstName,
            Field.LastName => contact.LastName,
            Field.Mobile => contact.Mobile,
            _ => throw new ArgumentOutOfRangeException(nameof(field))
        };
    }

    private static void TestEmptyArray()
    {
        Phonebook phonebook =
            Phonebook.FromContacts(Array.Empty<Contact>());

        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Ascending);

        bool passed = phonebook.Count == 0;

        Console.WriteLine("Insertion Sort | Empty array");
        Console.WriteLine(
            $"Result: {(passed ? "PASS" : "FAIL")}");
        Console.WriteLine();
    }

    private static void TestSingleElement()
    {
        Contact contact = new Contact
        {
            FirstName = "Test",
            LastName = "Person",
            Mobile = "12345678",
            Birthday = "2000-01-01",
            Street = "Test Street 1",
            City = "Oslo"
        };

        Phonebook phonebook =
            Phonebook.FromContacts(new[] { contact });

        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Ascending);

        bool passed =
            phonebook.Count == 1 &&
            phonebook.GetContact(0).LastName == "Person";

        Console.WriteLine("Insertion Sort | Single element");
        Console.WriteLine(
            $"Result: {(passed ? "PASS" : "FAIL")}");
        Console.WriteLine();
    }
}