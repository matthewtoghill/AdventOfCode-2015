using System;
using System.Collections.Generic;
using System.IO;

namespace Day03
{
    class Program
    {
        private static readonly string input = File.ReadAllText(@"..\..\..\data\day03.txt");
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            Dictionary<(int x, int y), int> housesVisited = new Dictionary<(int x, int y), int>();
            (int x, int y) currentLocation = (0, 0);
            housesVisited.Add(currentLocation, 1);

            foreach (var direction in input)
            {
                currentLocation = GetNewLocation(currentLocation, direction);

                // Create and update a dictionary of the co-ordinates visited
                housesVisited.TryGetValue(currentLocation, out int count);
                housesVisited[currentLocation] = ++count;
            }

            // Return a count of the number of co-ordinates visited more than once
            Console.WriteLine($"Part 1: Total visited: {housesVisited.Count}");
        }

        private static void Part2()
        {
            Dictionary<(int x, int y), int> housesVisited = new Dictionary<(int x, int y), int>();
            (int x, int y) santaLocation = (0, 0);
            (int x, int y) robotLocation = (0, 0);
            bool isRobot = false;

            housesVisited.Add((0, 0), 2);

            foreach (var direction in input)
            {
                // Check if it's the robots turn
                if (isRobot)
                {
                    robotLocation = GetNewLocation(robotLocation, direction);
                    housesVisited.TryGetValue(robotLocation, out int count);
                    housesVisited[robotLocation] = ++count;
                }
                else
                {
                    santaLocation = GetNewLocation(santaLocation, direction);
                    housesVisited.TryGetValue(santaLocation, out int count);
                    housesVisited[santaLocation] = ++count;
                }

                // Flip the robot turn flag
                isRobot = !isRobot;
            }

            // Return a count of the number of co-ordinates visited more than once
            Console.WriteLine($"Part 2: Total visited: {housesVisited.Count}");
        }

        private static (int x, int y) GetNewLocation((int x, int y) currentLocation, char direction)
        {
            switch (direction)
            {
                case '<': currentLocation.x--; break;
                case '>': currentLocation.x++; break;
                case '^': currentLocation.y--; break;
                case 'v': currentLocation.y++; break;
                default: break;
            }
            return (currentLocation.x, currentLocation.y);
        }
    }
}
