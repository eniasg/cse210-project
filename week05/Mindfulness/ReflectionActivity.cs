using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    
    private List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base(
        "Reflection", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    ) { }

    public override void Run()
    {
        Start();
        
        Random rand = new Random();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {Prompts[rand.Next(Prompts.Count)]} ---");
        
        Console.WriteLine("\nPress Enter when you have something in mind...");
        Console.ReadLine();
        
        Console.WriteLine("\nNow ponder these questions:");
        Console.Write("Starting in ");
        ShowCountdown(5);
        
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"\n> {Questions[rand.Next(Questions.Count)]} ");
            ShowSpinner(8);
        }
        
        End();
    }
}