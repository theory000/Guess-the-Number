using System;

namespace GuessingGame // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 100);
            int guess;
            int attempts = 0;

            void ResetGame(){
                secretNumber = random.Next(1, 100);
                attempts = 0;
            }

            while(true) {
                while(attempts < 5) {
                    Console.WriteLine("Guess a number between 1 and 100 in 5 attempts");
                    Console.WriteLine("Attempts: {0}", attempts);

                    try {
                        guess = Convert.ToInt32(Console.ReadLine());
                    } catch (FormatException) {
                        Console.WriteLine("Invalid input. Please try again.");
                        continue;
                    }

                    if (guess < 1 || guess > 100) {
                        Console.WriteLine("Please enter a number between 1 and 100");
                        continue;
                    }

                    int difference = Math.Abs(guess - secretNumber);

                    if (guess == secretNumber) {
                        Console.WriteLine("Congrats, you guessed the correct number in {0} attempts!", attempts);
                        break;
                    } else if (difference > 20) {
                        Console.WriteLine("Way to {0}! Try again", guess < secretNumber ? "low" : "high");
                    } else if (difference > 10) {
                        Console.WriteLine("Getting close! Just a little {0}", guess < secretNumber ? "low" : "high");
                    } else {
                        Console.WriteLine("Very close! Just a little {0}", guess < secretNumber ? "Lower" : "higher");
                    }

                    attempts ++;
                }

            if (attempts == 5) {
                Console.WriteLine("Sorry, you ran out of guesses. The secret number was {0}", secretNumber);
            }

            Console.WriteLine("Do you want to play again? (y/n): ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y") {
                ResetGame();
            } else {
                Console.WriteLine("Thanks for playing!");
                break; // Exit the infinite loop
            }
            }

        }
    }
}