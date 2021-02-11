using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyConsoleApp.Advent2020
{
    public class Dayxx_temp
    {
        public static bool DayXX()
        {
            Console.WriteLine("Starting Advent of Code Day 10");

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
