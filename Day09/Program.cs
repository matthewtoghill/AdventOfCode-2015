using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day09
{
    class Program
    {
        private static readonly string[] input = File.ReadAllLines(@"..\..\..\data\day09.txt");
        static void Main()
        {
            BothParts();
        }

        private static void BothParts()
        {
            List<Location> locations = GetLocations(input);

            List<List<Location>> locationPermutations = GetPermutations(locations)
                .Select(l => l.ToList())
                .ToList();

            int minDistance = int.MaxValue;
            int maxDistance = 0;

            foreach (var permutation in locationPermutations)
            {
                int distance = 0;
                for (int i = 0; i < permutation.Count() - 1; i++)
                    distance += permutation[i].GetDistanceTo(permutation[i + 1].Name);

                minDistance = Math.Min(minDistance, distance);
                maxDistance = Math.Max(maxDistance, distance);
            }

            Console.WriteLine($"Part 1: Min Distance: {minDistance}");
            Console.WriteLine($"Part 2: Max Distance: {maxDistance}");
        }

        private static List<Location> GetLocations(string[] locationsData)
        {
            List<Location> locations = new List<Location>();
            foreach (var line in locationsData)
            {
                string[] info = line.Split(new[] { "to", "=", " " }, StringSplitOptions.RemoveEmptyEntries);
                string from = info[0];
                string to = info[1];
                int distance = int.Parse(info[2]);

                Location fromLoc = locations.Find(l => l.Name == from);
                if (fromLoc is null)
                {
                    Location newFromLocation = new Location(from);
                    newFromLocation.AddDestination(to, distance);
                    locations.Add(newFromLocation);
                }
                else
                {
                    fromLoc.AddDestination(to, distance);
                }

                Location toLoc = locations.Find(l => l.Name == to);
                if (toLoc is null)
                {
                    Location newToLocation = new Location(to);
                    newToLocation.AddDestination(from, distance);
                    locations.Add(newToLocation);
                }
                else
                {
                    toLoc.AddDestination(from, distance);
                }
            }
            return locations;
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items)
        {
            if (items.Count() > 1)
                return items.SelectMany(
                     item => GetPermutations(items.Where(i => !i.Equals(item))),
                     (item, permutation) => new[] { item }.Concat(permutation));

            return new[] { items };
        }
    }
}
