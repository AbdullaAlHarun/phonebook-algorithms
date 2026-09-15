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
            Phonebook phonebook = Phonebook.Load("phonebook.csv");

            Console.WriteLine("=== Phonebook Algorithms ===");
            Console.WriteLine($"Loaded {phonebook.Count} contacts.");
            Console.WriteLine();

            TestLinearSearch(
                phonebook,
                Field.FirstName,
                "Emma",
                "FirstName test");

            TestLinearSearch(
                phonebook,
                Field.LastName,
                "Hansen",
                "LastName test");

            TestLinearSearch(
                phonebook,
                Field.Mobile,
                "00000000",
                "Absent mobile test");

            TestLinearSearch(
                phonebook,
                Field.LastName,
                "ThisNameDoesNotExist",
                "Absent LastName test");
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

    private static void TestLinearSearch(
        Phonebook phonebook,
        Field field,
        string value,
        string testName)
    {
        Contact[] results = phonebook.LinearSearch(field, value);

        Console.WriteLine($"--- {testName} ---");
        Console.WriteLine($"Field: {field}");
        Console.WriteLine($"Search value: {value}");
        Console.WriteLine($"Matches: {results.Length}");

        foreach (Contact contact in results)
        {
            Console.WriteLine(
                $"{contact.FirstName} {contact.LastName} | " +
                $"{contact.Mobile} | {contact.Birthday} | " +
                $"{contact.Street} | {contact.City}");
        }

        Console.WriteLine();
    }
}