using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Day18
{
    class Program
    {
        private static readonly string[] input = File.ReadAllLines(@"..\..\..\data\day18.txt");
        private static readonly (int x, int y)[] directions = { (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1) };
        private static string[] currentLightGrid;
        private static int maxRows, maxCols;
        static void Main()
        {

            // Part 1
            PlayLightGrid(100, false);
            Console.WriteLine($"Part 1: {currentLightGrid.Sum(s => s.Count(c => c == '#'))}");

            // Part 2
            PlayLightGrid(100, true);
            Console.WriteLine($"Part 2: {currentLightGrid.Sum(s => s.Count(c => c == '#'))}");
        }

        private static void PlayLightGrid(int steps, bool cornersAlwaysOn)
        {
            // Set grid to initial state
            currentLightGrid = input.ToArray();

            // Set corner lights as ON if required
            if (cornersAlwaysOn)
            {
                currentLightGrid[0] = currentLightGrid[0].ReplaceAtIndex(0, '#').ReplaceAtIndex(maxCols - 1, '#');
                currentLightGrid[maxRows - 1] = currentLightGrid[maxRows - 1].ReplaceAtIndex(0, '#').ReplaceAtIndex(maxCols - 1, '#');
            }

            // Get max row and columns from array lengths
            maxRows = currentLightGrid.Length;
            maxCols = currentLightGrid[0].Length;

            // Run the Light Grid changes the required number of steps
            for (int i = 0; i < steps; i++)
            {
                // Initialise the next grid state by starting with the current grid state
                string[] nextGrid = currentLightGrid.ToArray();

                // Iterate each row and column
                for (int row = 0; row < nextGrid.Length; row++)
                {
                    for (int col = 0; col < nextGrid[row].Length; col++)
                    {
                        // Get the number of neighbour lights that are ON for the current light
                        int countOn = CountStateOfNeighbours(row, col, '#');
                        char thisLight = currentLightGrid[row][col];

                        // Light is currently ON and does not have 2 or 3 ON neighbours, switch OFF
                        if (thisLight == '#' && (!(countOn == 2 || countOn == 3)))
                            nextGrid[row] = nextGrid[row].ReplaceAtIndex(col, '.');

                        // Light is currently OFF and has 3 ON neighbours, switch ON
                        if (thisLight == '.' && countOn == 3)
                            nextGrid[row] = nextGrid[row].ReplaceAtIndex(col, '#');
                    }
                }

                // Set corner lights as ON if required
                if (cornersAlwaysOn)
                {
                    nextGrid[0] = nextGrid[0].ReplaceAtIndex(0, '#').ReplaceAtIndex(maxCols - 1, '#');
                    nextGrid[maxRows - 1] = nextGrid[maxRows - 1].ReplaceAtIndex(0, '#').ReplaceAtIndex(maxCols - 1, '#');
                }

                // Set the current grid state before the next iteration
                currentLightGrid = nextGrid.ToArray();
            }
        }

        private static int CountStateOfNeighbours(int row, int col, char state)
        {
            int countOn = 0;

            foreach ((int x, int y) in directions)
            {
                int nCol = col + x;
                int nRow = row + y;

                if (nCol < 0 || nCol >= maxCols) continue;
                if (nRow < 0 || nRow >= maxRows) continue;

                if (currentLightGrid[nRow][nCol] == state)
                    countOn++;
            }

            return countOn;
        }
    }

    public static class StringExtensions
    {
        public static string ReplaceAtIndex(this string text, int index, char c)
        {
            StringBuilder sb = new StringBuilder(text);
            sb[index] = c;
            return sb.ToString();
        }
    }
}
