using System;
using System.Collections.Generic;

namespace MyConsoleApp.Advent2020
{
    public class Day01_Expenses
    {
        public static bool Day01()
        {
            Console.WriteLine("Starting Advent of Code Day 01");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day01.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            List<int> entries = new List<int>();
            int iCount = 0;

            // seperate Data into List/array/class etc
            foreach (var raw in rawEntries)
            {
                int entry = int.Parse(raw);
                entries.Add(entry);
                iCount++;
            }

            // Start of solution
            foreach (var x in entries)
            {
                foreach (var y in entries)
                {
                    if ((x + y) == (int)2020)
                    {
                        Console.WriteLine(x + "+" + y + "=" + (x + y) + " and a Product of " + (x * y));
                        goto Part2;
                    }
                }
            }
        Part2:

            foreach (var x in entries)
            {
                foreach (var y in entries)
                {
                    foreach (var z in entries)
                    {
                        if ((x + y + z) == (int)2020)
                        {
                            Console.WriteLine(x + "+" + y + "+" + z + "=" + (x + y + z) + " and a Product of " + (x * y * z));
                            goto End;
                        }
                    }
                }
            }

        End:
            return true;
        }
    }
}
