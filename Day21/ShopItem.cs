using System.Collections.Generic;

namespace Day21
{
    public class ShopItem
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Damage { get; set; }
        public int Armour { get; set; }

        public ShopItem(string name, int cost, int damage, int armour)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            Armour = armour;
        }
    }

    public class ShopRepository
    {
        public List<ShopItem> Weapons { get; set; }
        public List<ShopItem> Armour { get; set; }
        public List<ShopItem> Rings { get; set; }

        public ShopRepository()
        {
            // All Weapons
            Weapons = new List<ShopItem>()
            {
                new ShopItem("Dagger", 8, 4, 0),
                new ShopItem("Shortsword", 10, 5, 0),
                new ShopItem("Warhammer", 25, 6, 0),
                new ShopItem("Longsword", 40, 7, 0),
                new ShopItem("Greataxe", 74, 8, 0)
            };

            // All Armour, including option for No Armour
            Armour = new List<ShopItem>() {
                new ShopItem("No Armour", 0, 0, 0),
                new ShopItem("Leather", 13, 0, 1),
                new ShopItem("Chainmail", 31, 0, 2),
                new ShopItem("Splintmail", 53, 0, 3),
                new ShopItem("Bandedmail", 75, 0, 4),
                new ShopItem("Platemail", 102, 0, 5)
            };

            // All Rings, including options for No Ring 1 or 2
            Rings = new List<ShopItem>() {
                new ShopItem("No Ring 1", 0, 0, 0),
                new ShopItem("No Ring 2", 0, 0, 0),
                new ShopItem("Damage +1", 25, 1, 0),
                new ShopItem("Damage +2", 50, 2, 0),
                new ShopItem("Damage +3", 100, 3, 0),
                new ShopItem("Defense +1", 20, 0, 1),
                new ShopItem("Defense +2", 40, 0, 2),
                new ShopItem("Defense +3", 80, 0, 3)
            };
        }
    }
}
