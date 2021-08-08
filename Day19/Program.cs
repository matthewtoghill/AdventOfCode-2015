using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day19
{
    class Program
    {
        private static readonly string[] input = File.ReadAllText(@"..\..\..\data\day19.txt").Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
        private static List<MoleculeReplacement> possibleReplacements = new List<MoleculeReplacement>();
        static void Main()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            // Create list of possible molecule replacements from input data
            possibleReplacements = input[0].Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(line => new MoleculeReplacement(line))
                                           .ToList();

            // The unique list of molecules created
            HashSet<string> molecules = new HashSet<string>();

            // Set the sequence from the input data
            string sequence = input[1].Trim('\n');

            // Loop through the characters of the sequence
            for (int i = 0; i < sequence.Length; i++)
            {
                // Check each of the possible replacements, use Regex to make a single replacement from the character position
                foreach (var mr in possibleReplacements)
                {
                    Regex regex = new Regex(mr.Replace);
                    string newMolecule = regex.Replace(sequence, mr.Replacement, 1, i);

                    // Add the new molecule to the HashSet
                    molecules.Add(newMolecule);
                }
            }

            Console.WriteLine($"Part 1: {molecules.Count - 1}");
        }

        private static void Part2()
        {
            string molecule = input[1].Trim('\n');
            int steps = 0;
            int restarts = 0;

            // Keep looping until the molecule has been reduced back to a single electron
            while (molecule != "e")
            {
                bool madeReplacement = false;

                // Shuffle the list of possible molecule replacements
                possibleReplacements.Shuffle();

                // Iterate through list of possible replacements
                foreach (var mr in possibleReplacements)
                {
                    // Check if the remaining molecule contains the replacement value
                    if (molecule.Contains(mr.Replacement))
                    {
                        // Use Regex to make a single replacement reducing the molecule towards a single electron
                        Regex regex = new Regex(mr.Replacement);
                        molecule = regex.Replace(molecule, mr.Replace, 1);

                        // Update values and break out of the foreach loop
                        steps++;
                        madeReplacement = true;
                        break;
                    }
                }

                // If it was not possible to make a replacement then must have reached a dead end
                if (!madeReplacement)
                {
                    // Reset values for the next iteration of the while loop
                    molecule = input[1].Trim('\n');
                    steps = 0;
                    restarts++;
                }
            }

            Console.WriteLine($"Part 2: {steps} after {restarts} restarts");
        }
    }
}
