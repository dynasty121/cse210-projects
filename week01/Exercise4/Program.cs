using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
                break; // Stop when user enters 0

            numbers.Add(number);
        }

        // Check if the list has numbers before performing calculations
        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = numbers.Average();
            int maxNumber = numbers.Max();

            Console.WriteLine($"\nThe sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {maxNumber}");

            // Stretch Challenge: Find the smallest positive number
            int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min();
            if (smallestPositive != int.MaxValue)
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");

            // Stretch Challenge: Sort and display the sorted list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
