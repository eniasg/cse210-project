using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a library of scriptures
        List<Scripture> scriptureLibrary = CreateScriptureLibrary();

        // Select a random scripture from the library
        Random random = new Random();
        Scripture selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        // Display instructions
        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine("-------------------");
        Console.WriteLine("Press Enter to hide words or type 'quit' to exit.\n");


        // Exceeding requirements:
        // 1. The program now has a library of 7 different scriptures that it selects from randomly
        // 2. The program now only selects from words that aren't already hidden when choosing words to hide
        // 3. Added an encouraging message when all words are hidden


        // Main program loop
        while (!selectedScripture.AllWordsHidden)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.Write("\nPress Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                return;
            }

            selectedScripture.HideRandomWords(3); // Hide 3 words at a time
        }

        // Final display when all words are hidden
        Console.Clear();
        Console.WriteLine(selectedScripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden! Good job memorizing!");
    }

    // Create a library of scriptures (exceeding requirements)
    static List<Scripture> CreateScriptureLibrary()
    {
        return new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Psalm", 23, 1), "The LORD is my shepherd, I lack nothing."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
            new Scripture(new Reference("Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."),
            new Scripture(new Reference("Matthew", 11, 28), "Come to me, all you who are weary and burdened, and I will give you rest."),
            new Scripture(new Reference("Isaiah", 40, 31), "But those who hope in the LORD will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint.")
        };
    }
}