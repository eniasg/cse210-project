using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;


// Creativity and Exceeding Requirements:
// Activity log tracks usage statistics and is viewable through the main menu


class Program
{    
    static void Main(string[] args)
    {
        Console.Title = "Mindfulness Program";
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Activities ===");
            Console.WriteLine("1. Deep Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Positive Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==============================");
            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectionActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    Activity.ShowActivityLog();
                    break;
                case "5":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Have a peaceful day!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please select 1-5.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }
}