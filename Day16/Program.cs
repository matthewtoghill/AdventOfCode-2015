using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day16
{
    class Program
    {
        private static readonly string[] input = File.ReadAllLines(@"..\..\..\data\day16.txt");
        static void Main()
        {
            // Create an instance of the actual sue with fully populated values dictionary
            AuntSue actualSue = new AuntSue("Sue 0: children: 3, cats: 7, samoyeds: 2, pomeranians: 3, akitas: 0, " +
                                            "vizslas: 0, goldfish: 5, trees: 3, cars: 2, perfumes: 1");

            // Create list of Possible Aunt Sues from input data
            List<AuntSue> possibleSues = input.Select(line => new AuntSue(line)).ToList();

            // Get a list of any Aunt Sues that meet the validation for Part 1
            List<AuntSue> validSuesPart1 = possibleSues.Where(s => IsPart1Match(s, actualSue)).ToList();

            // Output Part 1 Result
            validSuesPart1.ForEach(s => Console.WriteLine($"Part 1: {s.ID}"));

            // Get a list of any Aunt Sues that meet the validation for Part 2
            List<AuntSue> validSuesPart2 = possibleSues.Where(s => IsPart2Match(s, actualSue)).ToList();

            // Output Part 2 Result
            validSuesPart2.ForEach(s => Console.WriteLine($"Part 2: {s.ID}"));
        }

        private static bool IsPart1Match(AuntSue possibleSue, AuntSue theSue)
        {
            foreach (var kvp in theSue.Values)
                if (possibleSue.Values.TryGetValue(kvp.Key, out int val))
                    if (val != kvp.Value)
                        return false;

            return true;
        }

        private static bool IsPart2Match(AuntSue possibleSue, AuntSue theSue)
        {
            foreach (var kvp in possibleSue.Values)
            {
                switch (kvp.Key)
                {
                    case "cats":
                    case "trees":
                        if (kvp.Value <= theSue.Values[kvp.Key]) return false;
                        break;
                    case "goldfish":
                    case "pomeranians":
                        if (kvp.Value >= theSue.Values[kvp.Key]) return false;
                        break;
                    default:
                        if (kvp.Value != theSue.Values[kvp.Key]) return false;
                        break;
                }
            }

            return true;
        }
    }
}
