using System;
using System.Collections.Generic;


/// Extra effort was the delete file option

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string[] prompts =
        {
            "What was the best part of the day?",
            "Did I do anything new?",
            "Do I think there was anything I could have done better?",
            "What was the funniest thing that happened?",
            "Did I talk to any new people?",
            "Did I get out of my comfort zone?",
            "What am I grateful for today?"
        };
        
        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];
        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string choiceInput = Console.ReadLine();
            int options = int.Parse(choiceInput);
            Console.WriteLine();


            /// A groupmate used case/switch statements , and I found out that 
            /// the maihn difference between them is that switch 
            /// statements are more efficient when it checks the same variable, while
            /// if statements better check unrelated variables.

            if (options == 1) 
            {
                string prompt = prompts[random.Next(prompts.Length)];
                Console.WriteLine(prompt);
                string response = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._prompt = prompt;
                newEntry._response = response;

                journal.AddEntry(newEntry);
            }
            else if (options == 2)
            {
                journal.DisplayAll();
            }
            else if (options == 3)
            {
                Console.Write("Enter filename: ");
                string loadFile = Console.ReadLine();
                journal.LoadFromFile(loadFile);
            }
            else if (options == 4)
            {
                Console.Write("What is the filename you want to save? ");
                string saveFilename = Console.ReadLine();
                journal.SaveToFile(saveFilename);
            }
            else if (options == 5)
            {
                Console.Write("Enter filename to delete: ");
                string deleteFile = Console.ReadLine();
                journal.DeleteFile(deleteFile);
            }
            else if (options == 6)
            {
                break;
            }
        }
    }
    }
