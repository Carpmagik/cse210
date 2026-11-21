using System;
using System.Collections.Generic;

class Program
{

    /// this program will display a scripture and then hide some of the words in the scripture until the user has guessed all of the words
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter to continue or type 'quit' to finish: ");
        Console.ReadLine();
        string scripture = "For I know the plans I have for you, declares the Lord, plans to prosper you and not to harm you, plans to give you hope and a future.";
        string[] words = scripture.Split(' ');
        List<string> hiddenWords = new List<string>();

        foreach (string word in words)
        {
            hiddenWords.Add(word);
        }

        while (hiddenWords.Count > 0)
        {
            Console.WriteLine("Current scripture:");
            foreach (string word in words)
            {
                if (hiddenWords.Contains(word))
                {
                    Console.Write("_ ");
                }
                else
                {
                    Console.Write(word + " ");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Enter a word to guess:");
            string guess = Console.ReadLine();

            if (hiddenWords.Contains(guess))
            {
                hiddenWords.Remove(guess);
            }
            else
            {
                Console.WriteLine("Incorrect guess. Try again.");
            }
        }

        Console.WriteLine("Congratulations! You have guessed all the words.");

    }
}