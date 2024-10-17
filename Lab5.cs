/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Lab5
*/

public abstract class Item
{
    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public Item()
    {
        title = string.Empty;
    }

    public Item(string title)
    {
        this.title = title;
    }

    public abstract string getListing();

    public override string ToString()
    {
        return title;
    }
}

public class Book : Item
{
    private string isbn_number;
    private string author;

    public string ISBNNumber
    {
        get { return isbn_number; }
        set { isbn_number = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public Book() : base()
    {
        isbn_number = string.Empty;
        author = string.Empty;
    }

    public Book(string title, string isbn_number, string author) : base(title)
    {
        this.isbn_number = isbn_number;
        this.author = author;
    }

    public override string getListing()
    {
        return $"Book Name - {Title}\nAuthor - {Author}\nISBN# - {ISBNNumber}";
    }
}

public class Periodicals : Item
{
    private string issueNum;

    public string IssueNum
    {
        get { return issueNum; }
        set { issueNum = value; }
    }

    public Periodicals() : base()
    {
        issueNum = string.Empty;
    }

    public Periodicals(string title, string issueNum) : base(title)
    {
        this.issueNum = issueNum;
    }

    public override string getListing()
    {
        return $"Periodical Title - {Title}\nIssue# - {IssueNum}";
    }
}

public class myCollection
{
    public static void Main(string[] args)
    {
        Item[] collection = new Item[5];

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Please enter B for Book or P for Periodical");
            string choice = Console.ReadLine().ToUpper();

            if (choice == "B")
            {
                Console.WriteLine("Please enter the name of the Book");
                string title = Console.ReadLine();

                Console.WriteLine("Please enter the author of the book:");
                string author = Console.ReadLine();

                Console.WriteLine("Please enter the ISBN of the Book");
                string isbn = Console.ReadLine();

                collection[i] = new Book(title, isbn, author);
            }
            else if (choice == "P")
            {
                Console.WriteLine("Please enter the name of the Periodical:");
                string title = Console.ReadLine();

                Console.WriteLine("Please enter the issue number:");
                string issueNum = Console.ReadLine();

                collection[i] = new Periodicals(title, issueNum);
            }
            else
            {
                Console.WriteLine("Invalid input.");
                i--;
            }
        }

        Console.WriteLine("\nYour items:");
        foreach (Item item in collection)
        {
            Console.WriteLine(item.getListing());
            Console.WriteLine();
        }
    }
}