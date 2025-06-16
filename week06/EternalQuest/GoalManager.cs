using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level = 1;

    public void Start()
    {
        LoadGoals();
        bool running = true;
        
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== ETERNAL QUEST ===");
            Console.WriteLine($"Current Score: {_score} points (Level {_level})");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. View Progress");
            Console.WriteLine("5. Save & Exit");
            Console.Write("Select option: ");
            
            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": RecordEvent(); break;
                case "4": ShowProgress(); break;
                case "5": running = false; break;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
        
        SaveGoals();
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\n=== YOUR GOALS ===");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (Creative)");
        Console.WriteLine("5. Progress Goal (Creative)");
        
        Console.Write("Select type: ");
        string type = Console.ReadLine();
        
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        
        Console.Write("Enter points: ");
        string points = Console.ReadLine();
        
        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, desc, points));
                break;
            case "5":
                Console.Write("Enter target progress: ");
                int progressTarget = int.Parse(Console.ReadLine());
                _goals.Add(new ProgressGoal(name, desc, points, progressTarget));
                break;
            default:
                Console.WriteLine("Invalid goal type");
                break;
        }
        
        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available");
            return;
        }
        
        Console.WriteLine("\nSelect a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i]._shortName}");
        }
        
        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        
        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            int points = goal.RecordEvent();
            _score += points;
            
            // Update level
            int newLevel = _score / 500 + 1;
            if (newLevel > _level)
            {
                Console.WriteLine($"Level up! You reached level {newLevel}!");
                _level = newLevel;
            }
            
            Console.WriteLine($"Event recorded! {(points >= 0 ? "+" : "")}{points} points");
        }
    }

    public void ShowProgress()
    {
        Console.WriteLine("\n=== PROGRESS OVERVIEW ===");
        Console.WriteLine($"Total Points: {_score}");
        Console.WriteLine($"Current Level: {_level}");
        
        int completed = 0;
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete()) completed++;
        }
        Console.WriteLine($"Goals Completed: {completed}/{_goals.Count}");
        
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        if (!File.Exists("goals.txt")) return;
        
        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        
        if (lines.Length > 1)
        {
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            
            for (int i = 2; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] data = parts[1].Split('|');
                
                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(data[0], data[1], data[2]) 
                            { _isComplete = bool.Parse(data[3]) });
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], data[2]));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(data[0], data[1], data[2], 
                            int.Parse(data[4]), int.Parse(data[3])) 
                            { _amountCompleted = int.Parse(data[5]) });
                        break;
                    case "NegativeGoal":
                        _goals.Add(new NegativeGoal(data[0], data[1], data[2]));
                        break;
                    case "ProgressGoal":
                        _goals.Add(new ProgressGoal(data[0], data[1], data[2], 
                            int.Parse(data[3])) 
                            { _currentProgress = int.Parse(data[4]) });
                        break;
                }
            }
        }
    }
}