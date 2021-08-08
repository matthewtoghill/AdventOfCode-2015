using System;

namespace Day19
{
    public class MoleculeReplacement
    {
        public string Replace { get; set; }
        public string Replacement { get; set; }

        public MoleculeReplacement(string rule)
        {
            var temp = rule.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
            Replace = temp[0];
            Replacement = temp[1];
        }
    }
}
