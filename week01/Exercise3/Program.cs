using System;

class Program
{
    static void Main(string[] args)
    {
        // where the user picks the number...
        // Console.Write("guess the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());

        // Using a random number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(20, 107);

        int guess = 11;

        //using do_while loop
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}