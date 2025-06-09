using System;

// EXCEEDS REQUIREMENTS:
// - Loads scriptures from a file called "scriptures.txt"
// - Randomly selects one to display
// - Only hides words that are still visible
// - Clean object-oriented design using encapsulation

class Program
{
    static void Main(string[] args)
    {
 List<Scripture> scriptures = LoadScriptures("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found. Please check your file.");
            return;
        }

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
                return;

            scripture.HideRandomWords(3); // You can change this number
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Press Enter to exit.");
        Console.ReadLine();
    }

    static List<Scripture> LoadScriptures(string filePath)
    {
        var scriptures = new List<Scripture>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return scriptures;
        }

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split('|');
            if (parts.Length != 2) continue;

            Reference reference = Reference.Parse(parts[0]);
            string text = parts[1].Trim();
            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
            }
}