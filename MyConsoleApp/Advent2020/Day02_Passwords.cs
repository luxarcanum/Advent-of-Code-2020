using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Advent2020
{
    public class Day02_Passwords
    {
        public class Entry
        {
            public int iMin;
            public int iMax;
            public string iReq;
            public string iPass;

            public int IMin // property
            {
                get { return iMin; } // get method
                set { iMin = value; } // set method
            }

            public int IMax // property
            {
                get { return iMax; } // get method
                set { iMax = value; } // set method
            }

            public string IReq
            {
                get { return iReq; }
                set { iReq = value; }
            }

            public string IPass
            {
                get { return iPass; }
                set { iPass = value; }
            }

            public Entry(int IMin, int IMax, string IReq, string IPass)
            {
                iMin = IMin;
                iMax = IMax;
                iReq = IReq;
                iPass = IPass;
            }
        }
        public static bool Day02()
        {
            Console.WriteLine("Starting Advent of Code Day 02");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day02.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            List<Entry> Entries = new List<Entry>();
            int iCount = 0;

            // seperate Data into List/array/class etc
            foreach (string raw in rawEntries)
            {
                // 11-12 s: sssssqsslsvhfs
                string[] lines = raw.Split(new string[] { "-", " ", ":" }, StringSplitOptions.RemoveEmptyEntries);
                int min = int.Parse(lines[0]);
                int max = int.Parse(lines[1]);
                string req = lines[2].ToString();
                string pas = lines[3].ToString();

                Entries.Add(new Entry(min, max, req, pas));
                iCount++;
            }

            int count = 0;
            int occur = 0;
            foreach (Entry i in Entries)
            {
                occur = i.iPass.Count(x => x.ToString() == i.iReq);
                if (occur >= i.iMin && occur <= i.iMax)
                {
                    count++;
                }
            }
            Console.WriteLine("Count of valid entries Part 1: " + count);
            // extra for part 2
            count = 0;
            foreach (Entry i in Entries)
            {
                int test = 0;
                if (i.iPass[(i.iMin - 1)].ToString() == i.iReq) { test++; }
                if (i.iPass[(i.iMax - 1)].ToString() == i.iReq) { test++; }
                if (test == 1) { count++; }
            }
            Console.WriteLine("Count of valid entries Part 2: " + count);

            return true;
        }
    }
}
