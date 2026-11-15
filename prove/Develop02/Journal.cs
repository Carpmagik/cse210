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

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.Date} - {entry.Prompt}: {entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
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

                if (parts.Length == 3)
                {
                    Entry entry = new Entry();
                    entry.Date = parts[0];
                    entry.Prompt = parts[1];
                    entry.Response = parts[2];

                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully!\n");
        }

        }
    }