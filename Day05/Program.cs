using System;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        private static readonly string[] input = File.ReadAllLines(@"..\..\..\data\day05.txt");
        private static string[] invalidCombinations = { "ab", "cd", "pq", "xy" };
        private static char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            int niceTotal = 0;
            foreach (var line in input)
                if (IsPart1NiceString(line)) niceTotal++;

            Console.WriteLine($"Part 1: {niceTotal}");
        }

        private static bool IsPart1NiceString(string text)
        {
            // Must contain at least 3 vowels
            int vowelCount = text.Count(vowels.Contains);
            if (vowelCount < 3) return false;

            // Must contain at least 1 letter that appears twice in a row e.g. xx
            int doubleCount = 0;
            for (int i = 0; i < text.Length - 1; i++)
                if (text[i] == text[i + 1])
                    doubleCount++;

            if (doubleCount == 0) return false;

            // Must not contain the strings ab, cd, pq, or xy
            if (invalidCombinations.Any(text.Contains)) return false;

            return true;
        }

        private static void Part2()
        {
            int niceTotal = 0;
            foreach (var line in input)
                if (IsPart2NiceString(line)) niceTotal++;

            Console.WriteLine($"Part 2: {niceTotal}");
        }

        private static bool IsPart2NiceString(string text)
        {
            // Must contain a pair of any 2 letters that appear at least twice without overlapping
            // e.g. xyxy (xy) or aabcdeaa (aa) but not aaa (aa, but overlaps)
            bool hasRepeatingPair = false;
            for (int i = 0; i < text.Length - 1; i++)
            {
                string thisPair = $"{text[i]}{text[i + 1]}";
                if (text.IndexOf(thisPair, i + 2, StringComparison.Ordinal) != -1)
                {
                    hasRepeatingPair = true;
                    break;
                }
            }

            if (!hasRepeatingPair) return false;

            // Must contain at least 1 letter which repeats with exactly 1 letter between
            // e.g. xyx, abcdefeg (efe), or even aaa (a)
            int repeatWithGapCount = 0;
            for (int i = 0; i < text.Length - 2; i++)
                if (text[i] == text[i + 2])
                    repeatWithGapCount++;

            if (repeatWithGapCount == 0) return false;

            return true;
        }
    }
}
