using System.Collections.Generic;

namespace Day13
{
    public class Attendee
    {
        public string Name { get; set; }
        public Dictionary<string, int> Relatives { get; set; } = new Dictionary<string, int>();

        public Attendee(string name) => Name = name;

        public void AddRelative(string name, int score) => Relatives.Add(name, score);

        public int GetScoreFor(string name)
        {
            Relatives.TryGetValue(name, out int score);
            return score;
        }
    }
}
