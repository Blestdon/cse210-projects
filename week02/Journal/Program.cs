using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        string userChoice;

        do
        {
            Console.WriteLine("\n📘 JOURNAL MENU:");
            Console.WriteLine("1️⃣ Write a new entry");
            Console.WriteLine("2️⃣ Display journal");
            Console.WriteLine("3️⃣ Save journal to file");
            Console.WriteLine("4️⃣ Load journal from file");
            Console.WriteLine("5️⃣ Exit");

            Console.Write("Choose an option: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"📝 Prompt: {prompt}");
                    Console.Write("✍️ Your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(new Entry(prompt, response));
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("💾 Enter file name to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("📂 Enter file name to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    Console.WriteLine("👋 Goodbye!");
                    break;
                default:
                    Console.WriteLine("❌ Invalid option! Try again.");
                    break;
            }
        } while (userChoice != "5");
    }
}
