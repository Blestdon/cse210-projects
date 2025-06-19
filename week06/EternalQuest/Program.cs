// Eternal Quest Goal Tracker
// Exceeding Requirements:
// - Added leveling system (gain a level every 1000 points)
// - Bonus effects for completing checklist goals
// - Clean file I/O
// - Modular and extensible design

using System;
using System.IO;

class Program
{
    static int totalScore = 0;
    static int level = 1;
    static List<Goal> goals = new List<Goal>();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            ShowLevel();
            Console.WriteLine("Eternal Quest - Main Menu");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid input."); break;
            }

            if (running)
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    static void ShowLevel()
    {
        int newLevel = (totalScore / 1000) + 1;
        if (newLevel > level)
        {
            level = newLevel;
            Console.WriteLine($"🎉 Congrats! You've leveled up to Level {level}!");
        }
        Console.WriteLine($"Score: {totalScore} | Level: {level}");
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nChoose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Option: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for completion: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times to complete this goal? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points when completed: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int i = 1;
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"{i++}. {goal.Display()}");
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Enter number of goal to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent();
            totalScore += earned;
            Console.WriteLine($"You earned {earned} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal.");
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalScore);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.SaveData());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            totalScore = int.Parse(lines[0]);
            goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                Goal loaded = Goal.LoadFromString(lines[i]);
                if (loaded != null)
                    goals.Add(loaded);
            }

            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
