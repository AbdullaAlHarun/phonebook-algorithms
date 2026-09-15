using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms.Tests;

public static class BinarySearchTests
{
    public static void Run()
    {
        Console.WriteLine("--- 3. Binary Search Tests ---");
        Console.WriteLine();

        Console.WriteLine(
            "{0,-5} {1,-12} {2,-18} {3,10} {4,14}",
            "Test",
            "Field",
            "Target",
            "Result",
            "Comparisons");

        Console.WriteLine(new string('-', 65));

        TestExistingMobile();
        TestMobileBelowRange();
        TestMobileAboveRange();
        TestDuplicateLastName();
        TestAbsentLastName();
        TestDuplicateFirstName();
        TestEmptyArray();
        TestSingleElement();

        Console.WriteLine();
    }

    private static void TestExistingMobile()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.MergeSort(
            Field.Mobile,
            SortOrder.Ascending);

        string target =
            phonebook.GetContact(phonebook.Count / 2).Mobile;

        int result =
            phonebook.BinarySearch(Field.Mobile, target);

        PrintResult(
            1,
            "Mobile",
            target,
            result,
            phonebook.ComparisonCount);
    }

    private static void TestMobileBelowRange()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.MergeSort(
            Field.Mobile,
            SortOrder.Ascending);

        int result =
            phonebook.BinarySearch(
                Field.Mobile,
                "00000000");

        PrintResult(
            2,
            "Mobile",
            "00000000",
            result,
            phonebook.ComparisonCount);
    }

    private static void TestMobileAboveRange()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.MergeSort(
            Field.Mobile,
            SortOrder.Ascending);

        int result =
            phonebook.BinarySearch(
                Field.Mobile,
                "99999999");

        PrintResult(
            3,
            "Mobile",
            "99999999",
            result,
            phonebook.ComparisonCount);
    }

    private static void TestDuplicateLastName()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        string target =
            FindDuplicateLastName(phonebook);

        int result =
            phonebook.BinarySearch(
                Field.LastName,
                target);

        PrintResult(
            4,
            "LastName",
            target,
            result,
            phonebook.ComparisonCount);

        if (result > 0)
        {
            Console.WriteLine(
                $"      Previous entry: " +
                $"{phonebook.GetContact(result - 1).LastName}");
        }
    }

    private static void TestAbsentLastName()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        const string target = "Aardal";

        int result =
            phonebook.BinarySearch(
                Field.LastName,
                target);

        PrintResult(
            5,
            "LastName",
            target,
            result,
            phonebook.ComparisonCount);
    }

    private static void TestDuplicateFirstName()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.MergeSort(
            Field.FirstName,
            SortOrder.Ascending);

        string target =
            FindDuplicateFirstName(phonebook);

        int result =
            phonebook.BinarySearch(
                Field.FirstName,
                target);

        PrintResult(
            6,
            "FirstName",
            target,
            result,
            phonebook.ComparisonCount);

        if (result > 0)
        {
            Console.WriteLine(
                $"      Previous entry: " +
                $"{phonebook.GetContact(result - 1).FirstName}");
        }
    }

    private static void TestEmptyArray()
    {
        Phonebook phonebook =
            Phonebook.FromContacts(
                Array.Empty<Contact>());

        int result =
            phonebook.BinarySearch(
                Field.LastName,
                "Test");

        PrintResult(
            7,
            "LastName",
            "Test",
            result,
            phonebook.ComparisonCount);
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
            Phonebook.FromContacts(
                new[] { contact });

        int result =
            phonebook.BinarySearch(
                Field.LastName,
                "Person");

        PrintResult(
            8,
            "LastName",
            "Person",
            result,
            phonebook.ComparisonCount);
    }

    private static string FindDuplicateLastName(
        Phonebook phonebook)
    {
        for (int i = 2; i < phonebook.Count; i++)
        {
            string beforePrevious =
                phonebook.GetContact(i - 2).LastName;

            string previous =
                phonebook.GetContact(i - 1).LastName;

            string current =
                phonebook.GetContact(i).LastName;

            bool isDuplicate =
                string.Equals(
                    previous,
                    current,
                    StringComparison.OrdinalIgnoreCase);

            bool startsHere =
                !string.Equals(
                    beforePrevious,
                    current,
                    StringComparison.OrdinalIgnoreCase);

            if (isDuplicate && startsHere)
            {
                return current;
            }
        }

        throw new InvalidOperationException(
            "No suitable duplicate last name was found.");
    }

    private static string FindDuplicateFirstName(
        Phonebook phonebook)
    {
        for (int i = 2; i < phonebook.Count; i++)
        {
            string beforePrevious =
                phonebook.GetContact(i - 2).FirstName;

            string previous =
                phonebook.GetContact(i - 1).FirstName;

            string current =
                phonebook.GetContact(i).FirstName;

            bool isDuplicate =
                string.Equals(
                    previous,
                    current,
                    StringComparison.OrdinalIgnoreCase);

            bool startsHere =
                !string.Equals(
                    beforePrevious,
                    current,
                    StringComparison.OrdinalIgnoreCase);

            if (isDuplicate && startsHere)
            {
                return current;
            }
        }

        throw new InvalidOperationException(
            "No suitable duplicate first name was found.");
    }

    private static void PrintResult(
        int test,
        string field,
        string target,
        int result,
        long comparisons)
    {
        Console.WriteLine(
            "{0,-5} {1,-12} {2,-18} {3,10} {4,14}",
            test,
            field,
            target,
            result,
            comparisons);
    }
}