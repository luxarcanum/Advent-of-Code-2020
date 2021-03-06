﻿using System;
using System.Collections.Generic;

namespace MyConsoleApp.Advent2020
{
    public class Dayxx_temp
    {
        public static bool DayXX()
        {
            Console.WriteLine("Starting Advent of Code Day 10");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day10.txt";
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

            return true;
        }
    }
}
