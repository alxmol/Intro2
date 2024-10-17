/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#:Assignment5
*/

class Assignment5
{
    public static int lengthOfMatch(string s1, string s2)
    {
        if (s1.Length == 0 || s2.Length == 0)
            return 0;

        if (s1[s1.Length - 1] == s2[s2.Length - 1])
            return 1 + lengthOfMatch(s1.Substring(0, s1.Length - 1), s2.Substring(0, s2.Length - 1));

        return 0;
    }

    public static int calculateSkip(char c, string pattern)
    {
        if (pattern.Length == 0) return 0;
        return calculateSkipPt2(c, pattern, pattern.Length - 1);
    }

    private static int calculateSkipPt2(char c, string pattern, int index)
    {
        if (index < 0) return pattern.Length;

        if (pattern[index] == c) return pattern.Length - 1 - index;

        return calculateSkipPt2(c, pattern, index - 1);
    }

    public static int findString(string text, string pattern)
    {
        if (pattern.Length == 0) return 0;
        if (text.Length < pattern.Length) return -1;

        int textIndex = pattern.Length - 1;

        while (textIndex < text.Length)
        {
            int patternIndex = pattern.Length - 1;
            int textPointer = textIndex;

            while (patternIndex >= 0 && text[textPointer] == pattern[patternIndex])
            {
                textPointer--;
                patternIndex--;
            }

            if (patternIndex < 0)
                return textPointer + 1;

            textIndex += Math.Max(1, calculateSkip(text[textIndex], pattern));
        }

        return -1;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("[Pattern Matcher]");
        Console.Write("Enter original text: ");
        string text = Console.ReadLine();

        Console.Write("Enter pattern to find: ");
        string pattern = Console.ReadLine();

        int position = findString(text, pattern);

        if (position != -1)
        {
            Console.WriteLine($"Pattern found at position {position}");
        }
        else
        {
            Console.WriteLine("Pattern could not be found in text!");
        }
    }
}