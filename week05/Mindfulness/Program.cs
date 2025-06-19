// Exceeding Requirements:
// - Prevents repeating reflection questions within a session.
// - Shows total items listed in listing activity.
// - Animated breathing with countdowns.
// - Spinner during all waits.
// - Modular and extensible design using inheritance and encapsulation.

using System;

class Program
{
    static void Main(string[] args)
    {
 while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
        }
    }
}