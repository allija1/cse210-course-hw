using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response}";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        entries.Add(new Entry(prompt, response));
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
            return;
        }
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public List<Entry> GetEntries()
    {
        return entries;
    }

    public void ClearEntries()
    {
        entries.Clear();
    }
}

static class FileHandler
{
    private const string Separator = " ~|~ ";

    public static void SaveToFile(string filename, List<Entry> entries)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}{Separator}{entry.Prompt}{Separator}{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public static List<Entry> LoadFromFile(string filename)
    {
        List<Entry> entries = new List<Entry>();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return entries;
        }

        foreach (var line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split(new string[] { Separator }, StringSplitOptions.None);
            if (parts.Length == 3)
            {
                entries.Add(new Entry(parts[1], parts[2]) { Date = parts[0] });
            }
        }

        Console.WriteLine("Journal loaded successfully.");
        return entries;
    }
}

class Program
{
    static Journal journal = new Journal();
    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine($"\n{prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        journal.AddEntry(prompt, response);
        Console.WriteLine("Entry added successfully.");
    }

    static void SaveJournal()
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();
        FileHandler.SaveToFile(filename, journal.GetEntries());
    }

    static void LoadJournal()
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        journal.ClearEntries();
        foreach (var entry in FileHandler.LoadFromFile(filename))
        {
            journal.AddEntry(entry.Prompt, entry.Response);
        }
    }
}
