using System;
using System.Linq;

namespace Day11
{
    class Program
    {
        private static char[] invalidChars = new[] { 'i', 'o', 'l' };

        static void Main()
        {
            string password = "cqjxjnds";

            // Get the next valid password after the input value
            do
            {
                password = IncrementPassword(password);
            } while (!IsValid(password));

            Console.WriteLine($"Part 1: {password}");

            // Get the second valid password
            do
            {
                password = IncrementPassword(password);
            } while (!IsValid(password));

            Console.WriteLine($"Part 2: {password}");
        }

        private static string IncrementPassword(string text)
        {
            char[] chars = text.ToCharArray();
            int index = text.Length - 1;
            while (true)
            {
                if (index < 0) break;
                if (chars[index] < 'z')
                {
                    chars[index]++;
                    break;
                }

                chars[index] = 'a';
                index--;
            }
            return string.Concat(chars);
        }

        private static bool IsValid(string text)
        {
            return ExcludesInvalidChars(text, invalidChars) && IncludesAnIncreasingStraight(text) && IncludesNonOverlappingPairs(text);
        }

        private static bool IncludesAnIncreasingStraight(string text)
        {
            if (text.Length < 3) return false;
            string temp = text.ToLower();
            for (int i = 0; i < temp.Length - 2; i++)
            {
                if (temp[i] == temp[i + 1] - 1 && temp[i + 1] == temp[i + 2] - 1)
                    return true;
            }
            return false;
        }

        private static bool IncludesNonOverlappingPairs(string text)
        {
            int countPairs = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1])
                {
                    countPairs++;
                    i++;
                }
            }

            return countPairs > 1;
        }

        private static bool ExcludesInvalidChars(string text, char[] invalid)
        {
            return !invalid.Any(text.Contains);
        }
    }
}
