namespace Day15
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Durability { get; set; }
        public int Flavour { get; set; }
        public int Texture { get; set; }
        public int Calories { get; set; }

        public Ingredient() { }

        public Ingredient(string text)
        {
            var vals = text.Replace(":", "").Replace(",", "").Split();
            Name = vals[0];
            Capacity = int.Parse(vals[2]);
            Durability = int.Parse(vals[4]);
            Flavour = int.Parse(vals[6]);
            Texture = int.Parse(vals[8]);
            Calories = int.Parse(vals[10]);
        }
    }
}
