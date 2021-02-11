using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Advent2020
{
    public class Day09_Dataports
    {
        public class Entry
        {
            public int index;
            public string action;
            public string sign;
            public int shift;

            public int Index // property
            {
                get { return index; } // get method
                set { index = value; } // set method
            }

            public string Action // property
            {
                get { return action; } // get method
                set { action = value; } // set method
            }

            public string Sign // property
            {
                get { return sign; } // get method
                set { sign = value; } // set method
            }

            public int Shift
            {
                get { return shift; }
                set { shift = value; }
            }

            public Entry(int Index, string Action, string Sign, int Shift)
            {
                index = Index;
                action = Action;
                sign = Sign;
                shift = Shift;
            }
        }
        public static bool Day09()
        {
            Console.WriteLine("Starting Advent of Code Day 09");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day09.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            List<int> allValues = new List<int>();

            //Console.WriteLine(maxloop);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            List<double> entries = new List<double>();
            int iCount = 0;

            // seperate Data into List/array/class etc
            foreach (var raw in rawEntries)
            {
                double entry = double.Parse(raw);
                entries.Add(entry);
                iCount++;
            }
            //Console.WriteLine(iCount);
            // Loop through program... 

            int start = 1;
            int end = 25;
            int target = 26;

            double conX = 0;
            double conY = 0;

            int i = 26;
            while (i < iCount + 1)
            {
                bool check = false;
                for (int x = start; x < end + 1; x++)
                {
                    for (int y = start; y < end + 1; y++)
                    {
                        if (entries[x] + entries[y] == entries[target])
                        {
                            //Console.WriteLine(entries[x] + " + " + entries[y] + " = " + entries[target]);
                            check = true;
                            conX = entries[x];
                            conY = entries[y];
                        }
                    }
                }

                if (!check)
                {
                    Console.WriteLine("Target Failed: " + entries[target]);
                    int begin = 1;
                    for (int z = begin; z < iCount + 1; z++)
                    {
                        double sum = 0;
                        List<double> current = new List<double>();
                        while (sum <= entries[target])
                        {
                            for (int cur = z; cur < target; cur++)
                            {
                                sum += entries[cur];
                                //Console.WriteLine("Adding: " + entries[cur] + " = " + sum);
                                current.Add(entries[cur]);
                                if (sum == entries[target])
                                {
                                    Console.WriteLine("Found it! Min is " + current.Min() + " and Max is " + current.Max() + " summing to " + (current.Min() + current.Max()));
                                    z = iCount + 1;
                                    cur = target;
                                    break;
                                }
                            }
                        }
                    }
                }
                start++;
                end++;
                target++;
                i++;
            }

            Console.WriteLine("\r\nGoodbye World");
            return true;
        }
    }
}
