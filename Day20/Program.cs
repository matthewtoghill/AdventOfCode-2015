using System;
using System.Collections.Generic;

namespace Day20
{
    class Program
    {
        private static readonly int input = 34000000;
        static void Main()
        {
            int houseNum = Part1();
            Part2(houseNum);
        }

        private static int Part1()
        {
            int houseNum = 0;

            // Keep iterating up through house numbers 1 at a time
            while (true)
            {
                houseNum++;

                // Find all divisors and then multiply each by 10 and add the results to get total presents for the house
                List<int> divisors = GetDivisors(houseNum);
                long result = 0;

                foreach (var val in divisors)
                    result += (val * 10);

                // Stop when required number is met
                if (result >= input)
                {
                    Console.WriteLine($"Part 1: House Number {houseNum} with {result:N0} total presents");
                    break;
                }
            }

            return houseNum;
        }

        private static void Part2(int startHouseNum)
        {
            int houseNum = startHouseNum;
            while (true)
            {
                houseNum++;
                List<int> divisors = GetDivisors(houseNum);
                long result = 0;

                // Check if each divisor goes into the house number 50 times or less
                // If it does, multiply by 11 and add the results to get total presents delivered to the house
                foreach (var val in divisors)
                    if ((decimal)houseNum / val <= 50)
                        result += (val * 11);

                // Stop when the required number is met
                if (result >= input)
                {
                    Console.WriteLine($"Part 2: House Number {houseNum} with {result:N0} total presents");
                    break;
                }
            }
        }

        private static List<int> GetDivisors(int n)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    if (n / i == i)
                    {
                        divisors.Add(i);
                    }
                    else
                    {
                        divisors.Add(i);
                        divisors.Add(n / i);
                    }
                }
            }
            return divisors;
        }
    }
}
