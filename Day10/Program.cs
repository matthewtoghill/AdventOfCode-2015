using System;
using System.Text;

namespace Day10
{
    class Program
    {
        static void Main()
        {
            string sequence = LookAndSayGame("1113122113", 40);
            Console.WriteLine($"Part 1: {sequence.Length}");

            sequence = LookAndSayGame(sequence, 10);
            Console.WriteLine($"Part 2: {sequence.Length}");
        }

        private static string LookAndSayGame(string sequence, int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                int countCurrent = 0;
                char currentNum = sequence[0];
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < sequence.Length; j++)
                {
                    if (sequence[j] == currentNum)
                    {
                        countCurrent++;
                    }
                    else
                    {
                        sb.Append(countCurrent.ToString() + currentNum);
                        currentNum = sequence[j];
                        countCurrent = 1;
                    }
                }

                sb.Append(countCurrent.ToString() + currentNum);
                sequence = sb.ToString();
            }

            return sequence;
        }
    }
}
