/* Challenge 14
*
* Write a program for a higher / lower guessing game
*
* The computer randomly generates a sequence of up to
* 10 numbers between 1 and 13. The player each after
* seeing each number in turn has to decide whether the
* next number is higher or lower.
*
* If you can remember Brucie's 'Play your cards right'
* it's basically that.
*
* If you get 10 guesses right you win the game.
*
* Extension:
* - Give the players two lives
* - Make sure only H or L can be entered
*
* ---------------------------------------------------------------
*
* Note: I have adapted this challenge - in its original
* form (as shown above) there was the possibility that
* the randomly-generated next number could be the same
* as the current number.
*
* Instead, I have made the game work as follows:
* - 12 numbers are selected from a deck containing the numbers 1-13
* - This array of 12 numbers is shuffled
* - The player is given the starting number
* - The player has to decide whether the next number in the array
*   is higher or lower than the current number
*
* In my opinion, this works better, as the game can now be played
* tactically - if the current number is 13, the next number must
* be lower; if the current number is 3, the odds are that the next
* number will be higher, etc.
*
*/

using System;
using System.Linq;

namespace Challenge14
{
    class Challenge14
    {
        static int playerLives = 2;
        static int playerPoints;
        const int WinThreshold = 10;
        static int[] numberSequence;

        static void Main(string[] args)
        {
            Init();
            Run();
        }

        static void Init()
        {
            numberSequence = GenerateDeck(12, 13);
            Console.WriteLine("Starting number: {0}", numberSequence[0]);
        }

        static void Game(int nextnum)
        {
            Console.Write("Higher (H) or lower (L)? ");
            var answer = Console.ReadKey();
            switch (char.ToLower(answer.KeyChar)) {
                case 'h':
                    if (numberSequence[nextnum] > numberSequence[nextnum - 1])
                        Correct();
                    else
                        Incorrect();
                    break;

                case 'l':
                    if (numberSequence[nextnum] < numberSequence[nextnum - 1])
                        Correct();
                    else
                        Incorrect();
                    break;

                default:
                    Console.WriteLine(" That's not an answer!");
                    Game(nextnum);
                    break;
            }
        }

        static int[] GenerateDeck(int count, int max)
        {
            var randNum = new Random();
            int[] sequence = Enumerable.Range(1, max).ToArray();

            for (int i = 0; i < sequence.Length; i++) {
                int randpos = i + randNum.Next(sequence.Length - i);
                int temp = sequence[randpos];
                sequence[randpos] = sequence[i];
                sequence[i] = temp;
            }
            return sequence.Take(count).ToArray();
        }

        static void Run()
        {
            for (int nextnum = 1; nextnum < numberSequence.Length; nextnum++) {
                Game(nextnum);
                Console.WriteLine("Next number: " + numberSequence[nextnum]);
            }
        }

        static void Incorrect()
        {
            playerLives--;
            if (playerLives == 0) {
                Console.WriteLine(" Incorrect. No lives remaining, sorry!");
                Environment.Exit(0);
            } else {
                Console.WriteLine(" Incorrect, sorry. {0} lives remaining.", playerLives);
            }
        }

        static void Correct()
        {
            playerPoints++;     // add a point
            Console.WriteLine(" Correct! Points: {0}\n", playerPoints);
            if (playerPoints == WinThreshold)
                Win();
        }

        static void Win()
        {
            Console.Write("You won!");
            Environment.Exit(0);
        }
    }
}
