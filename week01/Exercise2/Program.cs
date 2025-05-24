using System;

class Program
{
    
class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int percent = int.Parse(userInput);

        string letter = "";
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign
        string sign = "";
        int lastDigit = percent % 10;

        if (letter != 'F')
        {
            if (letter == 'A')
            {
                // A can only have a minus or none
                if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
            else
            {
                // For B, C, D: check for + or -
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
        }

        // Combine the letter and sign
        string grade = $"{letter}{sign}";

        // Print the letter grade
        Console.WriteLine($"Your grade is {grade}");

        // Check if the user passed and provide feedback
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard. Better luck next time!");
        }
    }
}