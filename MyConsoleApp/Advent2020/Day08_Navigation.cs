using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Advent2020
{
    public class Day08_Navigation
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
        public static bool Day08()
        {
            Console.WriteLine("Starting Advent of Code Day 08");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day08.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            List<int> allValues = new List<int>();

            for (int maxloop = 0; maxloop < 626; maxloop++)
            {
                //Console.WriteLine(maxloop);

                string[] fullEntryDiv = { "\n" };
                string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

                List<Entry> entries = new List<Entry>();
                int iCount = 0;

                // seperate Data into List/array/class etc
                foreach (var raw in rawEntries)
                {
                    string act = raw.Trim().Substring(0, 3);
                    string sign = raw.Trim().Substring(4, 1);
                    int len = raw.Trim().Length;
                    int nCount = len - 5;
                    int modifier = Int32.Parse(raw.Trim().Substring(len - nCount, nCount));

                    if (iCount == maxloop && act == "nop") { act = "jmp"; }
                    if (iCount == maxloop && act == "jmp") { act = "nop"; }

                    entries.Add(new Entry(iCount, act, sign, modifier));
                    iCount++;
                }
                //Console.WriteLine(iCount);
                // Loop through program... 

                List<int> used = new List<int>();
                int result = 0;
                //used.Add(8);

                int i = 0;
                while (!used.Contains(i))
                {
                    var entry = entries.Where(x => x.Index == i);
                    string action = entry.Select(x => x.Action).First().ToString();
                    string sign = entry.Select(x => x.Sign).First().ToString();
                    int mod = entry.Select(x => x.Shift).First();
                    int index = i;

                    if (action == "nop")
                    {
                        used.Add(i);
                        i++;
                    }
                    else if (action == "acc")
                    {
                        if (sign == "+")
                        {
                            result = (result + mod);
                        }
                        else
                        {
                            result = (result - mod);
                        }
                        used.Add(i);
                        i++;
                    }
                    else if (action == "jmp")
                    {
                        used.Add(i);
                        if (sign == "+")
                        {
                            i = (i + mod);
                        }
                        else
                        {
                            i = (i - mod);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Panic");
                        break;
                    }

                    if (i == iCount)
                    {
                        Console.WriteLine("Proper Exit");
                        Console.WriteLine("Accumulator: " + result);
                        break;
                    }
                }
                allValues.Add(result);
                //Console.WriteLine("Accumulator: " + result);
            }

            Console.WriteLine("\r\nGoodbye World");

            return true;
        }
    }
}
