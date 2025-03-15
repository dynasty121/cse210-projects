using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();

        // Try to convert the input to an integer
        if (int.TryParse(input, out int grade))
        {
            string letterGrade;

            // Determine the letter grade
            if (grade >= 90)
            {
                letterGrade = "A";
            }
            else if (grade >= 80)
            {
                letterGrade = "B";
            }
            else if (grade >= 70)
            {
                letterGrade = "C";
            }
            else if (grade >= 60)
            {
                letterGrade = "D";
            }
            else
            {
                letterGrade = "F";
            }

            // Print the final letter grade
            Console.WriteLine($"\nYour letter grade is: {letterGrade}");

            // Determine if the student passed
            if (grade >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course. 🎉");
            }
            else
            {
                Console.WriteLine("Don't worry! Keep working hard and you'll pass next time. 💪");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid input! Please enter a valid number.");
        }

        // Keep the console open until the user presses Enter
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}
