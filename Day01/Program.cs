using System;
using System.IO;
using System.Linq;

namespace Day01
{
    class Program
    {
        private static readonly string input = File.ReadAllText(@"..\..\..\data\day01.txt");
        static void Main(string[] args)
        {
            Part1();
            Part2();
            Console.ReadLine();
        }

        private static void Part1()
        {
            int countUp = input.Count(c => c == '(');
            int countDown = input.Count(c => c == ')');

            Console.WriteLine($"Up: {countUp} Down: {countDown}");
            Console.WriteLine($"Final Floor: {countUp - countDown}");
        }

        private static void Part2()
        {
            int currentFloor = 0;
            for (int i = 0; i < input.Length; i++)
            {
                currentFloor += input[i] == '(' ? 1 : input[i] == ')' ? -1 : 0;
                if (currentFloor < 0)
                {
                    Console.WriteLine($"First entered Basement Floor {currentFloor} at position {i + 1}");
                    return;
                }
            }
        }
    }
}
