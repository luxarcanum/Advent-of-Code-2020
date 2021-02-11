using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Advent2020
{
    public class Day05_PlaneSeats
    {
        public class Seat
        {
            public int seatRow;
            public int seatCol;
            public int seatID;

            public int SeatRow // property
            {
                get { return seatRow; } // get method
                set { seatRow = value; } // set method
            }

            public int SeatCol // property
            {
                get { return seatCol; } // get method
                set { seatCol = value; } // set method
            }

            public int SeatID
            {
                get { return seatID; }
                set { seatID = value; }
            }

            public Seat(int SeatRow, int SeatCol, int SeatID)
            {
                seatRow = SeatRow;
                seatCol = SeatRow;
                seatID = SeatRow;
            }
        }
        public static bool Day05()
        {
            Console.WriteLine("Starting Advent of Code Day 05");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day05.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n", " " };
            char[] charsToTrim = { ' ' };
            List<string> passes = new List<string>();
            List<Seat> seats = new List<Seat>();
            List<int> seatIDs = new List<int>();

            int result = 0;

            string[] entries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(entries.Length + " words in text:");

            foreach (string entry in entries)
            {
                //Console.WriteLine(entry.Trim());
                passes.Add(entry.Trim());
            }

            // Loop over string values.
            foreach (string pass in passes)
            {
                char[] bits = pass.ToCharArray();
                double low = 0;
                double top = 127;
                double left = 0;
                double right = 7;

                for (int i = 0; i < 10; i++)
                {
                    if (bits[i] == 'F')
                    {
                        top = top - (Math.Floor((top - low) / 2) + 1);
                    }
                    else if (bits[i] == 'B')
                    {
                        low = low + Math.Ceiling((top - low) / 2);
                    }
                    else if (bits[i] == 'L')
                    {
                        right = right - (Math.Floor((right - left) / 2) + 1);
                    }
                    else if (bits[i] == 'R')
                    { // 'R'
                        left = left + Math.Ceiling((right - left) / 2);

                    }
                }
                seatIDs.Add(Convert.ToInt32(low * 8 + left));
                seats.Add(new Seat(Convert.ToInt32(low), Convert.ToInt32(left), Convert.ToInt32(low * 8 + left)));
                result = (low * 8 + left) > result ? Convert.ToInt32(low * 8 + left) : result;
            }
            Console.WriteLine("Highest Seat ID: " + result);

            // Part B: access (and print) values.
            List<int> allSeats = Enumerable.Range(1, 1000).ToList();

            var setToRemove = new HashSet<int>(seatIDs);
            allSeats.RemoveAll(x => setToRemove.Contains(x));

            //allSeats.ExceptWith(setToRemove);
            allSeats = allSeats.Except(seats.Select(x => x.seatID)).ToList();

            Console.WriteLine("---------------------");
            foreach (int i in allSeats)
            {
                if (allSeats.Contains(i - 1) && allSeats.Contains(i + 1))
                {

                }
                else { Console.WriteLine(i); }
            }




            return true;
        }
    }
}
