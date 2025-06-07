using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    private static List<Scripture> _scriptures = new List<Scripture>();
    private static List<SessionRecord> _sessionHistory = new List<SessionRecord>();
    private const string SCRIPTURE_FILE = "scriptures.json";
    private const string HISTORY_FILE = "sessions.json";
    
    static void Main(string[] args)
    {
        Console.Title = "Scripture Memorizer";
        LoadScriptures();
        LoadHistory();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.ResetColor();

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Start New Memorization Session");
            Console.WriteLine("2. View Session History");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    StartMemorizationSession();
                    break;
                case "2":
                    DisplaySessionHistory();
                    break;
                case "3":
                    SaveHistory();
                    Console.WriteLine("\nThank you for using Scripture Memorizer!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void StartMemorizationSession()
    {
        // Select random scripture
        Random rand = new Random();
        Scripture scripture = _scriptures[rand.Next(_scriptures.Count)];
        
        // Set difficulty
        Console.WriteLine("\nSelect Difficulty:");
        Console.WriteLine("1. Easy (1 word hidden)");
        Console.WriteLine("2. Medium (3 words hidden)");
        Console.WriteLine("3. Hard (5 words hidden, prioritizes key words)");
        Console.Write("Choose difficulty: ");
        
        int difficulty = int.Parse(Console.ReadLine());
        int wordsToHide = difficulty switch { 1 => 1, 3 => 5, _ => 3 };
        bool prioritizeLong = (difficulty == 3);  // Hard mode
        
        // Start session
        SessionRecord session = new SessionRecord
        {
            ScriptureId = scripture.GetReferenceId(),
            StartTime = DateTime.Now,
            Difficulty = difficulty
        };
        
        bool completed = false;
        Console.Clear();
        Console.WriteLine("Starting memorization session...\n");
        
        while (true)
        {
            // Display progress
            float progress = scripture.GetCompletionPercentage();
            Console.ForegroundColor = GetProgressColor(progress);
            Console.WriteLine($"Progress: {progress:P0}");
            Console.ResetColor();
            
            // Display scripture
            Console.WriteLine(scripture.GetDisplayText());
            
            // Check completion
            if (scripture.IsCompletelyHidden())
            {
                completed = true;
                break;
            }
            
            // Get user input
            Console.Write("\nPress ENTER to hide words, 'hint' for clues, or 'quit' to exit: ");
            string input = Console.ReadLine()?.ToLower();
            
            if (input == "quit")
            {
                break;
            }
            else if (input == "hint")
            {
                scripture.ApplyHints();
            }
            else
            {
                scripture.HideRandomWords(wordsToHide, prioritizeLong);
            }
            
            Console.Clear();
        }
        
        // Record session
        session.EndTime = DateTime.Now;
        session.Completed = completed;
        _sessionHistory.Add(session);
        
        Console.Clear();
        if (completed)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations! You've memorized the entire scripture!");
            Console.ResetColor();
            Console.WriteLine(scripture.GetDisplayText());
        }
        
        Console.WriteLine($"\nSession Duration: {session.Duration:mm\\:ss}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void LoadScriptures()
    {
        if (!File.Exists(SCRIPTURE_FILE))
        {
            CreateSampleScriptures();
        }
        
        List<ScriptureData> data = JsonConvert.DeserializeObject<List<ScriptureData>>(
            File.ReadAllText(SCRIPTURE_FILE));
        
        _scriptures = data.Select(item => 
            item.EndVerse.HasValue ?
                new Scripture(
                    new Reference(item.Book, item.Chapter, item.StartVerse, item.EndVerse.Value),
                    item.Text) :
                new Scripture(
                    new Reference(item.Book, item.Chapter, item.StartVerse),
                    item.Text)
        ).ToList();
    }

    static void CreateSampleScriptures()
    {
        List<ScriptureData> sampleData = new List<ScriptureData>
        {
            new ScriptureData {
                Book = "John",
                Chapter = 3,
                StartVerse = 16,
                Text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
            },
            new ScriptureData {
                Book = "Proverbs",
                Chapter = 3,
                StartVerse = 5,
                EndVerse = 6,
                Text = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
            },
            new ScriptureData {
                Book = "Philippians",
                Chapter = 4,
                StartVerse = 13,
                Text = "I can do all this through him who gives me strength."
            }
        };
        
        File.WriteAllText(SCRIPTURE_FILE, JsonConvert.SerializeObject(sampleData, Formatting.Indented));
    }

    static void LoadHistory()
    {
        if (File.Exists(HISTORY_FILE))
        {
            _sessionHistory = JsonConvert.DeserializeObject<List<SessionRecord>>(
                File.ReadAllText(HISTORY_FILE)) ?? new List<SessionRecord>();
        }
    }

    static void SaveHistory()
    {
        File.WriteAllText(HISTORY_FILE, 
            JsonConvert.SerializeObject(_sessionHistory, Formatting.Indented));
    }

    static void DisplaySessionHistory()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("SESSION HISTORY\n");
        Console.ResetColor();
        
        if (!_sessionHistory.Any())
        {
            Console.WriteLine("No sessions recorded yet.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }
        
        foreach (var session in _sessionHistory)
        {
            Console.WriteLine($"{session.StartTime:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"Scripture: {GetScriptureName(session.ScriptureId)}");
            Console.WriteLine($"Difficulty: {(session.Difficulty == 1 ? "Easy" : session.Difficulty == 2 ? "Medium" : "Hard")}");
            Console.WriteLine($"Duration: {session.Duration:mm\\:ss}");
            Console.WriteLine($"Completed: {(session.Completed ? "Yes" : "No")}");
            Console.WriteLine(new string('-', 40));
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static string GetScriptureName(string id)
    {
        var parts = id.Split('_');
        if (parts.Length == 3) 
            return $"{parts[0]} {parts[1]}:{parts[2]}";
        if (parts.Length == 4) 
            return $"{parts[0]} {parts[1]}:{parts[2]}-{parts[3]}";
        return id;
    }

    static ConsoleColor GetProgressColor(float progress) => progress switch
    {
        < 0.25f => ConsoleColor.Red,
        < 0.5f => ConsoleColor.Yellow,
        < 0.75f => ConsoleColor.Cyan,
        _ => ConsoleColor.Green
    };
}