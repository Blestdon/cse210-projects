using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What did you score in your grade percentage? ");
        string responce = Console.ReadLine();
        int percent = int.Parse(responce);

        string grade = " ";
        if (percent >= 90)
        {
            grade = "A";
        }
        else if (percent >= 80)
        {
            grade = "B";
        }
        else if (percent >= 70)
        {
            grade = "C";
        }
        else if (percent >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }



        Console.WriteLine($"Your grade is: {grade}");

        if (percent >= 70)
        {
            Console.WriteLine("You Passed");
        }
        else
        {
            Console.WriteLine("Do better next time!");
        }
        
    }
    
}