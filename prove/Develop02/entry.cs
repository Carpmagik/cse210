using System;

public class Entry
{
    public string Date; 
    public string Prompt;
    public string Response;

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }
}