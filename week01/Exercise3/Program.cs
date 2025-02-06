using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;

        do
        {
            // Step 1: Generate random magic number between 1 and 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int guess;
            int guessCount = 0;

            // Step 2: Start the loop to guess until correct
            do
            {
                // Ask user for their guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++; // Increment the guess count

                // Step 3: Check if the guess is higher, lower, or correct
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

Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }
            while (guess != magicNumber);

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");
        
        Console.WriteLine("Thanks for playing!");
    }
}
