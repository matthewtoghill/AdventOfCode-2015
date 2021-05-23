using System;
using System.IO;

namespace Day06
{
    class Program
    {
        private static string[] input = File.ReadAllLines(@"..\..\..\data\day06.txt");
        static void Main()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            // Create the grid of lights
            bool[,] grid = new bool[1000, 1000];

            foreach (var line in input)
            {
                string[] instruction = line.Replace("turn ", "").Replace("through ", "").Split(' ', ',');
                string action = instruction[0];
                int startX = int.Parse(instruction[1]);
                int startY = int.Parse(instruction[2]);
                int endX = int.Parse(instruction[3]);
                int endY = int.Parse(instruction[4]);

                switch (action)
                {
                    case "on":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[x, y] = true;
                        break;

                    case "off":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[x, y] = false;
                        break;

                    case "toggle":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[x, y] = !grid[x, y];
                        break;
                }
            }

            int total = 0;
            foreach (bool light in grid)
                if (light) total++;

            Console.WriteLine($"Part 1: Total Lights on: {total}");
        }


        private static void Part2()
        {
            // Create the grid of lights
            int[,] grid = new int[1000, 1000];

            foreach (var line in input)
            {
                string[] instruction = line.Replace("turn ", "").Replace("through ", "").Split(' ', ',');
                string action = instruction[0];
                int startX = int.Parse(instruction[1]);
                int startY = int.Parse(instruction[2]);
                int endX = int.Parse(instruction[3]);
                int endY = int.Parse(instruction[4]);

                switch (action)
                {
                    case "on":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[x, y]++;
                        break;

                    case "off":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                if (grid[x, y] > 0)
                                    grid[x, y]--;
                        break;

                    case "toggle":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[x, y] += 2;
                        break;
                }
            }

            int total = 0;
            foreach (int lightBrightness in grid)
                total += lightBrightness;

            Console.WriteLine($"Part 2: Total Brightness: {total}");
        }
    }
}
