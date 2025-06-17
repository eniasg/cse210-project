using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"=== Eternal Quest ===");
        Console.WriteLine($"Current Score: {_score}");
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal");
        Console.WriteLine("  5. Progress Goal");
        Console.Write("Select goal type: ");
        string type = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, desc, points));
                break;
            case "5":
                Console.Write("Progress points: ");
                int progressPoints = int.Parse(Console.ReadLine());
                Console.Write("Target progress: ");
                int targetProgress = int.Parse(Console.ReadLine());
                _goals.Add(new ProgressGoal(name, desc, points, progressPoints, targetProgress));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
        Console.WriteLine("Goal created!");
    }

    private void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Select goal to record: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            int pointsEarned = _goals[index - 1].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Recorded! Earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Save filename: ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score); // Save score first
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals()
    {
        Console.Write("Load filename: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        var simple = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4]))
                        {
                            simple.RecordEvent();
                        }
                        _goals.Add(simple);
                        break;
                    case "EternalGoal":
                        var eternal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        var eternalField = eternal.GetType().GetField("_timesCompleted",
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        eternalField.SetValue(eternal, int.Parse(parts[4]));
                        _goals.Add(eternal);
                        break;
                    case "ChecklistGoal":
                        var checklist = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                            int.Parse(parts[5]), int.Parse(parts[4]));
                        var amountField = checklist.GetType().GetField("_amountCompleted",
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        amountField.SetValue(checklist, int.Parse(parts[6]));

                        if (int.Parse(parts[6]) >= int.Parse(parts[5]))
                        {
                            checklist.RecordEvent();
                        }
                        _goals.Add(checklist);
                        break;
                    case "NegativeGoal":
                        _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ProgressGoal":
                        var progress = new ProgressGoal(parts[1], parts[2], int.Parse(parts[3]),
                            int.Parse(parts[4]), int.Parse(parts[5]));
                        var progressField = progress.GetType().GetField("_currentProgress",
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        progressField.SetValue(progress, int.Parse(parts[6]));

                        if (int.Parse(parts[6]) >= int.Parse(parts[5]))
                        {
                            progress.RecordEvent();
                        }
                        _goals.Add(progress);
                        break;
                }
            }
            Console.WriteLine("Goals loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}