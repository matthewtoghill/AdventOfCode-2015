using System;
using System.Collections.Generic;
using System.Linq;

namespace Day21
{
    public class Character
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int Armour { get; set; }
        public bool IsAlive => HitPoints > 0;

        public Character(string name, int hitPoints, int damage, int armour)
        {
            Name = name;
            HitPoints = hitPoints;
            Damage = damage;
            Armour = armour;
        }

        /// <summary>
        /// Attack a specified character <br/>
        /// The defenders hit points are reduced by the attack.
        /// </summary>
        /// <param name="defender">The character being attacked</param>
        public void Attack(Character defender)
        {
            if (defender is null) return;
            int damageDealt = Math.Max(1, this.Damage - defender.Armour);
            defender.HitPoints -= damageDealt;
            //Console.WriteLine($"{this.Name}\tdeals {this.Damage} - {defender.Armour} = {damageDealt}; {defender.Name}\thas {defender.HitPoints} hp");
        }

        /// <summary>
        /// Equip the list of items
        /// </summary>
        /// <param name="items">The list of items to equip</param>
        public void Equip(List<ShopItem> items)
        {
            Armour = items.Sum(i => i.Armour);
            Damage = items.Sum(i => i.Damage);
        }
    }
}
