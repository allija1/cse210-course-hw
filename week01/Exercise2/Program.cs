using System;

class Program
{
    static void Main(string[] args)
    {
        // core requirements
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();

        // stretch challange
        if (int.TryParse(input, out int percent))
        {
            if (percent < 0 || percent > 100)
            {
                Console.WriteLine("Please enter a percentage between 0 and 100.");
                return;
            }

            string letter = "";
            string sign = "";

            // Determine the letter grade
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

            int lastDigit = percent % 10;

            if (letter != "F") 
            {
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }

            // If A+ casses occur
            if (letter == "A" && sign == "+")
            {
                sign = "";
            }

            // Print the grade with the sign
            Console.WriteLine($"Your grade is: {letter}{sign}");

            // Determine if the user passed or failed
            if (percent >= 70)
            {
                Console.WriteLine("Congratulations, you passed!");
            }
            else
            {
                Console.WriteLine("Better luck next time!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
    }
}
