using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Advent2023
{
    public class Day01_Trebuchet
    {
        public static bool Day01()
        {
            Console.WriteLine("Starting Advent of Code Day 01");

            string inputFile = @"S:\Advent 2023\input-01.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            #region Part 1
            int CalibrationTotal = 0;

            //seperate Data into List/ array /class etc
            foreach (var raw in rawEntries)
            {
                CalibrationTotal = CalibrationTotal + CalibrationValue(raw);
            }

            Console.WriteLine("CalibrationTotal: " + CalibrationTotal.ToString());
            #endregion

            #region Part2:
            int CalibrationTotalTwo = 0;
            foreach (var raw in rawEntries)
            {
                CalibrationTotalTwo = CalibrationTotalTwo + CalibrationValueTwo(raw);
                //Console.WriteLine("Running Total: " + CalibrationTotalTwo);
            }

            Console.WriteLine("CalibrationTotal: " + CalibrationTotalTwo.ToString());
            #endregion
            return true;
        }

        private static int CalibrationValue(string raw)
        {
            // get indexes
            int x = raw.IndexOfAny("0123456789".ToCharArray());
            int y = raw.LastIndexOfAny("0123456789".ToCharArray());
            //get values from index
            string a = raw[x].ToString();
            string b = raw[y].ToString();
            //add together
            int z = int.Parse(a + b);
            //return calibration value
            //Console.WriteLine("x: {0} + y: {1} = {2}", a, b, z);
            return z;
        }

        private static int CalibrationValueTwo(string raw)
        {
            // get first index and value
            string a = "";
            string b = "";
            string[] stringArray = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            int x = raw.IndexOfAny("0123456789".ToCharArray());

            x = x == -1 ? 1000000 : x;
            int xx = 10000000;
            foreach (string num in stringArray)
            {
                if (raw.Contains(num))
                {
                    int possible = raw.IndexOf(num);
                    xx = int.Min(xx, possible);
                }
            }

            if (xx < x && xx > -1)
            {
                a = FindInt(raw, xx).ToString();
            }
            else
            {
                a = raw[x].ToString();
            }

            
            int y = raw.LastIndexOfAny("0123456789".ToCharArray());
            int yy = -1;
            foreach (string num in stringArray)
            {
                if (raw.Contains(num))
                {
                    int possible = raw.IndexOf(num);
                    yy = int.Max(yy, possible);
                }
            }
            if (yy > y && yy > -1)
            {
                b = FindInt(raw, yy).ToString();
            }
            else
            {
                b = raw[y].ToString();
            }

            //add together
            int z = int.Parse(a + b);
            //return calibration value
            Console.WriteLine("x: {0} + y: {1} = {2}         {3}", a, b, z, raw);
            return z;
        }


        private static int FindInt(string raw, int index)
        {   
            switch (raw.Substring(index, 3))
            {
                case "one": return 1;
                case "two": return 2;
                case "thr": return 3;
                case "fou": return 4;
                case "fiv": return 5;
                case "six": return 6;
                case "sev": return 7;
                case "eig": return 8;
                case "nin": return 9;

                default:
                    return 0;
            }
        }
    }
}
