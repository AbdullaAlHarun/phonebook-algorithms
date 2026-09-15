using PhonebookAlgorithms.Services;
using PhonebookAlgorithms.Tests;

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

            LinearSearchTests.Run();
            SortingTests.Run();
            BinarySearchTests.Run();
            SearchComparisonTests.Run();

            Console.WriteLine("=================================");
            Console.WriteLine("All measurements completed.");
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
}