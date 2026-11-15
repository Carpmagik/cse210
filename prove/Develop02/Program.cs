using System;
using System.Collections.Generic;

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
        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save"); 
            Console.WriteLine("5. Quit");                         
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    
                    string prompt = prompts[random.Next(prompts.Length)];
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    
                    //write
                    Entry newEntry = new Entry(); 
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._prompt = prompt;
                    newEntry._response = response;

                    journal.AddEntry(newEntry);
                    break;

                
                case "2": 
                    //display
                    journal.DisplayAll();
                    break;

                case "3":
                    //load
                    Console.Write("Enter filename: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;


                case "4":
                    //save
                    Console.Write("What is the filename you want to save? ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "5":
                    //quit
                    running = false;
                    break;
            }
        }
    }
}