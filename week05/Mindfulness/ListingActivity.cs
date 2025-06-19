using System;

public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped recently?",
        "What are things you’re grateful for?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by prompting you to list as many items as you can.";
    }

    protected override void PerformActivity()
    {
        Random rand = new();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\n--- Prompt ---\n{prompt}");
        Console.WriteLine("You may begin in:");
        Countdown(5);

        List<string> items = new();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
    }
}
