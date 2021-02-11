using System;

namespace MyConsoleApp.Advent2020
{
    public class Day03_Tobbogan
    {
        public static bool Day03()
        {
            Console.WriteLine("Starting Advent of Code Day 03");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day03.txt";
            string dataSet = @"";
            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n", "\r" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            // seperate Data into List/array/class etc
            int rows = rawEntries.GetUpperBound(0) + 1;
            int cols = rawEntries[0].Length;
            int x = 0;
            int y = 0;

            string[,] trees = new string[rows, cols];
            foreach (var row in rawEntries)
            {
                //Console.WriteLine(row);
                x = 0;
                foreach (var item in row.ToCharArray())
                {
                    //Console.WriteLine(item);
                    trees[y, x] = item.ToString();
                    x++;
                }
                y++;
            }

            // Part B: access (and print) values.
            /*      
                Right 1, down 1.
                Right 3, down 1. (This is the slope you already checked.)
                Right 5, down 1.
                Right 7, down 1.
                Right 1, down 2.
                */
            int[] xShift = new int[] { 1, 3, 5, 7, 1 };
            int[] yShift = new int[] { 1, 1, 1, 1, 2 };
            double productTrees = 1;
            for (int runs = 0; runs < 5; runs++)
            {
                x = 0;
                y = 0;
                double hits = 0;
                //int entries = trees.Length;
                int tRows = trees.GetUpperBound(0) + 1;
                int tCols = trees.GetUpperBound(1) + 1;
                int rowLen = trees.Length / (trees.GetUpperBound(0) + 1) - 1;

                //Console.WriteLine(tRows + "-" + tCols + "-" + rowLen);

                for (int i = 0; i < tRows; i++)
                {
                    //Console.WriteLine("Row: (" + y + ") Col: " + x + " contains: ");
                    if (trees[y, x] == "#") { hits++; }
                    x += xShift[runs];
                    y += yShift[runs];
                    if (x > rowLen) { x -= tCols; }
                    if (y > tRows) { break; }
                }

                Console.WriteLine("xShift: {0} yShift: {1} Hit {2}", xShift[runs], yShift[runs], hits);
                productTrees *= hits;
            }
            Console.WriteLine(productTrees);

            return true;
        }
    }
}
