using System;
using System.Linq;

namespace Wordle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to wordle, where you need to guess a five letter word.");
            Game wordle = new Game();
            wordle.wordle();
        }
    }

    class Game
    {
        public void wordle()
        {
            //20 5 letter words
            string[] myArray = { "apple", "baker", "chess", "drift", "every", "flour", "grape", "happy", "ivory", "jolly", 
                "kneel", "lemon", "merry", "noble", "olive", "proud", "queen", "rider", "silly", "tiger" };
            //picking random word in the array
            Random rand = new Random();
            int randomIndex = rand.Next(myArray.Length);
            string randomWord = myArray[randomIndex];
            int guessesRemaining = 6;
            bool guessed = false;

            
            while (!guessed && guessesRemaining > 0)
            {
                Console.WriteLine();
                Console.Write("Guess a 5 letter word (" + guessesRemaining + " guesses remaining): ");
                string guess = Console.ReadLine();

                if (guess == randomWord)
                {
                    Console.WriteLine("You guessed it! The word was " + randomWord);
                    guessed = true;
                }
                else
                {
                    guessesRemaining--;
                    Console.WriteLine();
                    Console.WriteLine("Sorry, that's not the word. You have " + guessesRemaining + " guesses remaining.");

                    // different color for right guess letter
                    Console.WriteLine();
                    Console.Write("Correct letters within your guess: ");
                    for (int i = 0; i < guess.Length; i++)
                    {
                        if (randomWord.Contains(guess[i]))
                        {
                            if (guess[i] == randomWord[i])
                            {
                                //kapag mali ang word pero tama ang letter placement magiging green
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(guess[i]);
                            }
                            else
                            {
                                //kapag mali ang word at mali rin ang letter placement magiging yellow
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(guess[i]);
                            }
                        }
                        else
                        {
                            Console.ResetColor();
                            Console.Write("_");
                        }
                    }
                    Console.WriteLine();
                }
            }

            if (!guessed)
            {
                Console.WriteLine("Sorry, you ran out of guesses. The word was " + randomWord);
            }
        }
    }
}
