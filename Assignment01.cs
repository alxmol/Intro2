/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Assignment01
*/
using System;

public class Symbol
{
    public char symbol;
    public int uses;
    public double frequency;

    public Symbol(char symbol)
    {
        this.symbol = symbol;
        this.uses = 0;
        this.frequency = 0.0;
    }
}

class Assignment01
{
    static void Main(string[] args)
    {
        Symbol[] symbols = new Symbol[]
        {
            new Symbol('\u221E'),
            new Symbol('\u263A'),
            new Symbol('\u2640'),
            new Symbol('\u2642'),
            new Symbol('\u2660'), 
            new Symbol('\u2663'),
            new Symbol('\u2665'),
            new Symbol('\u2666'),
            new Symbol('\u266B')
        };

        bool True = true;
        Console.WriteLine("[Symbol Recommender]");
        while (True)
        {
            Console.WriteLine("Here are all available symbols");
            for (int i = 0; i < symbols.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {symbols[i].symbol}");
            }
            Console.WriteLine("0 - Exit");

            Console.Write("Please select a symbol to print: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine();

                if (choice == 0)
                {
                    True = false;
                    Console.WriteLine("Shutting off...");
                }
                else if (choice > 0 && choice <= symbols.Length)
                {
                    Symbol selectedSymbol = symbols[choice - 1];
                    selectedSymbol.uses++;
                    Console.WriteLine($"You selected the {selectedSymbol.symbol} symbol.");
                    updateFrequencies(symbols);
                    sortSymbols(symbols);
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }
            }
            else
            {
                Console.WriteLine("Invalid option!");
            }

            Console.WriteLine();
        }
    }

    static void updateFrequencies(Symbol[] symbols)
    {
        int totalUses = 0;
        foreach (Symbol s in symbols)
        {
            totalUses += s.uses;
        }

        foreach (Symbol s in symbols)
        {
            if (totalUses > 0)
            {
                s.frequency = (double)s.uses / totalUses;
            }
        }
    }

    static void sortSymbols(Symbol[] symbols)
    {
        for (int i = 0; i < symbols.Length - 1; i++)
        {
            for (int j = i + 1; j < symbols.Length; j++)
            {
                if (symbols[i].frequency < symbols[j].frequency ||
                    (symbols[i].frequency == symbols[j].frequency && symbols[i].symbol > symbols[j].symbol))
                {
                    Symbol temp = symbols[i];
                    symbols[i] = symbols[j];
                    symbols[j] = temp;
                }
            }
        }
    }
}
