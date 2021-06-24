using System;
using System.Collections.Generic;

namespace Day16
{
    public class AuntSue
    {
        public int ID { get; set; }

        public Dictionary<string, int> Values = new Dictionary<string, int>();

        public AuntSue() { }

        public AuntSue(string data) => Parse(data);

        private void Parse(string data)
        {
            string[] split = data.Split(new[] { ": ", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            ID = int.Parse(split[1]);

            for (int i = 2; i < split.Length - 1; i += 2)
            {
                Values.Add(split[i], int.Parse(split[i + 1]));
            }
        }
    }
}
