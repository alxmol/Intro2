/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Lab7B
*/

using System;

class Lab7B
{
    static void Main(string[] args)
    {
        string repeatedString = repeatNTimes("I must study recursion until it makes sense\n", 100);
        Console.WriteLine(repeatedString);

        Console.WriteLine("Enter the first string");
        string string1 = Console.ReadLine();

        Console.WriteLine("Enter the second string");
        string string2 = Console.ReadLine();

        if (isReverse(string1, string2))
        {
            Console.WriteLine($"{string1} is the reverse of {string2}");
        }
        else
        {
            Console.WriteLine($"{string1} is not the reverse of {string2}");
        }
    }

    public static string repeatNTimes(string recursionString, int count)
    {
        if (count == 0)
        {
            return "";
        }
        return recursionString + repeatNTimes(recursionString, count - 1);
    }

    public static bool isReverse(string string1, string string2)
    {
        if (string1.Length == 0 && string2.Length == 0)
        {
            return true;
        }
        if (string1.Length != string2.Length)
        {
            return false;
        }
        if (string1[0] != string2[string2.Length - 1])
        {
            return false;
        }
        return isReverse(string1.Substring(1), string2.Substring(0, string2.Length - 1));
    }
}