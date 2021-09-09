using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day15
{
    class Program
    {
        private static readonly string[] input = File.ReadAllLines(@"..\..\..\data\day15.txt");
        static void Main()
        {
            // Create list of Ingredients from input data
            List<Ingredient> ingredients = input.Select(t => new Ingredient(t)).ToList();

            long maxScore = 0, maxScoreCals = 0;

            // Use nested for loops to calculate all quantity permutations of each ingredient
            // Each permutation must total 100 teaspoons of ingredients
            // x represents the quantity of the 1st Ingredient: Sprinkles
            for (int x = 0; x <= 100; x++)
            {
                // y represents the quantity of the 2nd Ingredient: PeanutButter
                for (int y = 0; y <= 100 - x; y++)
                {
                    // z represents the quantity of the 3rd Ingredient: Frosting
                    // the remaining ingredient Sugar is calculated as (100 - x - y - z)
                    for (int z = 0; z <= 100 - y - x; z++)
                    {
                        int sugarQuantity = 100 - x - y - z;

                        // Calculate scores for each property: Capacity, Durability, Flavour, and Texture
                        // by multiplying each Ingredients respective property by the quantity for the current permutation
                        long c = ingredients[0].Capacity * x + ingredients[1].Capacity * y + ingredients[2].Capacity * z + ingredients[3].Capacity * sugarQuantity;
                        long d = ingredients[0].Durability * x + ingredients[1].Durability * y + ingredients[2].Durability * z + ingredients[3].Durability * sugarQuantity;
                        long f = ingredients[0].Flavour * x + ingredients[1].Flavour * y + ingredients[2].Flavour * z + ingredients[3].Flavour * sugarQuantity;
                        long t = ingredients[0].Texture * x + ingredients[1].Texture * y + ingredients[2].Texture * z + ingredients[3].Texture * sugarQuantity;

                        // Calculate the total score for this permutation by multiplying each score together
                        // if any score is less than 0 then the total score is 0
                        long score = c < 0 || d < 0 || f < 0 || t < 0 ? 0 : c * d * f * t;

                        // Store the Max Score found across all permutations
                        maxScore = Math.Max(score, maxScore);

                        // Store the Max Calories Score across all permutations that have a Calorie score of 500 
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
