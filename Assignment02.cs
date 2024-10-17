/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Assignment02
*/
using System;
using System.Collections.Generic;

public class Bill
{
    private List <BillingItem> items;
    private static int nextId = 0;
    private int id;
    private static double taxPercentage = 0;

    public Bill()
    {
        items = new List<BillingItem>();
        id = nextId;
        nextId++;
    }

    public static void setTax(double tax)
    {
        if (tax >= 0)
        {
            taxPercentage = tax;
        }
        else
        {
            Console.WriteLine("Invalid tax percentage.");
        }
    }

    public static double getTaxPercentage()
    {
        return taxPercentage;
    }

    public void addItem(BillingItem item)
    {
        items.Add(item);
    }

    public void removeItem(BillingItem item)
    {
        items.Remove(item);
    }

    public BillingItem getItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            return items[index];
        }
        return null;
    }

    public string seeItems()
    {
        if (items.Count == 0)
        {
            return "";
        }

        string result = "";
        for (int i = 0; i < items.Count; i++)
        {
            BillingItem item = items[i];
            result += $"{i}. {item.getDescription()}: ${item.getAmount():F2}\n";
        }

        return result.TrimEnd();
    }

    public double calculateSubTotal()
    {
        double subTotal = 0;

        foreach (BillingItem item in items)
        {
            subTotal += item.getAmount();
        }

        return subTotal;
    }

    public double calculateTotal()
    {
        double subTotal = calculateSubTotal();
        return subTotal * (1 + taxPercentage / 100);
    }

    public override string ToString()
    {
        string result = $"# {id}\n";
        result += "\n";

        foreach (BillingItem item in items)
        {
            result += item.ToString() + "\n";
        }

        double subTotal = calculateSubTotal();
        double total = calculateTotal();

        result += $"\nSubtotal: ${subTotal:F2}\n";
        result += $"Total + Tax: ${total:F2}";

        return result;
    }
}

public class BillingItem
{
    private List<BillingSubItem> subitems;
    private double amount;
    private string description;

    public BillingItem()
    {
        subitems = new List<BillingSubItem>();
        amount = 0;
        description = "";
    }

    public BillingItem(double amount)
    {
        subitems = new List<BillingSubItem>();
        this.amount = amount;
        description = "";
    }

    public BillingItem(double amount, string description)
    {
        subitems = new List<BillingSubItem>();
        this.amount = amount;
        this.description = description;
    }

    public double getAmount()
    {
        if (subitems.Count == 0)
        {
            return amount;
        }

        double subItemTotal = 0;
        foreach (BillingSubItem subitem in subitems)
        {
            subItemTotal += subitem.getAmount();
        }

        return subItemTotal;
    }

    public void setAmount(double amount)
    {
        this.amount = amount;
    }

    public void addSubItem(BillingSubItem subitem)
    {
        subitems.Add(subitem);
    }

    public void removeSubItem(BillingSubItem subitem)
    {
        subitems.Remove(subitem);
    }

    public BillingSubItem getSubItem(int index)
    {
        if (index >= 0 && index < subitems.Count)
        {
            return subitems[index];
        }
        return null;
    }

    public string seeSubItems()
    {
        if (subitems.Count == 0)
        {
            return "";
        }

        string result = "";
        foreach (BillingSubItem subitem in subitems)
        {
            result += $"\t{subitem.ToString()}\n";
        }

        return result.TrimEnd();
    }

    public string getDescription()
    {
        return description;
    }

    public void setDescription(string description)
    {
        this.description = description;
    }

    public override string ToString()
    {
        if (subitems.Count == 0)
        {
            return $"{description}: ${amount:F2}";
        }
        else
        {
            return $"{description}\n{seeSubItems()}";
        }
    }
}

public class BillingSubItem
{
    private double amount;
    private string description;

    public BillingSubItem(double amount, string description)
    {
        this.amount = amount;
        this.description = description;
    }

    public double getAmount()
    {
        return amount;
    }

    public void setAmount(double amount)
    {
        this.amount = amount;
    }

    public string getDescription()
    {
        return description;
    }

    public void setDescription(string description)
    {
        this.description = description;
    }

    public override string ToString()
    {
        return $"{description}: ${amount:F2}";
    }
}

