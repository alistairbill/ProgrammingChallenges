/* Challenge 3
 *
 * Write a program to work out the areas of a rectangle.
 *
 * - Collect the width and height of the rectangle from
 *   the keyboard
 * - Calculate the area
 * - Display the result
 *
 * Extension
 * Display the volume of a cuboid
 */

using System;

namespace Challenge03
{
    class Challenge03
    {
        static void Main(string[] args)
        {
            double[] shapeDimensions = {
                UserInteraction("Enter width: "),
                UserInteraction("Enter height: "),
                UserInteraction("Enter depth (0 if this is a 2D shape): ")
            };
            double answer;
            if (shapeDimensions[2] != 0) {
                answer = CalcArea(shapeDimensions[0], shapeDimensions[1], shapeDimensions[2]);
                Console.WriteLine("Area of cuboid: {0} cm\u00b3", answer);
            } else {
                answer = CalcArea(shapeDimensions[0], shapeDimensions[1]);
                Console.WriteLine("Area of rectangle: {0} cm\u00b2", answer);
            }
            Console.ReadKey();
        }

        static double UserInteraction(string prompt)
        {
            double providedvalue;
            bool isnumber;
            do {
                Console.Write(prompt);
                isnumber = double.TryParse(Console.ReadLine(), out providedvalue);
                if (!isnumber) {
                    Console.WriteLine("That's not a number");
                }
            } while (!isnumber);
            return providedvalue;
        }

        static double CalcArea(double width, double height)
        {
            return width * height;
        }

        static double CalcArea(double width, double height, double depth)
        {
            return width * height * depth;
        }
    }
}