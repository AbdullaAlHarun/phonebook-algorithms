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
            Console.WriteLine("PHONEBOOK - SEARCHING AND SORTING");
            Console.WriteLine("=================================");
            Console.WriteLine();

            Phonebook phonebook = Phonebook.Load("phonebook.csv");

            Console.WriteLine(
                $"Loaded {phonebook.Count} contacts from phonebook.csv");
            Console.WriteLine();

            RunSortingTests();
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

    private static void RunSortingTests()
    {
        Console.WriteLine("--- Sorting Correctness Tests ---");
        Console.WriteLine();

        Console.WriteLine(
            "{0,-12} {1,-12} {2,-12} {3,-8} {4,12} {5,10}",
            "Algorithm",
            "Field",
            "Order",
            "Result",
            "Comparisons",
            "Moves");

        Console.WriteLine(new string('-', 72));

        TestInsertionSort(Field.FirstName, SortOrder.Ascending);
        TestInsertionSort(Field.FirstName, SortOrder.Descending);

        TestInsertionSort(Field.LastName, SortOrder.Ascending);
        TestInsertionSort(Field.LastName, SortOrder.Descending);

        TestInsertionSort(Field.Mobile, SortOrder.Ascending);
        TestInsertionSort(Field.Mobile, SortOrder.Descending);

        TestMergeSort(Field.FirstName, SortOrder.Ascending);
        TestMergeSort(Field.FirstName, SortOrder.Descending);

        TestMergeSort(Field.LastName, SortOrder.Ascending);
        TestMergeSort(Field.LastName, SortOrder.Descending);

        TestMergeSort(Field.Mobile, SortOrder.Ascending);
        TestMergeSort(Field.Mobile, SortOrder.Descending);

        Console.WriteLine();

        RunEdgeCaseTests();
    }

    private static void TestInsertionSort(
        Field field,
        SortOrder order)
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.InsertionSort(field, order);

        bool sorted = IsSorted(phonebook, field, order);

        PrintSortResult(
            "Insertion",
            field,
            order,
            sorted,
            phonebook.ComparisonCount,
            phonebook.MoveCount);
    }

    private static void TestMergeSort(
        Field field,
        SortOrder order)
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.MergeSort(field, order);

        bool sorted = IsSorted(phonebook, field, order);

        PrintSortResult(
            "Merge",
            field,
            order,
            sorted,
            phonebook.ComparisonCount,
            phonebook.MoveCount);
    }

    private static void PrintSortResult(
        string algorithm,
        Field field,
        SortOrder order,
        bool passed,
        long comparisons,
        long moves)
    {
        Console.WriteLine(
            "{0,-12} {1,-12} {2,-12} {3,-8} {4,12} {5,10}",
            algorithm,
            field,
            order,
            passed ? "PASS" : "FAIL",
            comparisons,
            moves);
    }

    private static bool IsSorted(
        Phonebook phonebook,
        Field field,
        SortOrder order)
    {
        for (int i = 1; i < phonebook.Count; i++)
        {
            string previous =
                GetFieldValue(
                    phonebook.GetContact(i - 1),
                    field);

            string current =
                GetFieldValue(
                    phonebook.GetContact(i),
                    field);

            int comparison = string.Compare(
                previous,
                current,
                StringComparison.OrdinalIgnoreCase);

            if (order == SortOrder.Ascending &&
                comparison > 0)
            {
                return false;
            }

            if (order == SortOrder.Descending &&
                comparison < 0)
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

            _ => throw new ArgumentOutOfRangeException(
                nameof(field))
        };
    }

    private static void RunEdgeCaseTests()
    {
        Console.WriteLine("--- Sorting Edge Cases ---");
        Console.WriteLine();

        Console.WriteLine(
            "{0,-12} {1,-18} {2,-8}",
            "Algorithm",
            "Test",
            "Result");

        Console.WriteLine(new string('-', 40));

        TestInsertionEmpty();
        TestInsertionSingle();

        TestMergeEmpty();
        TestMergeSingle();

        Console.WriteLine();
    }

    private static void TestInsertionEmpty()
    {
        Phonebook phonebook =
            Phonebook.FromContacts(
                Array.Empty<Contact>());

        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Ascending);

        bool passed = phonebook.Count == 0;

        PrintEdgeResult(
            "Insertion",
            "Empty array",
            passed);
    }

    private static void TestInsertionSingle()
    {
        Phonebook phonebook =
            Phonebook.FromContacts(
                new[] { CreateTestContact() });

        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Ascending);

        bool passed =
            phonebook.Count == 1 &&
            phonebook.GetContact(0).LastName == "Person";

        PrintEdgeResult(
            "Insertion",
            "Single element",
            passed);
    }

    private static void TestMergeEmpty()
    {
        Phonebook phonebook =
            Phonebook.FromContacts(
                Array.Empty<Contact>());

        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        bool passed = phonebook.Count == 0;

        PrintEdgeResult(
            "Merge",
            "Empty array",
            passed);
    }

    private static void TestMergeSingle()
    {
        Phonebook phonebook =
            Phonebook.FromContacts(
                new[] { CreateTestContact() });

        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        bool passed =
            phonebook.Count == 1 &&
            phonebook.GetContact(0).LastName == "Person";

        PrintEdgeResult(
            "Merge",
            "Single element",
            passed);
    }

    private static Contact CreateTestContact()
    {
        return new Contact
        {
            FirstName = "Test",
            LastName = "Person",
            Mobile = "12345678",
            Birthday = "2000-01-01",
            Street = "Test Street 1",
            City = "Oslo"
        };
    }

    private static void PrintEdgeResult(
        string algorithm,
        string test,
        bool passed)
    {
        Console.WriteLine(
            "{0,-12} {1,-18} {2,-8}",
            algorithm,
            test,
            passed ? "PASS" : "FAIL");
    }
}