using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn today?",
            "What am I grateful for today?",
            "What was the most challenging part of my day?",
            "How did I take care of myself today?",
            "What made me smile today?"
        };

        // Exceeding requirements:
        // 1. Added 5 additional prompts (10 total)
        // 2. Used JSON format for robust storage
        // 3. Handled special characters through JSON serialization
        // 4. Included date/time in entries

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Entry newEntry = new Entry
                    {
                        Date = DateTime.Now,
                        Prompt = GetRandomPrompt(prompts)
                    };
                    Console.WriteLine($"\nPrompt: {newEntry.Prompt}");
                    Console.Write("Your response: ");
                    newEntry.Response = Console.ReadLine();
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    Console.WriteLine("\nJournal Entries:");
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("\nEnter filename to save: ");
                    journal.SaveToFile(Console.ReadLine());
                    Console.WriteLine("Journal saved successfully.");
                    break;

                case "4":
                    Console.Write("\nEnter filename to load: ");
                    try
                    {
                        journal.LoadFromFile(Console.ReadLine());
                        Console.WriteLine("Journal loaded successfully.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error loading journal. File may not exist.");
                    }
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static string GetRandomPrompt(List<string> prompts)
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }
}