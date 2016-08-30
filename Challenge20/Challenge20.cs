/* Challenge 20
 *
 * Create a Fibonacci sequence generator.
 * (The Fibonacci sequence was originally used
 * as a basic model for rabbit population growth).
 * The Fibonacci sequence goes like this.
 *
 * 0,1,1,2,3,5,8,13
 *
 * The Nth term is the sum of the previous two terms.
 * So in the example above the next term would be 21 because
 * it would be the previous two terms added together (8+13).
 *
 * You will need create a list of Fibonnaci numbers up
 * to the 50th term. The program will then ask the user
 * for which position in the sequence they want to know
 * the Fibonacci value for (up to 50).
 *
 * E.g Which position in sequence? 6 (start counting at 0)
 *
 * Fibonacci number is 8
 */

using System;
using System.Collections.Generic;

namespace Challenge20
{
    class Challenge20
    {
        static void Main(string[] args)
        {
            Console.Write("");
            int number = FibonacciNumber(UserInteraction("Which position in sequence? "));
            Console.WriteLine("Fibonacci number is {0}", number);
            Console.ReadKey();
        }
        static int FibonacciNumber(int position)
        {
            var sequence = new List<int> { 0, 1 };

            if (position <= 1) return sequence[position];
            for (int i = 2; i < (position + 1); i++) {
                sequence.Add(sequence[i - 2] + sequence[i - 1]);
            }
            return sequence[position];
        }

        static int UserInteraction(string prompt)
        {
            int providedvalue;
            bool isnumber;
            do {
                Console.Write(prompt);
                isnumber = int.TryParse(Console.ReadLine(), out providedvalue);
                if (!isnumber) {
                    Console.WriteLine("That's not a number");
                }
            } while (!isnumber);
            return providedvalue;
        }
    }
}
