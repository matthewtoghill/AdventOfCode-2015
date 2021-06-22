using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace Day12
{
    class Program
    {
        private static readonly string input = File.ReadAllText(@"..\..\..\data\day12.txt");
        static void Main()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            long total = 0;
            using (var reader = new JsonTextReader(new StringReader(input)))
            {
                while (reader.Read())
                    if (reader.TokenType == JsonToken.Integer)
                        total += (long)reader.Value;
            }

            Console.WriteLine($"Part 1: {total}");
        }

        private static void Part2()
        {
            dynamic jsonObject = JsonConvert.DeserializeObject(input);
            long total = SumAllNumbers(jsonObject);
            Console.WriteLine($"Part 2: {total}");
        }

        private static long SumAllNumbers(JObject jsonObject)
        {
            // if the object contains any properties with a value of red then return 0
            if (jsonObject.Properties().Select(prop => prop.Value).OfType<JValue>().Select(val => val.Value).Contains("red"))
                return 0;

            // otherwise sum the child nodes by calling the appropriate method using dynamic dispatch
            return jsonObject.Properties().Sum((dynamic j) => (long)SumAllNumbers(j.Value));
        }

        private static long SumAllNumbers(JArray jsonArray)
        {
            // sum the array items by calling the appropriate method using dynamic dispatch
            return jsonArray.Sum((dynamic j) => (long)SumAllNumbers(j));
        }

        private static long SumAllNumbers(JValue jsonValue)
        {
            // return the value if it is an integer, otherwise return 0
            return jsonValue.Type == JTokenType.Integer ? (long)jsonValue.Value : 0;
        }
    }
}
