using System;
using System.Collections.Generic;

public class Entry
{
    public string Response { get; set; } = string.Empty;
}

public class Word
{
    public List<Entry> Entries { get; set; } = new List<Entry>();

    public void PrintHiddenWords()
    {
        foreach (Entry entry in Entries)
        {
            string hiddenResponse = MaskWords(entry?.Response);
            Console.WriteLine($"Response: {hiddenResponse}");
        }
    }

    public static string MaskWords(string? text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }

        string[] words = text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
            {
                words[i] = new string('_', words[i].Length);
            }
        }

        return string.Join(" ", words);
    }
}