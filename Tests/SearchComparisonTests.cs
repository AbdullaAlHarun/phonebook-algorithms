using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms.Tests;

public static class SearchComparisonTests
{
    public static void Run()
    {
        Phonebook original =
            Phonebook.Load("phonebook.csv");

        string first =
            original.GetContact(0).LastName;

        string middle =
            original.GetContact(original.Count / 2).LastName;

        string last =
            original.GetContact(original.Count - 1).LastName;

        const string absent = "Aardal";

        Console.WriteLine(
            "--- 4. Linear vs Binary Search ---");

        Console.WriteLine("Field: LastName");
        Console.WriteLine();

        Console.WriteLine(
            "{0,-18} {1,-18} {2,12} {3,12}",
            "Position",
            "Target",
            "Linear",
            "Binary");

        Console.WriteLine(new string('-', 64));

        CompareSearches("First record", first);
        CompareSearches("Middle record", middle);
        CompareSearches("Last record", last);
        CompareSearches("Absent", absent);

        Console.WriteLine();
    }

    private static void CompareSearches(
        string position,
        string target)
    {
        Phonebook linearPhonebook =
            Phonebook.Load("phonebook.csv");

        linearPhonebook.LinearSearch(
            Field.LastName,
            target);

        long linearComparisons =
            linearPhonebook.ComparisonCount;

        Phonebook binaryPhonebook =
            Phonebook.Load("phonebook.csv");

        binaryPhonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        binaryPhonebook.BinarySearch(
            Field.LastName,
            target);

        long binaryComparisons =
            binaryPhonebook.ComparisonCount;

        Console.WriteLine(
            "{0,-18} {1,-18} {2,12} {3,12}",
            position,
            target,
            linearComparisons,
            binaryComparisons);
    }
}