using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Advent2015
{
    class Advent14
    {

        public static void Day14()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 14");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read Input
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-14.txt";
            string dataSet = @"";
            List<Tuple<int, int, int>> rdData = new List<Tuple<int, int, int>>();


            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in rawEntries)
            {
                string[] items = item.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                rdData.Add(new Tuple<int, int, int>(
                    int.Parse(items[3]),
                    int.Parse(items[6]),
                    int.Parse(items[13])
                    ));
            }

            #region Part 1         
            foreach (Tuple<int, int, int> reindeer in rdData)
            {
                for (int i = 0; i < 2503; i++)
                {

                }
            }


            sw.Stop();
            // Write Result
            Console.WriteLine("Answer to Part 1 {0}", 1);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #endregion

            #region Part 2
            sw.Restart();

            sw.Stop();
            // Write Result
            Console.WriteLine("Answer to Part 2 {0}", 2);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
            #endregion
        }





    }
}
