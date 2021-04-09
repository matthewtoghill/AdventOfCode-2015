using System;
using System.Security.Cryptography;
using System.Text;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
        private static void Part1()
        {
            string key = "iwrupvqb";
            MD5 md5 = MD5.Create();
            int val = 0;

            while (true)
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(string.Format(key + val));
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                if (sb.ToString().Substring(0, 5) == "00000")
                {
                    Console.WriteLine($"Part 1: {val} = {sb}");
                    break;
                }
                val++;
            }
        }

        private static void Part2()
        {
            string key = "iwrupvqb";
            MD5 md5 = MD5.Create();
            int val = 0;

            while (true)
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(string.Format(key + val));
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                if (sb.ToString().Substring(0, 6) == "000000")
                {
                    Console.WriteLine($"Part 2: {val} = {sb}");
                    break;
                }
                val++;
            }
        }
    }
}
