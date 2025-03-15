using System;

class Program
{
    static void Main()
    {
        // Ask the user for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess = -1; // Initialize guess variable

        // Loop until the user guesses correctly
        while (guess != magicNumber)
        {
            // Ask the user for a guess
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Provide feedback to the user
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
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
