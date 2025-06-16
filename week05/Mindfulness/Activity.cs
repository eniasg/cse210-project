using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;
    protected static Dictionary<string, int> ActivityLog = new Dictionary<string, int>();

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {Name} Activity");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        
        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
        
        // Log activity
        if (ActivityLog.ContainsKey(Name))
            ActivityLog[Name]++;
        else
            ActivityLog.Add(Name, 1);
    }

    public void End()
    {
        Console.WriteLine("\nGreat job! You've completed the activity.");
        ShowSpinner(2);
        Console.WriteLine($"Activity: {Name}");
        Console.WriteLine($"Duration: {Duration} seconds");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("• ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();
    
    public static void ShowActivityLog()
    {
        Console.WriteLine("\n=== ACTIVITY LOG ===");
        foreach (var entry in ActivityLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}