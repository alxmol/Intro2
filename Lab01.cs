﻿/*
Class: CSE 1322L
Section: W#1
Term: Fall 2024
Instructor: Manosmi Gundu
Name: Alex Molina
Lab#: Lab01
*/
using System;

class Lab01
{

    public static char[,] make_forward()
    {
        char[,] pixel = new char[4, 13];
        pixel[0, 0] = ' ';
        pixel[0, 1] = ' ';
        pixel[0, 2] = '_';
        pixel[0, 3] = '_';
        pixel[0, 4] = '_';
        pixel[0, 5] = '_';
        pixel[0, 6] = '_';
        pixel[0, 7] = '_';
        pixel[0, 8] = ' ';
        pixel[0, 9] = ' ';
        pixel[0, 10] = ' ';
        pixel[0, 11] = ' ';
        pixel[0, 12] = ' ';
        pixel[1, 0] = ' ';
        pixel[1, 1] = '/';
        pixel[1, 2] = '|';
        pixel[1, 3] = '_';
        pixel[1, 4] = '|';
        pixel[1, 5] = '|';
        pixel[1, 6] = '_';
        pixel[1, 7] = '\\';
        pixel[1, 8] = '\'';
        pixel[1, 9] = '.';
        pixel[1, 10] = '_';
        pixel[1, 11] = '_';
        pixel[1, 12] = ' ';
        pixel[2, 0] = '(';
        pixel[2, 1] = ' ';
        pixel[2, 2] = ' ';
        pixel[2, 3] = ' ';
        pixel[2, 4] = '_';
        pixel[2, 5] = ' ';
        pixel[2, 6] = ' ';
        pixel[2, 7] = ' ';
        pixel[2, 8] = ' ';
        pixel[2, 9] = '_';
        pixel[2, 10] = ' ';
        pixel[2, 11] = '_';
        pixel[2, 12] = '\\';
        pixel[3, 0] = '=';
        pixel[3, 1] = '\'';
        pixel[3, 2] = '-';
        pixel[3, 3] = '(';
        pixel[3, 4] = '_';
        pixel[3, 5] = ')';
        pixel[3, 6] = '-';
        pixel[3, 7] = '-';
        pixel[3, 8] = '(';
        pixel[3, 9] = '_';
        pixel[3, 10] = ')';
        pixel[3, 11] = '-';
        pixel[3, 12] = '\'';
        return pixel;
    }

    static void Main(string[] args)
    {

        char[,] forward = make_forward();
        printArray(forward);
        Console.WriteLine();

        char[,] mirrored = make_mirror(forward);
        printArray(mirrored);
        Console.WriteLine();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                Console.Write(forward[i, j]);
            }

            for (int j = 0; j < 13; j++)
            {
                Console.Write(mirrored[i, j]);
            }

            Console.WriteLine();
        }
    }

    public static char[,] make_mirror(char[,] original)
    {
        char[,] mirrored = new char[4, 13];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                char currentChar = original[i, 12 - j];

                if (currentChar == '(')
                {
                    mirrored[i, j] = ')';
                }
                else if (currentChar == ')')
                {
                    mirrored[i, j] = '(';
                }
                else if (currentChar == '/')
                {
                    mirrored[i, j] = '\\';
                }
                else if (currentChar == '\\')
                {
                    mirrored[i, j] = '/';
                }
                else
                {
                    mirrored[i, j] = currentChar;
                }
            }
        }

        return mirrored;
    }

    static void printArray(char[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j]);
            }
            Console.WriteLine();
        }
    }
}