/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Lab02
*/
using System;

public class StockItem
{
    private static int nextId = 0;
    public int Id { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public StockItem()
    {
        Description = "Item";
        Id = nextId++;
        Price = 0.0m;
        Quantity = 0;
    }

    public StockItem(string description, decimal price, int quantity)
    {
        Description = description;
        Id = nextId++;
        Price = price;
        Quantity = quantity;
    }

    public string getDescription()
    {
        return Description;
    }

    public int getId()
    {
        return Id;
    }

    public decimal getPrice()
    {
        return Price;
    }

    public int getQuantity()
    {
        return Quantity;
    }

    public void setPrice(decimal newPrice)
    {
        if (newPrice < 0)
        {
            Console.WriteLine("Error: Negative price");
        }
        else
        {
            Price = newPrice;
        }
    }

    public void lowerQuant(int amount)
    {
        if (Quantity - amount < 0)
        {
            Console.WriteLine("Error: Negative stock");
        }
        else
        {
            Quantity -= amount;
        }
    }

    public void raiseQuant(int amount)
    {
        Quantity += amount;
    }

    public override string ToString()
    {
        return $"Item number: {Id} is {Description} has price {Price} we currently have {Quantity} in stock";
    }
}

class Lab02
{
    static void Main(string[] args)
    {
        StockItem milk = new StockItem("1 Gallon of Milk", 3.60m, 15);
        StockItem bread = new StockItem("1 Loaf of Bread", 1.98m, 30);

        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Sold One Milk");
            Console.WriteLine("2. Sold One Bread");
            Console.WriteLine("3. Change price of Milk");
            Console.WriteLine("4. Change price of Bread");
            Console.WriteLine("5. Add Milk to Inventory");
            Console.WriteLine("6. Add Bread to Inventory");
            Console.WriteLine("7. See Inventory");
            Console.WriteLine("8. Quit");
            Console.WriteLine();

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    milk.lowerQuant(1);
                    break;

                case "2":
                    bread.lowerQuant(1);
                    break;

                case "3":
                    Console.WriteLine("What is the new price for Milk? ");
                    decimal newMilkPrice;
                    if (decimal.TryParse(Console.ReadLine(), out newMilkPrice))
                    {
                        milk.setPrice(newMilkPrice);
                    }
                    else
                    {
                        Console.WriteLine("Invalid price entered.");
                    }
                    break;

                case "4":
                    Console.WriteLine("What is the new price for Bread? ");
                    decimal newBreadPrice;
                    if (decimal.TryParse(Console.ReadLine(), out newBreadPrice))
                    {
                        bread.setPrice(newBreadPrice);
                    }
                    else
                    {
                        Console.WriteLine("Invalid price entered.");
                    }
                    break;

                case "5":
                    Console.WriteLine("How many Milk did we get? ");
                    int milkToAdd;
                    if (int.TryParse(Console.ReadLine(), out milkToAdd))
                    {
                        milk.raiseQuant(milkToAdd);
                    }
                    else
                    {
                        Console.WriteLine("try again.");
                    }
                    break;

                case "6":
                    Console.WriteLine("How many Bread did we get? ");
                    int breadToAdd;
                    if (int.TryParse(Console.ReadLine(), out breadToAdd))
                    {
                        bread.raiseQuant(breadToAdd);
                    }
                    else
                    {
                        Console.WriteLine("try again.");
                    }
                    break;

                case "7":
                    Console.WriteLine($"Milk: {milk}");
                    Console.WriteLine($"Bread: {bread}");
                    Console.WriteLine();
                    break;

                case "8":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Enter a number between 1 and 8");
                    break;
            }
            Console.WriteLine();
        }
    }
}

