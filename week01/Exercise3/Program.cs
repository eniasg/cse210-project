using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;

        Console.WriteLine("Welcome to the Guess My Number game!");

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess;

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (guess != magicNumber);

            Console.WriteLine($"It took you {guessCount} guesses.");

            Console.Write("Would you like to play again? (yes/no) ");
            string response = Console.ReadLine().ToLower();

            if (response != "yes")
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Thanks for playing!");
    }
}