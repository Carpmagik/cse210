using System;
using System.IO;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { " - ", ": " }, StringSplitOptions.None);

            /// I learned that stringSplitOptions.None is used to keep everything, even if
            /// there are empty. 

                if (parts.Length == 3)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._prompt = parts[1];
                    entry._response = parts[2];

                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully!\n");
        }

        }
        
    /// saves to file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date} - {entry._prompt}: {entry._response}");
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }


    /// deletes the file
    public void DeleteFile(string filename)
    {
        if (File.Exists(filename))
        {
            File.Delete(filename);
            Console.WriteLine($"File '{filename}' deleted successfully.");
        }
    }
}