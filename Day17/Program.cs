using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17
{
    class Program
    {
        private static readonly string[] input = File.ReadAllLines(@"..\..\..\data\day17.txt");
        private static readonly int target = 150;
        static void Main()
        {
            // Populate list of containers from input
            List<int> containers = input.Select(int.Parse).ToList();

            // Get all possible combinations and filter to only include sets that sum to the target
            var combinations = GetPowerSet(containers).Where(c => c.Sum() == target);
            Console.WriteLine($"Part 1: {combinations.Count()}");

            // Find the minimum number of containers required to reach the target, then the number of times this was possible
            int minContainers = combinations.Min(c => c.Count());
            int countOfMin = combinations.Count(c => c.Count() == minContainers);
            Console.WriteLine($"Part 2: {countOfMin}");
        }

        /// <summary>
        /// Get a collection of all combination sets from a given list
        /// Source: https://rosettacode.org/wiki/Power_set#C.23
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        private static IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                       from i in Enumerable.Range(0, list.Count)
                       where (m & (1 << i)) != 0
                       select list[i];
        }
    }
}
