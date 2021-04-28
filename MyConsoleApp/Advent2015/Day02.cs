using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent2015
{
    class Advent02
    {
        public class Box
        {
            public int _boxLength;
            public int _boxWidth;
            public int _boxHeight;
            public int _boxSmallest;
            public int _totalArea;

            public int BoxLength // property
            {
                get { return _boxLength; } // get method
                set { _boxLength = value; } // set method
            }

            public int BoxWidth // property
            {
                get { return _boxWidth; } // get method
                set { _boxWidth = value; } // set method
            }

            public int BoxHeight
            {
                get { return _boxHeight; }
                set { _boxHeight = value; }
            }

            public int BoxSmallest
            {
                get { return _boxSmallest; }
                set { _boxSmallest = value; }
            }

            public int TotalArea
            {
                get { return _totalArea; }
                set { _totalArea = value; }
            }

            public Box(int BoxLength, int BoxWidth, int BoxHeight, int BoxSmallest, int TotalArea)
            {
                _boxLength = BoxLength;
                _boxWidth = BoxWidth;
                _boxHeight = BoxHeight;
                _boxSmallest = BoxSmallest;
                _totalArea = TotalArea;
            }
        }

        public static void Day02()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 02");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read File
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-02.txt";
            string dataSet = @"";
            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);
            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);



            List<Box> boxes = new List<Box>();
            int runningTotal = 0;

            // seperate Data into List/array/class etc
            foreach (string box in rawEntries)
            {
                string[] lines = box.Split(new string[] { "x" }, StringSplitOptions.RemoveEmptyEntries);
                int bl = int.Parse(lines[0]);
                int bw = int.Parse(lines[1]);
                int bh = int.Parse(lines[2]);
                int[] sizes = { bl * bw, bw * bh, bh * bl };
                int min = sizes.Min();
                int total = 2 * bl * bw + 2 * bw * bh + 2 * bh * bl + min;
                boxes.Add(new Box(bl, bw, bh, min, total));
                runningTotal += total;
            }

            sw.Stop();
            // Write Result
            Console.WriteLine("Total area is {0}.", runningTotal);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            sw.Restart();
            #region Part 2
            int areaTotal = 0;
            foreach (Box box in boxes)
            {
                int bl = box.BoxLength;
                int bw = box.BoxWidth;
                int bh = box.BoxHeight;
                List<int> sides = new List<int> { bl, bw, bh };
                List<int> sorted = sides.OrderBy(x => x).ToList();
                int ribbon = 2 * sorted[0] + 2 * sorted[1] + bl * bw * bh;
                areaTotal += ribbon;
            }
            sw.Stop();
            // Write Result
            Console.WriteLine("Total Ribbon needed {0}.", areaTotal);

            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #endregion
        }

    }
}
