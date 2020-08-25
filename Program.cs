using System;

namespace Guessing_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Guessing Game!");
            PlayTheGame();
        }



        static void PlayTheGame()
        {
            int secretNumber = 42;
            int guess;
            do
            {
                guess = MakeAGuess();
            }
            while (guess < 1 || guess > 100);

            if (guess == secretNumber)
            {
                Console.WriteLine("You guessed it!");
            }
            else
            {
                Console.WriteLine("WRONG!");
                Console.WriteLine("Try Again");
            }

        }
        static int MakeAGuess()
        {

            string response;
            int guess;
            do
            {
                Console.WriteLine("Guess the secret number (between 1 and 100)");
                Console.Write("??");
                response = Console.ReadLine();
            }
            while (int.TryParse(response, out guess) == false);

            guess = int.Parse(response);
            return guess;

        }


    }
}
