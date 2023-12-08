using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Advent2023
{
    public class Cubes
    {
        public int Game { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        
        public Cubes() { }
    }

    public class Day02_Cubes
    {
        public static bool Day02()
        {
            Console.WriteLine("Starting Advent of Code Day 02");

            string inputFile = @"S:\Advent 2023\input-02.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            //Game 1: 18 red, 8 green, 7 blue; 15 red, 4 blue, 1 green; 2 green, 17 red, 6 blue; 5 green, 1 blue, 11 red; 18 red, 1 green, 14 blue; 8 blue
            //Game 2: 16 blue, 12 green, 3 red; 13 blue, 2 red, 8 green; 15 green, 3 red, 16 blue

            List<Cubes> entries = new List<Cubes>();
            int iCount = 0;

            // seperate Data into List/array/class etc
            foreach (string raw in rawEntries)
            {   
                //get Game
                string[] lines = raw.Split(new string[] { " ", ":" }, StringSplitOptions.RemoveEmptyEntries);
                int game = int.Parse(lines[1]);
                //for each block
                string[] blocks = raw.Split(new string[] { ":", ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < blocks.Count(); i++)
                {
                    //split into Red Green Blue
                    Dictionary<string, int> pairs = new Dictionary<string, int>();
                    string[] elements = blocks[i].Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                    for (int x = 1; x < elements.Count(); x += 2)
                    {
                        pairs.Add(elements[x], int.Parse(elements[x-1]));
                    }
                    entries.Add(new Cubes()
                    {
                        Game = game,
                        Red = pairs.Where(x => x.Key == "red").Sum(y => y.Value),
                        Green = pairs.Where(x => x.Key == "green").Sum(y => y.Value),
                        Blue = pairs.Where(x => x.Key == "blue").Sum(y => y.Value),
                    });
                }
            }

            #region Part 1
            //12 red cubes, 13 green cubes, and 14 blue cubes
            //Add Game ID's together.

            //Find Max cubes in each game.
            List<Cubes> maximums = new List<Cubes>();
            var games = entries.Select(x => x.Game).Distinct();

            foreach (var game in games)
            {
                maximums.Add(new Cubes()
                {
                    Game = game,
                    Red = entries.Where(x => x.Game == game).Max(y => y.Red),
                    Green = entries.Where(x => x.Game == game).Max(y => y.Green),
                    Blue = entries.Where(x => x.Game == game).Max(y => y.Blue),
                });
            }
            int idTotals = 0;
            foreach (var item in maximums.Where(x => x.Red <= 12 && x.Green <= 13 && x.Blue <= 14))
            {
                idTotals += item.Game;
            }

            Console.WriteLine("Total of Games: " + idTotals);
            #endregion

            #region Part2:
            int idPower = 0;
            foreach (var item in maximums)
            {
                idPower += item.Red * item.Green * item.Blue;
            }
            Console.WriteLine("Total Power of Games: " + idPower);
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
