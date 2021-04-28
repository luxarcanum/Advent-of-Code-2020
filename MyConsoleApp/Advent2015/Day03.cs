using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent2015
{
    class Advent03
    {
        public class Map
        {
            public int _coordX;
            public int _coordY;
            public int _pressies;

            public int CoordX // property
            {
                get { return _coordX; } // get method
                set { _coordX = value; } // set method
            }

            public int CoordY // property
            {
                get { return _coordY; } // get method
                set { _coordY = value; } // set method
            }

            public int Pressies
            {
                get { return _pressies; }
                set { _pressies = value; }
            }

            public Map(int CoordX, int CoordY, int Pressies)
            {
                _coordX = CoordX;
                _coordY = CoordY;
                _pressies = Pressies;
            }
        }

        public static void Day03()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 03");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read File
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-03.txt";
            string dataSet = @"";
            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);
            char[] directions = dataSet.ToCharArray();

            int x = 0;
            int y = 0;
            List<Map> route = new List<Map>();
            route.Add(new Map(x, y, 1));
            foreach (char item in directions)
            {
                if (item == '^') { y++; }
                if (item == 'v') { y--; }
                if (item == '>') { x++; }
                if (item == '<') { x--; }
                int itemIndex = route.FindIndex(px => px.CoordX == x && px.CoordY == y);
                if (itemIndex != -1)
                {
                    Map house = route.ElementAt(itemIndex);
                    house.Pressies++;
                }
                else
                {
                    route.Add(new Map(x, y, 1));
                }

            }
            int maxX = route.Max(x => x.CoordX);
            int minX = route.Min(x => x.CoordX);
            int maxY = route.Max(x => x.CoordY);
            int minY = route.Min(x => x.CoordY);
            int maxP = route.Max(x => x.Pressies);
            int minP = route.Min(x => x.Pressies);

            sw.Stop();
            // Write Result
            Console.WriteLine("Total houses visited is {0}.", route.Count);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            sw.Restart();
            #region Part 2
            x = 0;
            y = 0;
            int rx = 0;
            int ry = 0;

            List<Map> newRoute = new List<Map>();
            newRoute.Add(new Map(x, y, 2));

            for (int i = 0; i < directions.Count(); i += 2)
            {
                if (directions[i] == '^') { y++; }
                if (directions[i] == 'v') { y--; }
                if (directions[i] == '>') { x++; }
                if (directions[i] == '<') { x--; }
                int itemIndex = newRoute.FindIndex(px => px.CoordX == x && px.CoordY == y);
                if (itemIndex != -1)
                {
                    Map house = newRoute.ElementAt(itemIndex);
                    house.Pressies++;
                }
                else
                {
                    newRoute.Add(new Map(x, y, 1));
                }
                // Robot santa
                if (directions[i + 1] == '^') { ry++; }
                if (directions[i + 1] == 'v') { ry--; }
                if (directions[i + 1] == '>') { rx++; }
                if (directions[i + 1] == '<') { rx--; }
                int roboIndex = newRoute.FindIndex(px => px.CoordX == rx && px.CoordY == ry);
                if (roboIndex != -1)
                {
                    Map house = newRoute.ElementAt(roboIndex);
                    house.Pressies++;
                }
                else
                {
                    newRoute.Add(new Map(rx, ry, 1));
                }
            }
            sw.Stop();
            // Write Result
            Console.WriteLine("Total houses visited is {0}.", newRoute.Count);

            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #endregion
        }

    }
}
