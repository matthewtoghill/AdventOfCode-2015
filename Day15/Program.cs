using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    class Program
    {
        private static string[] input = new[]
        {
           "Sprinkles: capacity 5, durability -1, flavor 0, texture 0, calories 5",
           "PeanutButter: capacity -1, durability 3, flavor 0, texture 0, calories 1",
           "Frosting: capacity 0, durability -1, flavor 4, texture 0, calories 6",
           "Sugar: capacity -1, durability 0, flavor 0, texture 2, calories 8"
        };

        static void Main()
        {
            List<Ingredient> ingredients = input.Select(t => new Ingredient(t)).ToList();

            long maxScore = 0, maxScoreCals = 0;

            for (int x = 0; x <= 100; x++)
            {
                for (int y = 0; y <= 100 - x; y++)
                {
                    for (int z = 0; z <= 100 - y - x; z++)
                    {
                        long c = ingredients[0].Capacity * x + ingredients[1].Capacity * y + ingredients[2].Capacity * z + ingredients[3].Capacity * (100 - x - y - z);
                        long d = ingredients[0].Durability * x + ingredients[1].Durability * y + ingredients[2].Durability * z + ingredients[3].Durability * (100 - x - y - z);
                        long f = ingredients[0].Flavor * x + ingredients[1].Flavor * y + ingredients[2].Flavor * z + ingredients[3].Flavor * (100 - x - y - z);
                        long t = ingredients[0].Texture * x + ingredients[1].Texture * y + ingredients[2].Texture * z + ingredients[3].Texture * (100 - x - y - z);

                        long score = c < 0 || d < 0 || f < 0 || t < 0 ? 0 : c * d * f * t;

                        maxScore = Math.Max(score, maxScore);
                        if (score > maxScoreCals)
                        {
                            long calories = ingredients[0].Calories * x + ingredients[1].Calories * y + ingredients[2].Calories * z + ingredients[3].Calories * (100 - x - y - z);
                            if (calories == 500) maxScoreCals = score;
                        }
                    }
                }
            }

            Console.WriteLine($"Part 1: {maxScore}");
            Console.WriteLine($"Part 2: {maxScoreCals}");
        }
    }
}
