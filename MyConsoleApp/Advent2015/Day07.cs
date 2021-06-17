using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Advent2015
{
    class Advent07
    {
        public class Gate
        {
            public string _inputA;
            public string _inputB;
            public string _logicGate;
            public string _output;

            public string InputA // property
            {
                get { return _inputA; } // get method
                set { _inputA = value; } // set method
            }

            public string InputB // property
            {
                get { return _inputB; } // get method
                set { _inputB = value; } // set method
            }

            public string LogicGate
            {
                get { return _logicGate; }
                set { _logicGate = value; }
            }

            public string Output
            {
                get { return _output; }
                set { _output = value; }
            }

            public Gate(string InputA, string InputB, string LogicGate, string Output)
            {
                _inputA = InputA;
                _inputB = InputB;
                _logicGate = LogicGate;
                _output = Output;
            }
        }

        public static void Day07()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 07");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read File
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-07.txt";
            string dataSet = @"";
            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);

            //dataSet = @"123 -> x
            //NOT x -> h
            //x AND y -> d
            //y RSHIFT 2 -> g
            //456 -> y
            //x OR y -> e
            //NOT y -> i
            //x LSHIFT 2 -> f";

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            // AND &
            // OR |
            // lshift <<
            // rshift >>
            // Not ~

            List<Gate> instructions = new List<Gate>();

            foreach (string item in rawEntries)
            {
                string[] items = item.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string target = items[items.Length - 1];
                // maybe add if doesn't exist? 
                if (items.Length == 3)  // Set Value
                {
                    instructions.Add(new Gate(
                        items[0],
                        null,
                        "SET",
                        items[2]
                    ));
                }
                if (items.Length == 4)  // NOT
                {
                    instructions.Add(new Gate(
                        items[1],
                        null,
                        "NOT",
                        items[3]
                    ));
                }
                if (items.Length == 5)  // Operation of 2 values
                {
                    instructions.Add(new Gate(
                        items[0],
                        items[2],
                        items[1],
                        items[4]
                    ));
                }
            }

            //dataSet = @"123 -> x
            //456 -> y
            //x AND y -> d
            //x OR y -> e
            //x LSHIFT 2 -> f
            //y RSHIFT 2 -> g
            //NOT x -> h
            //NOT y -> i";

            List<Gate> instructionsPart2 = new List<Gate>(instructions);

            #region Part 1         
            Dictionary<string, UInt16> circuit = new Dictionary<string, UInt16>();
            while (instructions.Count > 0)
            {
                foreach (Gate item in instructions)
                {
                    if (item.LogicGate == "SET")  // Set Value
                    {
                        int source1 = 0;
                        bool notPresent = true;
                        if (int.TryParse(item.InputA, out _))
                        {
                            source1 = int.Parse(item.InputA);
                        }
                        else if (circuit.ContainsKey(item.InputA))
                        {
                            source1 = circuit[item.InputA];
                        }
                        else
                        {
                            notPresent = false;
                        }

                        if (notPresent)
                        {
                            circuit[item.Output] = (UInt16)source1;
                            instructions.Remove(item);
                            break;
                        }

                    }
                    else if (item.LogicGate == "NOT")  // NOT
                    {
                        int source1 = 0;
                        bool notPresent = true;
                        if (int.TryParse(item.InputA, out _))
                        {
                            source1 = UInt16.Parse(item.InputA);
                        }
                        else if (circuit.ContainsKey(item.InputA))
                        {
                            source1 = circuit[item.InputA];
                        }
                        else
                        {
                            notPresent = false;
                        }
                        if (notPresent)
                        {
                            circuit[item.Output] = (UInt16)~source1;
                            instructions.Remove(item);
                            break;
                        }
                    }
                    else  // Operation of 2 values
                    {
                        string sourceLeft = item.InputA;
                        string sourceRight = item.InputB;
                        string instruction = item.LogicGate;
                        int source1 = 0;
                        int source2 = 0;
                        bool notPresent = true;
                        // 1 AND io -> ip
                        if (int.TryParse(item.InputA, out _))
                        {
                            source1 = int.Parse(sourceLeft);
                        }
                        else if (circuit.ContainsKey(sourceLeft))
                        {
                            source1 = circuit[sourceLeft];
                        }
                        else
                        {
                            notPresent = false;
                        }

                        if (int.TryParse(sourceRight, out _))
                        {
                            source2 = int.Parse(sourceRight);
                        }
                        else if (circuit.ContainsKey(sourceRight))
                        {
                            source2 = circuit[sourceRight];
                        }
                        else
                        {
                            notPresent = false;
                        }

                        if (notPresent)
                        {
                            if (instruction == "LSHIFT")
                            {
                                circuit[item.Output] = (UInt16)(source1 << source2);
                            }
                            if (instruction == "RSHIFT")
                            {
                                circuit[item.Output] = (UInt16)(source1 >> source2);
                            }

                            if (instruction == "AND")
                            {
                                circuit[item.Output] = (UInt16)(source1 & source2);
                            }
                            if (instruction == "OR")
                            {
                                circuit[item.Output] = (UInt16)(source1 | source2);
                            }
                            instructions.Remove(item);
                            break;
                        }

                    }
                }
            }


            // d: 72
            // e: 507
            // f: 492
            // g: 114
            // h: 65412
            // i: 65079
            // x: 123
            // y: 456

            sw.Stop();
            // Write Result
            Console.WriteLine("Power Value to A {0}", circuit["a"]);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #endregion

            #region Part 2
            sw.Restart();

            foreach (var item in instructionsPart2)
            {
                if (item.InputA == "b") item.InputA = circuit["a"].ToString();
                if (item.InputB == "b") item.InputB = circuit["a"].ToString();
                if (item.Output == "b") item.Output = circuit["a"].ToString();
            }


            Dictionary<string, UInt16> circuit2 = new Dictionary<string, UInt16>();
            while (instructionsPart2.Count > 0)
            {
                foreach (Gate item in instructionsPart2)
                {
                    if (item.LogicGate == "SET")  // Set Value
                    {
                        int source1 = 0;
                        bool notPresent = true;
                        if (int.TryParse(item.InputA, out _))
                        {
                            source1 = int.Parse(item.InputA);
                        }
                        else if (circuit2.ContainsKey(item.InputA))
                        {
                            source1 = circuit2[item.InputA];
                        }
                        else
                        {
                            notPresent = false;
                        }

                        if (notPresent)
                        {
                            circuit2[item.Output] = (UInt16)source1;
                            instructionsPart2.Remove(item);
                            break;
                        }

                    }
                    else if (item.LogicGate == "NOT")  // NOT
                    {
                        int source1 = 0;
                        bool notPresent = true;
                        if (int.TryParse(item.InputA, out _))
                        {
                            source1 = UInt16.Parse(item.InputA);
                        }
                        else if (circuit2.ContainsKey(item.InputA))
                        {
                            source1 = circuit2[item.InputA];
                        }
                        else
                        {
                            notPresent = false;
                        }
                        if (notPresent)
                        {
                            circuit2[item.Output] = (UInt16)~source1;
                            instructionsPart2.Remove(item);
                            break;
                        }
                    }
                    else  // Operation of 2 values
                    {
                        string sourceLeft = item.InputA;
                        string sourceRight = item.InputB;
                        string instruction = item.LogicGate;
                        int source1 = 0;
                        int source2 = 0;
                        bool notPresent = true;
                        // 1 AND io -> ip
                        if (int.TryParse(item.InputA, out _))
                        {
                            source1 = int.Parse(sourceLeft);
                        }
                        else if (circuit2.ContainsKey(sourceLeft))
                        {
                            source1 = circuit2[sourceLeft];
                        }
                        else
                        {
                            notPresent = false;
                        }

                        if (int.TryParse(sourceRight, out _))
                        {
                            source2 = int.Parse(sourceRight);
                        }
                        else if (circuit2.ContainsKey(sourceRight))
                        {
                            source2 = circuit2[sourceRight];
                        }
                        else
                        {
                            notPresent = false;
                        }

                        if (notPresent)
                        {
                            if (instruction == "LSHIFT")
                            {
                                circuit2[item.Output] = (UInt16)(source1 << source2);
                            }
                            if (instruction == "RSHIFT")
                            {
                                circuit2[item.Output] = (UInt16)(source1 >> source2);
                            }

                            if (instruction == "AND")
                            {
                                circuit2[item.Output] = (UInt16)(source1 & source2);
                            }
                            if (instruction == "OR")
                            {
                                circuit2[item.Output] = (UInt16)(source1 | source2);
                            }
                            instructionsPart2.Remove(item);
                            break;
                        }

                    }
                }
            }

            sw.Stop();
            // Write Result
            Console.WriteLine("Power Value to A {0}", circuit2["a"]);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
            #endregion
        }

    }
}
