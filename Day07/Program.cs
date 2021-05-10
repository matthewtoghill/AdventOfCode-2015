using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
{
    class Program
    {
        private static string[] input = File.ReadAllLines(@"..\..\..\data\day07.txt");
        static void Main(string[] args)
        {
            // Store wires in a dictionary, key is the wire ID
            Dictionary<string, Wire> wires = new Dictionary<string, Wire>();

            // Add all lines to the dictionary
            foreach (var line in input)
            {
                string[] vals = line.Split(new[] { "-> " }, StringSplitOptions.None);
                string wireID = vals[1];
                Wire newWire = new Wire(line);
                wires.Add(wireID, newWire);
            }

            //wires = SolveWires(wires);
            SolveWires(wires);

            Console.WriteLine($"Part 1: a: {wires["a"].Signal}");

            // PART 2 - Set wire b signal to the signal for wire a then solve the wires again:
            var wireASignal = wires["a"].Signal;
            foreach (var wire in wires)
                wire.Value.IsSolved = false;

            wires["b"].SetSignal(wireASignal);

            SolveWires(wires);

            Console.WriteLine($"Part 2: a: {wires["a"].Signal}");
        }

        private static void SolveWires(Dictionary<string, Wire> wires)
        {
            // Queue of wires that are not yet solved
            Queue<Wire> unsolvedWires = new Queue<Wire>(wires.Select(d => d.Value).Where(w => !w.IsSolved));

            // Keep looping through the queue until it is empty
            while (unsolvedWires.Count > 0)
            {
                Wire thisWire = unsolvedWires.Dequeue();

                string[] instruction = thisWire.Instruction.Split(new[] { "->", " " }, StringSplitOptions.RemoveEmptyEntries);

                string source, additionalSource, destination, op;
                int shiftLength;
                bool sourceIsNumber = false;

                switch (instruction.Length)
                {
                    case 2:
                        destination = instruction[1];
                        if (ushort.TryParse(instruction[0], out ushort signal))
                        {
                            wires[destination].SetSignal(signal);
                        }
                        else
                        {
                            source = instruction[0];

                            if (!wires[source].IsSolved)
                            {
                                unsolvedWires.Enqueue(thisWire);
                                continue;
                            }

                            wires[destination].SetSignal(wires[source].Signal);
                        }
                        break;
                    case 3:
                        // NOT operator
                        source = instruction[1];
                        destination = instruction[2];

                        if (!wires[source].IsSolved)
                        {
                            unsolvedWires.Enqueue(thisWire);
                            continue;
                        }

                        wires[destination].SetSignal((ushort)~wires[source].Signal);
                        break;
                    case 4:
                        // OR, AND, LSHIFT, RSHIFT operators
                        source = instruction[0];
                        op = instruction[1];
                        destination = instruction[3];

                        // If the value at index 0 of the instructions is a numeric value instead of a wire id
                        // then use the value as if it were a source signal
                        if (ushort.TryParse(source, out ushort sourceAsValue))
                        {
                            sourceIsNumber = true;
                        }
                        else
                        {
                            if (!wires[source].IsSolved)
                            {
                                unsolvedWires.Enqueue(thisWire);
                                continue;
                            }
                        }

                        switch (op)
                        {
                            case "OR":
                                additionalSource = instruction[2];
                                if (!wires[additionalSource].IsSolved)
                                {
                                    unsolvedWires.Enqueue(thisWire);
                                    continue;
                                }

                                wires[destination].SetSignal((ushort)(wires[source].Signal | wires[additionalSource].Signal));
                                break;

                            case "AND":
                                additionalSource = instruction[2];
                                if (!wires[additionalSource].IsSolved)
                                {
                                    unsolvedWires.Enqueue(thisWire);
                                    continue;
                                }

                                ushort sourceSignal = sourceIsNumber ? sourceAsValue : wires[source].Signal;

                                wires[destination].SetSignal((ushort)(sourceSignal & wires[additionalSource].Signal));
                                break;

                            case "LSHIFT":
                                shiftLength = int.Parse(instruction[2]);
                                wires[destination].SetSignal((ushort)(wires[source].Signal << shiftLength));
                                break;

                            case "RSHIFT":
                                shiftLength = int.Parse(instruction[2]);
                                wires[destination].SetSignal((ushort)(wires[source].Signal >> shiftLength));
                                break;

                            default:
                                Console.WriteLine(op);
                                break;
                        }

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
