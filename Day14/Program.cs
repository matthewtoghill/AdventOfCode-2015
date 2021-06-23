using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14
{
    class Program
    {
        private static readonly string[] input = File.ReadAllLines(@"..\..\..\data\day14.txt");
        static void Main()
        {
            int totalRunSeconds = 2503;

            // Create the list of reindeer from the input data
            List<Reindeer> reindeer = GetReindeer(input);

            // Run for the required number of seconds
            for (int i = 0; i < totalRunSeconds; i++)
            {
                // Tick 1 second for each reindeer
                reindeer.ForEach(r => r.Tick());

                // Find the current max distance travelled
                int max = reindeer.Max(r => r.DistanceTravelled);

                // Add a point to each reindeer which has travelled the max distance
                foreach (var r in reindeer)
                    if (r.DistanceTravelled == max)
                        r.Points++;
            }

            Console.WriteLine($"Part 1: Furthest: {reindeer.Max(r => r.DistanceTravelled)}");
            Console.WriteLine($"Part 2: Most Points: {reindeer.Max(r => r.Points)}");
        }

        private static List<Reindeer> GetReindeer(string[] reindeerData)
        {
            List<Reindeer> reindeer = new List<Reindeer>();
            foreach (var line in reindeerData)
            {
                string[] info = line.Split();
                string name = info[0];
                int speed = int.Parse(info[3]);
                int duration = int.Parse(info[6]);
                int rest = int.Parse(info[13]);

                reindeer.Add(new Reindeer(name, speed, duration, rest));
            }

            return reindeer;
        }
    }
}
