using System;
using System.Collections.Generic;

namespace Guessing_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int tries = 1;
            Console.Clear();
            Console.WriteLine("Welcome to the Guessing Game!");
            PlayTheGame(tries);
        }

        static int insultForWrongGuess()
        {
            int insult = new Random().Next(0, 4);
            return insult;
        }

        static void PlayTheGame(int tries)
        {
            List<string> warnings = new List<string>
             {
                 "Sorry, that's not it",
                 "Wrong again",
                 "You're not very good at this, are you?",
                 "Seriously, I' really though you'd do better."
            };

            int insult = (tries - 1);


            int secretNumber = 42;
            int guess;
            int allowed = 4;
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
                if (insult > 4)
                {
                    insult = insultForWrongGuess();
                }
                Console.Clear();
                Console.WriteLine($"{warnings[insult]}");
                if (tries < allowed)
                {
                    Console.WriteLine("Try Again");
                    tries++;
                    PlayTheGame(tries);
                }
                else
                {
                    Console.WriteLine("Thanks for playing");
                    Console.WriteLine("Please insert another quarter");
                }
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
