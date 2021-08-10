using System;
using System.Collections.Generic;
using System.Linq;

namespace Day21
{
    class Program
    {
        static void Main()
        {
            ShopRepository shop = new ShopRepository();

            // Create a list of all possible loadout combinations from the shop
            List<List<ShopItem>> loadOuts =
                shop.Weapons.SelectMany(w =>
                    shop.Armour.SelectMany(a =>
                        shop.Rings.SelectMany(r1 =>
                            shop.Rings.Where(r2 => r1 != r2).Select(r2 => new List<ShopItem> { w, a, r1, r2 })))).ToList();

            List<List<ShopItem>> wins = new List<List<ShopItem>>();
            List<List<ShopItem>> losses = new List<List<ShopItem>>();

            // Equip each loadout and simulate the fight
            foreach (var loadOut in loadOuts)
            {
                // Reset player and boss characters
                Character player = new Character("player", 100, 0, 0);
                Character boss = new Character("boss", 109, 8, 2);

                player.Equip(loadOut);

                // Then simulate the boss fight to see if the player wins and store the loadouts as successful or not
                if (Fight(player, boss))
                    wins.Add(loadOut);
                else
                    losses.Add(loadOut);
            }

            Console.WriteLine($"Wins = {wins.Count}");
            Console.WriteLine($"Part 1: {wins.Min(l => l.Sum(i => i.Cost))} was lowest winning cost");

            Console.WriteLine($"\nLosses = {losses.Count}");
            Console.WriteLine($"Part 2: {losses.Max(l => l.Sum(i => i.Cost))} was highest losing cost");
        }

        private static bool Fight(Character player, Character boss)
        {
            while (player.IsAlive)
            {
                // Take turns, player goes first
                player.Attack(boss);

                if (boss.HitPoints <= 0) return true;

                boss.Attack(player);
            }
            return false;
        }
    }
}
