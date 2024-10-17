/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Lab6
*/

public interface FindFib
{
    int calculate_fib(int x);
}

public class FibIteration : FindFib
{
    public int calculate_fib(int x)
    {
        if (x == 1 || x == 2)
        {
            return 1;
        }

        int prev1 = 1, prev2 = 1, result = 0;

        for (int i = 3; i <= x; i++)
        {
            result = prev1 + prev2;
            prev2 = prev1;
            prev1 = result;
        }

        return result;
    }
}

public class FibFormula : FindFib
{
    public int calculate_fib(int x)
    {
        double sqrt5 = Math.Sqrt(5);
        double func1 = (1 + sqrt5) / 2;
        double func2 = (1 - sqrt5) / 2;

        return (int)Math.Round((Math.Pow(func1, x) - Math.Pow(func2, x)) / sqrt5);
    }
}

class Lab6
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number you want to find the Fibonacci Series for: ");
        int n = int.Parse(Console.ReadLine());

        FindFib iterativeFib = new FibIteration();
        FindFib formulaFib = new FibFormula();

        int iterativeResult = iterativeFib.calculate_fib(n);
        int formulaResult = formulaFib.calculate_fib(n);

        Console.WriteLine($"Fib of {n} by iteration is: {iterativeResult}");
        Console.WriteLine($"Fib of {n} by formula is: {formulaResult}");
    }
}
