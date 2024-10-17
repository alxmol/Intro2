/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Lab7A
*/
using System;

class Lab7A
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose from the following:");
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Multiply 2 numbers");
            Console.WriteLine("2. Div 2 numbers");
            Console.WriteLine("3. Mod 2 numbers");

            string choice = Console.ReadLine();
            int a, b;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter first number");
                    a = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter second number");
                    b = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Answer: {recursive_multiply(a, b)}");
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("Enter first number");
                    a = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter second number");
                    b = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Answer: {recursive_div(a, b)}");
                    Console.WriteLine();
                    break;

                case "3":
                    Console.WriteLine("Enter first number");
                    a = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter second number");
                    b = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Answer: {recursive_mod(a, b)}");
                    Console.WriteLine();
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    public static int recursive_multiply(int a, int b)
    {
        if (b == 0)
        {
            return 0;
        }
        return a + recursive_multiply(a, b - 1);
    }

    public static int recursive_div(int a, int b)
    {
        if (b == 0)
        {
            return -1;
        }
        if (a == b)
        {
            return 1;
        }
        if (a < b)
        {
            return 0;
        }
        return 1 + recursive_div(a - b, b);
    }

    public static int recursive_mod(int a, int b)
    {
        if (b == 0)
        {
            return -1;
        }
        if (a < b)
        {
            return a;
        }
        return recursive_mod(a - b, b);
    }
}