/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Lab03
*/
using System;
using System.Collections.Generic;

public class Question
{
    private string question;
    private string answer;
    private int difficulty;

    public Question(string question, string answer, int difficulty)
    {
        this.question = question;
        this.answer = answer;
        this.difficulty = difficulty;
    }

    public string getQuestion()
    {
        return question;
    }

    public void setQuestion(string question)
    {
        this.question = question;
    }

    public string getAnswer()
    {
        return answer;
    }

    public void setAnswer(string answer)
    {
        this.answer = answer;
    }

    public int getDifficulty()
    {
        return difficulty;
    }

    public void setDifficulty(int difficulty)
    {
        if (difficulty >= 1 && difficulty <= 3)
        {
            this.difficulty = difficulty;
        }
        else
        {
            Console.WriteLine("Invalid difficulty level.");
        }
    }
}

public class Quiz
{
    private List<Question> questions;

    public Quiz()
    {
        questions = new List<Question>();
    }

    public void add_question()
    {
        Console.WriteLine("What is the question Text?");
        string question = Console.ReadLine();

        Console.WriteLine("What is the answer?");
        string answer = Console.ReadLine();

        Console.WriteLine("How Difficult (1-3)?");
        int difficulty;
        if (int.TryParse(Console.ReadLine(), out difficulty) && difficulty >= 1 && difficulty <= 3)
        {
            Question newQuestion = new Question(question, answer, difficulty);
            questions.Add(newQuestion);
        }
        else
        {
            Console.WriteLine("Invalid difficulty level.");
        }
        Console.WriteLine();
    }

    public void remove_question()
    {
        if (questions.Count == 0)
        {
            Console.WriteLine("No questions entered.");
            return;
        }

        Console.WriteLine("Choose the question to remove?");
        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {questions[i].getQuestion()}");
        }

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= questions.Count)
        {
            questions.RemoveAt(choice - 1);
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
        Console.WriteLine();
    }

    public void modify_question()
    {
        if (questions.Count == 0)
        {
            Console.WriteLine("No questions entered");
            return;
        }

        Console.WriteLine("Choose the question to modify?");
        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {questions[i].getQuestion()}");
        }

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= questions.Count)
        {
            Question selectedQuestion = questions[choice - 1];

            Console.WriteLine("What is the question Text?");
            selectedQuestion.setQuestion(Console.ReadLine());

            Console.WriteLine("What is the answer?");
            selectedQuestion.setAnswer(Console.ReadLine());

            Console.WriteLine("How Difficult (1-3)?");
            int newDifficulty;
            if (int.TryParse(Console.ReadLine(), out newDifficulty) && newDifficulty >= 1 && newDifficulty <= 3)
            {
                selectedQuestion.setDifficulty(newDifficulty);
            }
            else
            {
                Console.WriteLine("Invalid difficulty level.");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
        Console.WriteLine();
    }

    public void give_quiz()
    {
        if (questions.Count == 0)
        {
            Console.WriteLine("No questions entered");
            return;
        }

        int score = 0;
        foreach (Question question in questions)
        {
            Console.WriteLine(question.getQuestion());
            string userAnswer = Console.ReadLine();

            if (userAnswer.Equals(question.getAnswer(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"You got {score} out of {questions.Count}");
        Console.WriteLine();
    }
}

class Lab03
{
    static void Main(string[] args)
    {
        Quiz quiz = new Quiz();
        bool running = true;

        while (running)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add a question to the quiz");
            Console.WriteLine("2. Remove a question from the quiz");
            Console.WriteLine("3. Modify a question in the quiz");
            Console.WriteLine("4. Take the quiz");
            Console.WriteLine("5. Quit");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    quiz.add_question();
                    break;

                case "2":
                    quiz.remove_question();
                    break;

                case "3":
                    quiz.modify_question();
                    break;

                case "4":
                    quiz.give_quiz();
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Select a choice from 1 to 5.");
                    break;
            }
        }
    }
}

