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
 */

using System;
using System.Linq;

namespace Challenge14
{
    class Challenge14
    {
        static int _playerlives = 2;
        static int _playerpoints;
        const int WinThreshold = 10;
        static int[] _numberSequence;

        static void Main(string[] args)
        {
            Init();
            Run();
        }

        public static void Init()
        {
            _numberSequence = GenerateDeck(12, 13); // has to be 12 values - there are 2 lives
            Console.WriteLine("Starting number: {0}", _numberSequence[0]);
        }

        public static void Game(int i)
        {
            Console.Write("Higher (H) or lower (L)? ");
            var answer = Console.ReadKey();
            switch (char.ToLower(answer.KeyChar)) {
                case 'h':
                    if (_numberSequence[i] > _numberSequence[i - 1]) {
                        Correct();
                    } else {
                        Incorrect();
                    }
                    break;
                case 'l':
                    if (_numberSequence[i] < _numberSequence[i - 1]) {
                        Correct();
                    } else {
                        Incorrect();
                    }
                    break;
                default:
                    Console.WriteLine(" That's not an answer!");
                    Game(i);
                    break;
            }
        }

        public static int[] GenerateDeck(int count, int max)
        {
            /* Generates array of numbers 1 to 'max',
             * shuffles that array, then returns the
             * first 'count' values from that array.
             */

            var randNum = new Random();
            var sequence = Enumerable.Range(1, max).ToArray();

            for (int i = sequence.Length - 1; i > 0; i--) {
                int n = randNum.Next(i + 1);
                int temp = sequence[i];
                sequence[i] = sequence[n];
                sequence[n] = temp;
            }

            int[] deck = sequence.Take(count).ToArray();
            return deck;
        }

        public static void Run()
        {
            for (int i = 1; i < _numberSequence.Length; i++) {
                Game(i);
                Console.WriteLine("Next number: " + _numberSequence[i]);
            }
        }

        public static void Incorrect()
        {
            _playerlives--;
            if (_playerlives == 0) {
                Console.WriteLine(" Incorrect. No lives remaining, sorry!");
                Environment.Exit(0);
            } else {
                Console.WriteLine(" Incorrect, sorry. {0} lives remaining.", _playerlives);
            }
        }

        public static void Correct()
        {
            _playerpoints++;
            Console.WriteLine(" Correct! Points: {0}\n", _playerpoints);
            if (_playerpoints == WinThreshold) {
                Win();
            }
        }

        public static void Win()
        {
            Console.Write("You won!");
            Environment.Exit(0);
        }
    }
}
