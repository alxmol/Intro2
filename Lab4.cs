/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Lab4
*/

using System;

public class Account
{
    private static int NextAccount_Number = 10001;
    private int account_number;
    private decimal accountBalance;

    public Account()
    {
        account_number = NextAccount_Number++;
        accountBalance = 0;
    }

    public Account(decimal initialBalance)
    {
        account_number = NextAccount_Number++;
        accountBalance = initialBalance;
    }

    public int Account_Number()
    {
        return account_number;
    }

    public decimal getBalance()
    {
        return accountBalance;
    }

    public void setBalance(decimal amount)
    {
        accountBalance = amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        accountBalance -= amount;
    }

    public virtual void Deposit(decimal amount)
    {
        accountBalance += amount;
    }
}

public class Checking : Account
{
    public Checking(decimal initialBalance) : base(initialBalance) { }

    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount);
        if (getBalance() < 0)
        {
            Console.WriteLine("Charging an overdraft fee of $20 because account is below $0.");
            setBalance(getBalance() - 20);
        }
    }
}

public class Savings : Account
{
    private int depositCount = 0;

    public Savings(decimal initialBalance) : base(initialBalance) { }

    public override void Withdraw(decimal amount)
    {
        if (getBalance() - amount < 500)
        {
            Console.WriteLine("Charging a fee of $10 because you are below $500.");
            setBalance(getBalance() - 10);
        }
        base.Withdraw(amount);
    }

    public override void Deposit(decimal amount)
    {
        depositCount++;
        Console.WriteLine($"This is deposit number {depositCount} to this account.");
        if (depositCount > 5)
        {
            Console.WriteLine($"Charging a fee of $10.");
            amount -= 10;
        }
        base.Deposit(amount);
    }

    public void ApplyInterest()
    {
        decimal interest = getBalance() * 0.015M;
        Console.WriteLine($"Customer earned {interest:C} in interest.");
        setBalance(getBalance() + interest);
    }
}


public class Lab4
{
    public static void Main(string[] args)
    {
        Checking checkingAccount = new Checking(0);
        Savings savingsAccount = new Savings(0);

        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Withdraw from Checking");
            Console.WriteLine("2. Withdraw from Savings");
            Console.WriteLine("3. Deposit to Checking");
            Console.WriteLine("4. Deposit to Savings");
            Console.WriteLine("5. Balance of Checking");
            Console.WriteLine("6. Balance of Savings");
            Console.WriteLine("7. Award Interest to Savings now");
            Console.WriteLine("8. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("How much would you like to withdraw from Checking?");
                    decimal withdrawChecking = decimal.Parse(Console.ReadLine());
                    checkingAccount.Withdraw(withdrawChecking);
                    break;

                case "2":
                    Console.WriteLine("How much would you like to withdraw from Savings?");
                    decimal withdrawSavings = decimal.Parse(Console.ReadLine());
                    savingsAccount.Withdraw(withdrawSavings);
                    break;

                case "3":
                    Console.WriteLine("How much would you like to deposit into Checking?");
                    decimal depositChecking = decimal.Parse(Console.ReadLine());
                    checkingAccount.Deposit(depositChecking);
                    Console.WriteLine("Doing default deposit");
                    break;

                case "4":
                    Console.WriteLine("How much would you like to deposit into Savings?");
                    decimal depositSavings = decimal.Parse(Console.ReadLine());
                    savingsAccount.Deposit(depositSavings);
                    break;

                case "5":
                    Console.WriteLine($"Your balance for checking 10001 is {checkingAccount.getBalance():C}");
                    break;

                case "6":
                    Console.WriteLine($"Your balance for savings 10002 is {savingsAccount.getBalance():C}");
                    break;

                case "7":
                    savingsAccount.ApplyInterest();
                    break;

                case "8":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Please choose between options 1-8.");
                    break;
            }
        }
    }
}
