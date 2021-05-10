using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Part1();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            Part2();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        private static void Part1()
        {
            string key = "bgvyzdsv";
            MD5 md5 = MD5.Create();
            int val = 0;

            while (true)
            {
                // Get a byte array from the MD5 hashing algorith using the key + val input string
                byte[] hashBytes = CreateMD5HashBytes(ref md5, string.Format(key + val));

                // Each item within the byte array can be parsed back to 2 characters of a hex string
                // Only need to check the first 5 characters, so get the first 6 characters of the hash string from the first 3 array values
                string hash = ByteArrayToString(hashBytes, 3);

                if (hash.Substring(0, 5) == "00000")
                {
                    Console.WriteLine($"Part 1: {val} = {hash}");
                    break;
                }
                val++;
            }
        }

        private static void Part2()
        {
            string key = "bgvyzdsv";
            MD5 md5 = MD5.Create();
            int val = 0;

            while (true)
            {
                // Get a byte array from the MD5 hashing algorith using the key + val input string
                byte[] hashBytes = CreateMD5HashBytes(ref md5, string.Format(key + val));

                // Each item within the byte array can be parsed back to 2 characters of a hex string
                // Only need to check the first 6 characters, so get the first 6 characters of the hash string from the first 3 array values
                string hash = ByteArrayToString(hashBytes, 3);

                if (hash == "000000")
                {
                    Console.WriteLine($"Part 2: {val} = {hash}");
                    break;
                }
                val++;
            }
        }

        private static byte[] CreateMD5HashBytes(string input)
        {
            MD5 md5 = MD5.Create();
            return CreateMD5HashBytes(ref md5, input);
        }

        private static byte[] CreateMD5HashBytes(ref MD5 md5, string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return hashBytes;
        }

        private static string ByteArrayToString(byte[] array)
        {
            return ByteArrayToString(array, array.Length);
        }

        private static string ByteArrayToString(byte[] array, int arrayItemsToConvert)
        {
            if (array.Length < arrayItemsToConvert) arrayItemsToConvert = array.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrayItemsToConvert; i++)
            {
                sb.Append(array[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
