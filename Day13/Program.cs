using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13
{
    class Program
    {
        private static readonly string[] input = File.ReadAllLines(@"..\..\..\data\day13.txt");
        static void Main()
        {
            BothParts();
        }

        private static void BothParts()
        {
            // Part 1
            List<Attendee> attendees = GetAttendees(input);
            int maxScore = GetOptimalSeatingScore(attendees);
            Console.WriteLine($"Part 1: Optimal Seating Score: {maxScore}");

            // Part 2
            attendees.ForEach(a => a.AddRelative("Me", 0));                         // Add me as a relative to each attendee
            List<string> attendeeNames = attendees.Select(p => p.Name).ToList();    // Get a list of all attendee names
            Attendee me = new Attendee("Me");                                       // Create an attendee for Me
            attendeeNames.ForEach(r => me.AddRelative(r, 0));                       // Add all relatives to Me
            attendees.Add(new Attendee("Me"));                                      // Add Me to the attendees list

            maxScore = GetOptimalSeatingScore(attendees);
            Console.WriteLine($"Part 2: Optimal Seating Score: {maxScore}");
        }

        private static List<Attendee> GetAttendees(string[] attendeeData)
        {
            List<Attendee> attendees = new List<Attendee>();
            foreach (var line in attendeeData)
            {
                string[] info = line.Split(new[] { "would", "happiness units by sitting next to", ".", " " }, StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int score = int.Parse(info[2]);
                if (info[1] == "lose") score *= -1;
                string relativeName = info[3];

                Attendee attendee = attendees.Find(i => i.Name == name);
                if (attendee is null)
                {
                    Attendee newAttendee = new Attendee(name);
                    newAttendee.AddRelative(relativeName, score);
                    attendees.Add(newAttendee);
                }
                else
                {
                    attendee.AddRelative(relativeName, score);
                }
            }

            return attendees;
        }

        private static int GetOptimalSeatingScore(List<Attendee> attendees)
        {
            List<List<Attendee>> seatingPermutations = GetPermutations(attendees).Select(p => p.ToList()).ToList();
            int maxScore = 0;

            foreach (var permutation in seatingPermutations)
            {
                int happinessScore = 0;
                int neighbourIndex = 0;
                int seatCount = permutation.Count();

                for (int i = 0; i < seatCount; i++)
                {
                    // Get Score for seat to the right
                    neighbourIndex = (i + 1) % seatCount;
                    happinessScore += permutation[i].GetScoreFor(permutation[neighbourIndex].Name);

                    // Get Score for seat to the left
                    neighbourIndex = i > 0 ? i - 1 : seatCount - 1;
                    happinessScore += permutation[i].GetScoreFor(permutation[neighbourIndex].Name);
                }

                maxScore = Math.Max(maxScore, happinessScore);
            }

            return maxScore;
        }


        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items)
        {
            if (items.Count() > 1)
                return items.SelectMany(
                     item => GetPermutations(items.Where(i => !i.Equals(item))),
                     (item, permutation) => new[] { item }.Concat(permutation));

            return new[] { items };
        }
    }
}
