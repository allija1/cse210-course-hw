using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;

        do
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            int number;
            do
            {
                Console.Write("Enter number: ");
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number != 0)
                    {
                        numbers.Add(number);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (number != 0);

            if (numbers.Count > 0)
            {
                int sum = 0;
                int maxNumber = int.MinValue;

                foreach (var num in numbers)
                {
                    sum += num;
                    if (num > maxNumber)
                    {
                        maxNumber = num;
                    }
                }

                double average = sum / (double)numbers.Count;

                Console.WriteLine($"The average is: {average}");
                Console.WriteLine($"The largest number is: {maxNumber}");

                // Stretch Challenge: Find the smallest positive number
                int? smallestPositive = null;
                foreach (var num in numbers)
                {
                    if (num > 0 && (smallestPositive == null || num < smallestPositive))
                    {
                        smallestPositive = num;
                    }
                }

                if (smallestPositive.HasValue)
                {
                    Console.WriteLine($"The smallest positive number is: {smallestPositive.Value}");
                }
                else
                {
                    Console.WriteLine("No positive numbers were entered.");
                }

                // Sort the list and display it
                numbers.Sort();
                Console.WriteLine("The sorted list is:");
                foreach (var num in numbers)
                {
                    Console.WriteLine(num);
                }
            }
            else
            {
                Console.WriteLine("No numbers were entered.");
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to enter another list of numbers? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}
