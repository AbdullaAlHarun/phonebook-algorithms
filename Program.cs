using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Phonebook phonebook = Phonebook.Load("phonebook.csv");

            Console.WriteLine("PHONEBOOK - SEARCHING AND SORTING");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.WriteLine(
                $"Loaded {phonebook.Count} contacts from phonebook.csv");
            Console.WriteLine();

            RunSortingMeasurements();
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

    private static void RunSortingMeasurements()
    {
        Console.WriteLine("--- Sorting Measurements ---");
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
        Phonebook phonebook =
            Phonebook.Load("phonebook.csv");

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
        Phonebook phonebook =
            Phonebook.Load("phonebook.csv");

        // Prepare already-sorted input.
        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Ascending);

        // Measure Insertion Sort only.
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
        Phonebook phonebook =
            Phonebook.Load("phonebook.csv");

        // Prepare reverse-sorted input.
        phonebook.MergeSort(
            Field.LastName,
            SortOrder.Descending);

        // Measure Insertion Sort only.
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
        Phonebook phonebook =
            Phonebook.Load("phonebook.csv");

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
        Phonebook phonebook =
            Phonebook.Load("phonebook.csv");

        // Prepare already-sorted input.
        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Ascending);

        // Measure Merge Sort only.
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
        Phonebook phonebook =
            Phonebook.Load("phonebook.csv");

        // Prepare reverse-sorted input.
        phonebook.InsertionSort(
            Field.LastName,
            SortOrder.Descending);

        // Measure Merge Sort only.
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