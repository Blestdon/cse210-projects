using System;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.";
    }

    protected override void PerformActivity()
    {
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("Breathe in...");
            Countdown(4);
            Console.Write("Breathe out...");
            Countdown(6);
            elapsed += 10;
        }
    }
}
