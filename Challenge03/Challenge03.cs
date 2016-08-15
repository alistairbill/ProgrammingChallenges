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
        private static void Main(string[] args)
        {
            var shapeDimensions = new double[3];
            shapeDimensions[0] = UserInteraction("Enter width: ");
            shapeDimensions[1] = UserInteraction("Enter height: ");
            shapeDimensions[2] = UserInteraction("Enter depth (0 if this is a 2D shape): ");
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

        public static double UserInteraction(string prompt)
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

        public static double CalcArea(double width, double height)
        {
            return width*height;
        }

        public static double CalcArea(double width, double height, double depth)
        {
            return width*height*depth;
        }
    }
}