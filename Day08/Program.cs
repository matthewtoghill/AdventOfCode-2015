using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day08
{
    class Program
    {
        private static readonly string[] input = File.ReadAllLines(@"..\..\..\data\day08.txt");
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            int codeCharCount = input.Sum(w => w.Length);
            int decodedCharCount = input.Sum(w => Regex.Replace(w.Trim('"').Replace("\\\"", "A").Replace("\\\\", "B"), @"\\x..", "C").Length);
            Console.WriteLine($"Part 1: {codeCharCount - decodedCharCount}");
        }

        private static void Part2()
        {
            int codeCharCount = input.Sum(w => w.Length);
            int encodedCharCount = input.Sum(w => w.Replace("\\", "AA").Replace("\"", "BB").Length + 2);
            Console.WriteLine($"Part 2: {encodedCharCount - codeCharCount}");
        }
    }
}
