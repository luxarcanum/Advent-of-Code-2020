using System;
using System.Collections.Generic;

namespace MyConsoleApp.Advent2020
{
    public class Day11_AirportSeats
    {
        public static bool Day11()
        {
            Console.WriteLine("Starting Advent of Code Day 11");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day11.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            dataSet = @"";
            dataSet = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

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
