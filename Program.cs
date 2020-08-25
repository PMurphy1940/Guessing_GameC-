using System;
using System.Collections.Generic;

namespace Guessing_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int theMagicNumber = SecretNumber();
            int tries = 1;
            Console.Clear();
            Console.WriteLine("Welcome to the Guessing Game!");
            PlayTheGame(tries, theMagicNumber);
        }

        static int insultForWrongGuess()
        {
            int insult = new Random().Next(0, 4);
            return insult;
        }

        static int SecretNumber()
        {
            int secret = new Random().Next(1, 100);
            return secret;
        }

        static string PlaysLeft(int tries, int allowed)
        {
            int plays = allowed - tries;
            if (plays > 1)
            {
                return ($"You have {plays} attempts remaining.");
            }
            else
            {
                return ("This is your last shot!");
            }
        }

        static void PlayTheGame(int tries, int theMagicNumber)
        {
            List<string> warnings = new List<string>
             {
                 "Sorry, that's not it",
                 "Wrong again",
                 "You're not very good at this, are you?",
                 "Seriously, I' really though you'd do better."
            };

            int allowed = 4;
            int insult = (tries - 1);
            Console.WriteLine(theMagicNumber);

            string lives = PlaysLeft(tries, allowed);

            int guess;


            do
            {
                guess = MakeAGuess();
            }
            while (guess < 1 || guess > 100);

            if (guess == theMagicNumber)
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
                    if (guess < theMagicNumber)
                    {
                        Console.WriteLine("To Low!");
                    }
                    else
                    {
                        Console.WriteLine("To High!");
                    }

                    Console.WriteLine("Try Again");
                    Console.WriteLine($"{lives}");
                    tries++;
                    PlayTheGame(tries, theMagicNumber);
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
