/* Challenge 26
 * 
 * CodeBreaker
 *
 * The computer generates a 4 digit code
 * The user types in a 4 digit code - their guess.
 * The computer tells them how many digits they guessed correctly
 *
 * Extension
 * The computer tells them how many digits are guessed correctly
 * in the correct place and how many digits have been guessed correctly
 * but in the wrong place.
 * The user gets 12 guesses to either win – guess the right code –
 * or lose – run out of guesses.
 */

using System;
using System.Linq;

namespace Challenge26
{
    class Challenge26
    {
        static int[] code = new int[4];
        static int lives = 12;
        static Random random = new Random();

        static void Main(string[] args)
        {
            GenerateCode();
            Run();
        }

        static void GenerateCode()
        {
            for (int i = 0; i < code.Length; i++) {
                code[i] = random.Next(0, 9);
            }
        }

        static void Run()
        {
            int[] guess = new int[4];
            while (lives > 0) {
                Console.WriteLine("Guess code: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) continue;

                Array.Clear(guess, 0, guess.Length);

                for (int i = 0; i < code.Length; i++) {
                    guess[i] = (int)char.GetNumericValue(input[i]);
                }
                Check(guess);
                lives--;
            }
            Console.WriteLine("You lose!");
        }

        static void Check(int[] guess)
        {
            int correct = 0;
            int exact = 0;
            for (int i = 0; i < code.Length; i++) {
                if (guess.Any(t => code[i] == t))
                    correct++;
                if (code[i] == guess[i])
                    exact++;
            }

            Console.WriteLine("Correct: {0} | Exactly correct: {1}", correct, exact);
            Console.WriteLine();
            if (exact != code.Length) return;
            Console.WriteLine("***********************");
            Console.WriteLine("* You win! Well done! *");
            Console.WriteLine("***********************");
            Console.ReadKey();
        }
    }
}
