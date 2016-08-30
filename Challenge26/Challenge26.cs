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

namespace Challenge26
{
    class Challenge26
    {
        static int[] code = new int[4];
        static int[] guess = new int[4];
        static int correct, exact;
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
            correct = 0;
            exact = 0;
            Console.WriteLine("Guess code: ");
            string input = Console.ReadLine();
            for (int i = 0; i < code.Length; i++) {
                guess[i] = (int)char.GetNumericValue(input[i]);
            }
            Check();
            lives--;
            if (lives == 0) {
                Console.WriteLine("You lose!");
                Environment.Exit(0);
            } else {
                Run();
            }
        }

        static void Check()
        {
            for (int i = 0; i < code.Length; i++) {
                for (int j = 0; j < guess.Length; j++) {
                    if (code[i] == guess[j]) {
                        correct++;
                        break;
                    }
                }
                if (code[i] == guess[i]) {
                    exact++;
                }
            }
            Console.WriteLine("Correct: {0} | Exactly correct: {1}", correct, exact);
            Console.WriteLine();
            if (exact == code.Length) {
                Console.WriteLine("***********************");
                Console.WriteLine("* You win! Well done! *");
                Console.WriteLine("***********************");
                Environment.Exit(0);
            }
        }
    }
}
