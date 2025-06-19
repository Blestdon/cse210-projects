using System;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What did you learn from this?",
        "How can you use this experience in the future?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random rand = new();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\n--- Prompt ---\n{prompt}\n");
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        var used = new HashSet<int>();

        while (DateTime.Now < end)
        {
            int index;
            do { index = rand.Next(_questions.Count); } while (used.Contains(index));
            used.Add(index);

            Console.WriteLine($"> {_questions[index]}");
            ShowSpinner(5);
            Console.WriteLine();

            if (used.Count == _questions.Count) used.Clear(); // Reset if all used
        }
    }
}
