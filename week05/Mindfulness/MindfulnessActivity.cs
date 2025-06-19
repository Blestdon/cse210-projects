using System;

public abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void Run()
    {
        DisplayStartMessage();
        PerformActivity();
        DisplayEndMessage();
    }

    protected virtual void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    protected virtual void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(2);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b");
            i = (i + 1) % spinner.Length;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }

    protected abstract void PerformActivity();
}