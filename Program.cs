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
            int allowed = Difficulty();
            Console.Clear();
            PlayTheGame(tries, theMagicNumber, allowed);
        }

        static int insultForWrongGuess(int numberOfWarnings)
        {
            int insult = new Random().Next(0, numberOfWarnings);
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
        static int Difficulty()
        {
            string challenge;
            do
            {
                Console.WriteLine("Choose your difficulty level");
                Console.WriteLine("'E' - Easy");
                Console.WriteLine("'M' - Medium");
                Console.WriteLine("'H' - Hard");
                challenge = Console.ReadLine().ToLower();
            }
            while (challenge != "e" && challenge != "m" && challenge != "h" && challenge != "cheat");

            if (challenge == "e")
            {
                return 8;
            }
            else if (challenge == "m")
            {
                return 6;
            }
            else if (challenge == "h")
            {
                return 4;
            }
            else
            {
                return 10000;
            }
        }
        static void PlayTheGame(int tries, int theMagicNumber, int allowed)
        {
            List<string> warnings = new List<string>
             {
                 "Sorry, that's not it",
                 "Wrong again",
                 "You're not very good at this, are you?",
                 "Seriously, I' really though you'd do better.",
                 "Wow, just wow.",
                 "I think you had a better chance of getting it right if you hadn't even tried."
            };
            int numberOfWarnings = warnings.Count;

            int insult = (tries - 1);
            Console.WriteLine(theMagicNumber);

            string lives = PlaysLeft(tries, allowed);

            int guess;

            string mode = "normal";

            if (allowed == 10000)
            {
                mode = "cheat";
            }

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
                    insult = insultForWrongGuess(numberOfWarnings);
                }
                Console.Clear();
                Console.WriteLine($"{warnings[insult]}");
                if (tries < allowed && mode == "normal")
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
                    PlayTheGame(tries, theMagicNumber, allowed);
                }
                else if (mode == "cheat")
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
                    tries++;
                    Console.WriteLine($"Cheat mode active. You have made {tries} attempts");
                    PlayTheGame(tries, theMagicNumber, allowed);
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
