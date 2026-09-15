using PhonebookAlgorithms.Services;

namespace PhonebookAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Phonebook phonebook = Phonebook.Load("phonebook.csv");

            Console.WriteLine($"Loaded {phonebook.Count} contacts from phonebook.csv");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Data error: {ex.Message}");
        }
    }
}