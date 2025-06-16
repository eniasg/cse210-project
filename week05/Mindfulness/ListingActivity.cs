using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base(
        "Positive Listing", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    ) { }

    public override void Run()
    {
        Start();
        
        Random rand = new Random();
        Console.WriteLine("\nList as many responses as you can to:");
        Console.WriteLine($"\n--- {Prompts[rand.Next(Prompts.Count)]} ---");
        
        Console.Write("\nStarting in ");
        ShowCountdown(5);
        
        int itemCount = 0;
        Console.WriteLine("\nBegin listing now:");
        
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }
        }
        
        Console.WriteLine($"\nYou listed {itemCount} items!");
        End();
    }
}