class Assignment02
{
    static void Main(string[] args)
    {
        bool running = true;
        Console.WriteLine("[Bill Generator]");
        while (running)
        {
            Bill bill = new Bill();

            bool billRunning = true;

            Console.WriteLine("New bill created.\n");
            while (billRunning)
            {
                Console.WriteLine("1. Add item");
                Console.WriteLine("2. Remove item");
                Console.WriteLine("3. Add subitem");
                Console.WriteLine("4. Remove subitem");
                Console.WriteLine("5. See tax");
                Console.WriteLine("6. Set tax");
                Console.WriteLine("7. Preview bill");
                Console.WriteLine("8. Finish");
                Console.Write("Select option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter the item's description: ");
                        string itemDesc = Console.ReadLine();
                        Console.Write("Enter the item's amount: ");
                        double itemAmount = Convert.ToDouble(Console.ReadLine());
                        bill.addItem(new BillingItem(itemAmount, itemDesc));
                        Console.WriteLine("Item added to bill.");
                        Console.WriteLine();
                        break;

                    case "2":
                        if (bill.seeItems() == "")
                        {
                            Console.WriteLine("There are no items to remove!");
                        }
                        else
                        {
                            Console.WriteLine("Items:\n" + bill.seeItems());
                            Console.Write("Select item to remove: ");
                            int removeItemIndex = Convert.ToInt32(Console.ReadLine());
                            BillingItem itemToRemove = bill.getItem(removeItemIndex);
                            if (itemToRemove != null)
                            {
                                bill.removeItem(itemToRemove);
                                Console.WriteLine("Item removed from bill.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid item to remove!");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        if (bill.seeItems() == "")
                        {
                            Console.WriteLine("There are no items to add subitems to!");
                        }
                        else
                        {
                            Console.WriteLine("Items:\n" + bill.seeItems());
                            Console.WriteLine();
                            Console.Write("Select an item: ");
                            int addSubItemIndex = Convert.ToInt32(Console.ReadLine());
                            BillingItem selectedItem = bill.getItem(addSubItemIndex);
                            if (selectedItem != null)
                            {
                                Console.Write("Enter subitem's description: ");
                                string subItemDesc = Console.ReadLine();
                                Console.Write("Enter subitem's amount: ");
                                double subItemAmount = Convert.ToDouble(Console.ReadLine());
                                selectedItem.addSubItem(new BillingSubItem(subItemAmount, subItemDesc));
                                Console.WriteLine("Subitem added to item.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid item number.");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "4":
                        if (bill.seeItems() == "")
                        {
                            Console.WriteLine("There are no items from which you can remove subitems!");
                        }
                        else
                        {
                            Console.WriteLine("Items:\n" + bill.seeItems());
                            Console.WriteLine();
                            Console.Write("Select an item: ");
                            int removeSubItemIndex = Convert.ToInt32(Console.ReadLine());
                            BillingItem itemWithSubItem = bill.getItem(removeSubItemIndex);
                            if (itemWithSubItem != null && itemWithSubItem.seeSubItems() != "")
                            {
                                Console.WriteLine("Subitems:\n" + itemWithSubItem.seeSubItems());
                                Console.WriteLine();
                                Console.Write("Select subitem to remove: ");
                                int subItemIndex = Convert.ToInt32(Console.ReadLine());
                                BillingSubItem subItemToRemove = itemWithSubItem.getSubItem(subItemIndex);
                                if (subItemToRemove != null)
                                {
                                    itemWithSubItem.removeSubItem(subItemToRemove);
                                    Console.WriteLine("Subitem removed from item.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid subitem to remove!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("That item has no subitems!");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "5":
                        Console.WriteLine($"Current tax is {BILL.getTaxPercentage():F2}%");
                        Console.WriteLine();
                        break;

                    case "6":
                        Console.Write("Enter new tax %: ");
                        double newTax = Convert.ToDouble(Console.ReadLine());
                        BILL.setTax(newTax);
                        Console.WriteLine("Tax set.");
                        Console.WriteLine();
                        break;

                    case "7":
                        Console.WriteLine("The current contents of the bill are:");
                        Console.WriteLine("\n====================");
                        Console.WriteLine(bill.ToString());
                        Console.WriteLine("====================\n");
                        break;

                    case "8":
                        Console.WriteLine("\n====================");
                        Console.WriteLine(bill.ToString());
                        Console.WriteLine("====================\n");
                        Console.Write("Would you like to create a new bill? (say \"no\" to terminate) ");
                        string generateAnother = Console.ReadLine().ToLower();
                        if (generateAnother == "no")
                        {
                            billRunning = false;
                            running = false;
                        }
                        else
                        {
                            billRunning = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Please select a valid option.");
                        Console.WriteLine();
                        break;
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("Shutting off...");
    }
}