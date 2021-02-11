using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Advent2020
{
    public class Day10_AdapaterArray
    {
        public static bool Day10()
        {
            Console.WriteLine("Starting Advent of Code Day 10");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day10.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            //            dataSet = @"28
            //33
            //18
            //42
            //31
            //14
            //46
            //20
            //48
            //47
            //24
            //23
            //49
            //45
            //19
            //38
            //39
            //11
            //1
            //32
            //25
            //35
            //8
            //17
            //7
            //9
            //4
            //2
            //34
            //10
            ////3";

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
            //Console.WriteLine(iCount);
            entries.Add(0);
            entries.Sort();
            entries.Add(entries.Max() + 3);
            entries.Add(entries.Max() + 10);

            List<int> diffs = new List<int>();

            for (int i = 0; i < entries.Count; i++)
            {
                if (i < entries.Count - 1)
                {
                    int diff = entries[i + 1] - entries[i];
                    diffs.Add(diff);
                    Console.WriteLine(entries[i] + " : " + diffs[i]);
                }
            }

            int one = diffs.Where(x => x == 1).Count();
            int two = diffs.Where(x => x == 2).Count();
            int three = diffs.Where(x => x == 3).Count();

            Console.WriteLine(one + " : " + two + " : " + three + " = " + (one * three));

            return true;
        }
    }
}
