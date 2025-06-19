using System;

class Program
{
    static void Main(string[] args)
    {
    // Create a list of activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),         // 3 miles in 30 mins
            new Cycling(new DateTime(2022, 11, 3), 45, 15.0),        // 15 mph for 45 mins
            new Swimming(new DateTime(2022, 11, 3), 40, 40)          // 40 laps
        };

        // Print summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}