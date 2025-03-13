using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your first name?  ");
        string firstName = Console.ReadLine();

        Console.Write("what is your last name?  ");
        string lastName = Console.ReadLine();

        // print the formatted out put 
        Console.Write($"{lastName}, {firstName} {lastName}");
    }
}