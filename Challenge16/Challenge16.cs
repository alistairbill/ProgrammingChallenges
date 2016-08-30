/* Challenge 16
 * 
 * Guess the number game.
 *
 * The computer selects a random number between 1 and 100.
 * The user keeps guessing which number the computer has chosen
 * until they get it right.
 * The computer responds ‘got it’ or ‘too high’ or ‘too low’
 * after each guess.
 * After the user has guessed the number the computer tells them
 * how many attempts they have made.
 *
 * Extension
 * Reverse the game. You think of a number. Get the
 * computer to guess a number and you respond with too high (H),
 * too low (L) or got it (G). Make sure the computer has a game
 * plan — don't just let it guess at random!
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge16
{
    class Challenge16
    {
        static readonly List<int> NumberList = Enumerable.Range(1, 100).ToList();
        static int CurrentGuess;
        static bool NumberGuessed;
        static int Target;

        static void Main(string[] args)
        {
            do {
                Target = UserInteraction("Enter a number between 1 and 100: ");
            } while (Target > 100);

            while (!NumberGuessed) {
                Console.WriteLine("\nIs {0} your number?", GuessNumber());
                GuessResponse();
            }
            Console.WriteLine("\nThe computer guessed your number!");
            Console.ReadKey();
        }

        static int UserInteraction(string prompt)
        {
            int providedvalue;
            bool isnumber;
            do {
                Console.Write(prompt);
                isnumber = int.TryParse(Console.ReadLine(), out providedvalue);
                if (!isnumber)
                    Console.WriteLine("That's not a number");
            } while (!isnumber);
            return providedvalue;
        }

        static int GuessNumber()
        {
            NumberList.Sort();
            CurrentGuess = (NumberList.Count > 1) ? NumberList[(NumberList.Count + 1) / 2] : NumberList[0];
            return CurrentGuess;
        }

        static void GuessResponse()
        {
            Console.Write("Too high [h], too low [l] or got it [g]? : ");
            var response = Console.ReadKey();

            switch (char.ToLower(response.KeyChar)) {
                case 'h':
                    foreach (int number in NumberList.ToList()) {
                        if (number >= CurrentGuess)
                            NumberList.Remove(number);
                    }
                    break;
                case 'l':
                    foreach (int number in NumberList.ToList()) {
                        if (number <= CurrentGuess)
                            NumberList.Remove(number);
                    }
                    break;
                case 'g':
                    NumberGuessed = (CurrentGuess == Target);
                    if (!NumberGuessed)
                        Console.WriteLine("\nThat's not the number you put in!");
                    break;
            }
        }
    }
}
