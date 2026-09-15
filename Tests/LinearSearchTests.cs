using PhonebookAlgorithms.Enums;
using PhonebookAlgorithms.Models;
using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms.Tests;

public static class LinearSearchTests
{
    public static void Run()
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        string firstLastName =
            phonebook.GetContact(0).LastName;

        string lastLastName =
            phonebook.GetContact(phonebook.Count - 1).LastName;

        Console.WriteLine("--- 1. Linear Search ---");
        Console.WriteLine();

        Console.WriteLine(
            "{0,-12} {1,-18} {2,10} {3,14}",
            "Field",
            "Target",
            "Matches",
            "Comparisons");

        Console.WriteLine(new string('-', 58));

        MeasureLinear(Field.LastName, firstLastName);
        MeasureLinear(Field.LastName, lastLastName);
        MeasureLinear(Field.LastName, "Aardal");
        MeasureLinear(Field.Mobile, "00000000");

        Console.WriteLine();
    }

    private static void MeasureLinear(
        Field field,
        string target)
    {
        Phonebook phonebook = Phonebook.Load("phonebook.csv");

        Contact[] results =
            phonebook.LinearSearch(field, target);

        Console.WriteLine(
            "{0,-12} {1,-18} {2,10} {3,14}",
            field,
            target,
            results.Length,
            phonebook.ComparisonCount);
    }
}