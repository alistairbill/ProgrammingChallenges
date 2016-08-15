/* Challenge 22
 * - Create a two-dimensional array of integers 10 by 10
 *
 * - Fill the array with random numbers in the range 0 to 15
 *
 * - Display the array on the screen showing the numbers
 *
 * - Display the array on the screen as spaces whose
 *   BackColor property has been set to the number in
 *   this position of the array
 */

using System;

namespace Challenge22
{
    class Challenge22
    {
        static readonly int[,] Box = new int[10, 10];

        static void Main(string[] args)
        {
            FillArray();
            DisplayArray();
            Console.WriteLine();
            DisplayColourArray();
            Console.ReadKey();
        }

        static void FillArray()
        {
            var randInt = new Random();

            for (int x = 0; x < Box.GetLength(0); x++) {
                for (int y = 0; y < Box.GetLength(1); y++) {
                    Box[x, y] = randInt.Next(0, 16);
                }
            }
            return;
        }
        static void DisplayArray()
        {
            for (int row = 0; row < Box.GetLength(0); row++) {
                for (int column = 0; column < Box.GetLength(1); column++) {
                    // insert a 0 before one-digit numbers.
                    string number = (Box[row, column] < 10) ? "0" + Box[row,column] : Box[row,column].ToString();
                    Console.Write(number + " ");
                }
                Console.Write("\n");
            }
            return;
        }
        static void DisplayColourArray()
        {
            for (int row = 0; row < Box.GetLength(0); row++) {
                for (int column = 0; column < Box.GetLength(1); column++)
                {
                    Console.BackgroundColor = (ConsoleColor)Box[row, column];
                    Console.Write("   ");
                }
                Console.Write("\n");
            }
            Console.ResetColor();
        }
    }
}

