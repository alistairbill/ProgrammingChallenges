/* Challenge 12
 *
 * Write a program that will display all the factors of a number,
 * entered by the user, that are bigger than 1.
 * (e.g. the factors of the number 12 are 6,4,3 and 2
 * because they divide into 12 exactly).
 *
 */

using System;
using System.Collections.Generic;

namespace Challenge12
{
    class Challenge12
    {
        static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
        }

        public static void Run()
        {
            Console.Write("Enter an integer: ");
            string input = Console.ReadLine();
            int number;
            int[] factors = new int[0];
            if (int.TryParse(input, out number))
            {
                factors = Factorise(number);
            }
            else
            {
                Console.WriteLine("Not an integer");
                Run();
            }

            if (factors.Length > 0)
            {
                Console.Write("The factors of {0} are:", number);
                foreach (int item in factors)
                {
                    Console.Write(" " + item);
                }
                return;
            }
            Console.WriteLine("{0} is a prime number", number);
        }

        public static int[] Factorise(int number)
        {
            var factors = new List<int>();
            for (int i = number - 1; i > 1; i--)
            {
                if (number % i == 0) factors.Add(i);
            }
            return factors.ToArray();
        }
    }
}
