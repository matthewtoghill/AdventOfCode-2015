using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day06
{
    class Program
    {
        private static string[] input = File.ReadAllLines(@"..\..\..\data\day06.txt");
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            // Create the grid of lights
            var grid = new Dictionary<(int x, int y), bool>();

            for (int x = 0; x < 1000; x++)
                for (int y = 0; y < 1000; y++)
                    grid.Add((x, y), false);

            foreach (var line in input)
            {
                string[] instructions = line.Replace("turn ", "").Replace("through ", "").Split(' ', ',');
                string action = instructions[0];
                int startX = int.Parse(instructions[1]),
                    startY = int.Parse(instructions[2]),
                    endX = int.Parse(instructions[3]),
                    endY = int.Parse(instructions[4]);

                switch (action)
                {
                    case "on":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[(x, y)] = true;
                        break;

                    case "off":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[(x, y)] = false;
                        break;

                    case "toggle":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[(x, y)] = !grid[(x, y)];
                        break;
                }
            }

            Console.WriteLine($"Part 1: Total Lights on: {grid.Count(light => light.Value == true)}");
        }


        private static void Part2()
        {
            // Create the grid of lights
            var grid = new Dictionary<(int x, int y), int>();

            for (int x = 0; x < 1000; x++)
                for (int y = 0; y < 1000; y++)
                    grid.Add((x, y), 0);

            foreach (var line in input)
            {
                string[] instructions = line.Replace("turn ", "").Replace("through ", "").Split(' ', ',');
                string action = instructions[0];
                int startX = int.Parse(instructions[1]);
                int startY = int.Parse(instructions[2]);
                int endX = int.Parse(instructions[3]);
                int endY = int.Parse(instructions[4]);

                switch (action)
                {
                    case "on":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[(x, y)]++;
                        break;

                    case "off":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                if (grid[(x, y)] > 0) grid[(x, y)]--;
                        break;

                    case "toggle":
                        for (int x = startX; x <= endX; x++)
                            for (int y = startY; y <= endY; y++)
                                grid[(x, y)] += 2;
                        break;
                }
            }

            Console.WriteLine($"Part 2: Total Brightness: {grid.Sum(light => light.Value)}");
        }

    }
}
