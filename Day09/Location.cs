using System.Collections.Generic;

namespace Day09
{
    public class Location
    {
        public string Name { get; set; }
        public Dictionary<string, int> DestinationDistances { get; set; } = new Dictionary<string, int>();

        public Location() { }
        public Location(string name) => Name = name;

        public void AddDestination(string destination, int distance)
        {
            DestinationDistances.Add(destination, distance);
        }

        public int GetDistanceTo(string destination)
        {
            DestinationDistances.TryGetValue(destination, out int distance);
            return distance;
        }
    }
}
