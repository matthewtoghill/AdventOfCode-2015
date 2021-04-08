using System;
using System.Collections.Generic;
using System.IO;

namespace Day02
{
    class Program
    {
        private static string[] input = File.ReadAllLines(@"..\..\..\data\day02.txt");
        static void Main(string[] args)
        {
            int totalWrappingPaper = 0;
            int totalRibbon = 0;

            foreach (var line in input)
            {
                string[] vals = line.Split('x');
                int length = int.Parse(vals[0]);
                int width = int.Parse(vals[1]);
                int height = int.Parse(vals[2]);

                int wrappingPaper = GetWrappingPaperVolume(length, width, height);
                totalWrappingPaper += wrappingPaper;

                int ribbon = GetRibbonLength(length, width, height);
                totalRibbon += ribbon;
            }

            Console.WriteLine($"Part 1: {totalWrappingPaper}");
            Console.WriteLine($"Part 2: {totalRibbon}");
        }

        // Wrapper paper requirement calculated as:
        // Surface area of box: 2*(l*w + w*h + h*l)
        // plus additional slack as the side with the smallest area
        private static int GetWrappingPaperVolume(int length, int width, int height)
        {
            // Calculate the sides a, b, c
            int a = length * width;
            int b = width * height;
            int c = height * length;

            // Find the side with the smallest area
            int minArea = Math.Min(a, Math.Min(b, c));

            return 2 * (a + b + c) + minArea;
        }

        // Ribbon required calculated as:
        // The perimeter of the 2 shortest sides a and b = (2 * (a + b)) 
        // plus the cubic volume of the present (l * w * h)
        private static int GetRibbonLength(int length, int width, int height)
        {
            List<int> sides = new List<int> { length, width, height };
            sides.Sort();
            return 2 * (sides[0] + sides[1]) + (length * width * height);
        }
    }
}
