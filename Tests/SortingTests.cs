using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms.Tests;

public static class SortingTests
{
    public static void Run()
    {
        Console.WriteLine("--- 2. Sorting Measurements ---");
        Console.WriteLine("Field: LastName | Order: Ascending");
        Console.WriteLine();

        Console.WriteLine(
            "{0,-12} {1,-18} {2,14} {3,12}",
            "Algorithm",
            "Input Shape",
            "Comparisons",
            "Moves");

        Console.WriteLine(new string('-', 60));

        MeasureInsertionAsSupplied();
        MeasureInsertionSorted();
        MeasureInsertionReverse();

        MeasureMergeAsSupplied();
        MeasureMergeSorted();
        MeasureMergeReverse();

        Console.WriteLine();
    }

    private static void MeasureInsertionAsSupplied()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Ascending);

        PrintMeasurement(
            "Insertion",
            "As supplied",
            phonebook.ComparisonCount,
            phonebook.MoveCount);
    }

    private static void MeasureInsertionSorted()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        // Prepare already-sorted input.
        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        // This is the measured run.
        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Ascending);

        PrintMeasurement(
            "Insertion",
            "Already sorted",
            phonebook.ComparisonCount,
            phonebook.MoveCount);
    }

    private static void MeasureInsertionReverse()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        // Prepare reverse-sorted input.
        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Descending);

        // This is the measured run.
        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Ascending);

        PrintMeasurement(
            "Insertion",
            "Reverse sorted",
            phonebook.ComparisonCount,
            phonebook.MoveCount);
    }

    private static void MeasureMergeAsSupplied()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        PrintMeasurement(
            "Merge",
            "As supplied",
            phonebook.ComparisonCount,
            phonebook.MoveCount);
    }

    private static void MeasureMergeSorted()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        // Prepare already-sorted input.
        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Ascending);

        // This is the measured run.
        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        PrintMeasurement(
            "Merge",
            "Already sorted",
            phonebook.ComparisonCount,
            phonebook.MoveCount);
    }

    private static void MeasureMergeReverse()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        // Prepare reverse-sorted input.
        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Descending);

        // This is the measured run.
        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        PrintMeasurement(
            "Merge",
            "Reverse sorted",
            phonebook.ComparisonCount,
            phonebook.MoveCount);
    }

    private static void PrintMeasurement(
        string algorithm,
        string inputShape,
        long comparisons,
        long moves)
    {
        Console.WriteLine(
            "{0,-12} {1,-18} {2,14} {3,12}",
            algorithm,
            inputShape,
            comparisons,
            moves);
    }
}