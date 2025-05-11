using System;

class Program
{
    static void Main(string[] args)
    {
        {
            WelcomeMessage();

            string userName = PromptName();
            int userNumber = PromptNumber();

            int squaredNumber = SquareNumber(userNumber);

            DisplayResult(userName, squaredNumber);
        }

        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptName()
        {
            Console.Write("Please what is your name?: ");
            string name = Console.ReadLine();

            return name;
        }

        static int PromptNumber()
        {
            Console.Write("Please what is your favourite number?: ");
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        static int SquareNumber(int number)
        {
            int square = number * number;
            return square;
        }

        static void DisplayResult(string name, int square)
        {
            Console.WriteLine($"{name}, the square of your number is {square}");
        }
    }
}