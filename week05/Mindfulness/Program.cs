using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;


// Exceeded core requirements:
// - Added GratitudeActivity: a new activity guiding the user to express gratitude.
// - Session tracking: counts how many times each activity was run during the session.
// - Intelligent prompt/question reuse: ensures all items are shown before repeating.
// - Enhanced breathing animation: dynamic breathing text that grows and shrinks.
// - Activity log system: logs activity sessions to a text file and loads previous logs.

class Program
{
    private static Dictionary<string, int> activityCounts = new();
    private static string logFile = "activity_log.txt";
    
    static void Main(string[] args)
    {
        LoadLog();

        List<Activity> activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectingActivity(),
            new ListingActivity(),
            new GratitudeActivity()
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities:");
            for (int i = 0; i < activities.Count; i++)
                Console.WriteLine($"{i + 1}. {activities[i].GetType().Name.Replace("Activity", "")}");
            Console.WriteLine("0. Quit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();
            if (input == "0") break;

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= activities.Count)
            {
                var activity = activities[choice - 1];
                activity.Run();
                string key = activity.GetType().Name;
                if (!activityCounts.ContainsKey(key))
                    activityCounts[key] = 0;
                activityCounts[key]++;
                SaveLog();
            }
        }
    }

    static void SaveLog()
    {
        using StreamWriter writer = new StreamWriter(logFile);
        foreach (var pair in activityCounts)
            writer.WriteLine($"{pair.Key}:{pair.Value}");
    }

    static void LoadLog()
    {
        if (!File.Exists(logFile)) return;
        foreach (var line in File.ReadAllLines(logFile))
        {
            var parts = line.Split(':');
            if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                activityCounts[parts[0]] = count;
        }
    }
}