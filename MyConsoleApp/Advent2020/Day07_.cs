using System;
using System.Collections.Generic;

namespace MyConsoleApp.Advent2020
{
    public class Day07_temp
    {
        public static bool Day07()
        {
            Console.WriteLine("Starting Advent of Code Day 07");

            string dataSet = @"";
            dataSet = @"";

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

            return true;
        }
    }
}
