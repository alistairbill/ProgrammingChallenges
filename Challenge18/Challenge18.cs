/* Challenge 18
 *
 * Write a procedure drawstars that
 * will draw a sequence of spaces followed
 * by a sequence of stars. It should accept
 * two parameters—the number of spaces and
 * the number of stars.
 *
 * Example: Drawstars(3,5) would produce
 *         _ _ _ * * * * *
 *
 * Extension
 * Now write a program using this procedure
 * that will draw a pyramid whose base is
 * a width specified by the user.
 * Example:
 *
 * Enter base size of pyramid : 5
 * 	  	*
 * 	   ***
 * 	  *****
 */

using System;

namespace Challenge18
{
    class Challenge18
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            int baseSize = UserInteraction("Enter the size of the base of the triangle: ");
            Console.WriteLine();
            PrintTriangle(baseSize);
            Run();
        }

        static void DrawStars(int spaces, int stars)
        {
            for (int i = 0; i < spaces; i++) {
                Console.Write(" ");
            }
            for (int j = 0; j < stars; j++) {
                Console.Write("*");
            }
        }

        static void PrintTriangle(int baseSize)
        {
            int stars = 1;
            int spaces = (baseSize - 1) / 2;
            while (stars <= baseSize) {
                DrawStars(spaces, stars);
                stars += 2;
                spaces--;
                Console.Write("\n");
            }
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

