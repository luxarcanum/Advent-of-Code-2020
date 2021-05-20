using System;
using System.Diagnostics;

namespace Advent2015
{
    class Advent06
    {
        public static void Day06()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 06");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read File
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-06.txt";
            string dataSet = @"";
            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);

            //dataSet = @"turn on 0,0 through 999,0";

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            // turn off 812,389 through 865,874
            // turn on 599,989 through 806,993
            //turn on 376,415 through 768,548
            //turn on 606,361 through 892,600
            //turn off 448,208 through 645,684
            //toggle 50,472 through 452,788
            //toggle 205,417 through 703,826
            //toggle 533,331 through 906,873
            //toggle 857,493 through 989,970

            bool[,] lightArray = new bool[1000, 1000];

            foreach (string item in rawEntries)
            {
                int toggle = 0;
                switch (item.Substring(0, 7))
                {
                    case "toggle ":
                        toggle = 2;
                        break;
                    case "turn on":
                        toggle = 1;
                        break;
                    case "turn of":
                        toggle = 0;
                        break;
                }

                //left somestring.Substring(0,nCount)
                //right somestring.Substring(somestring.Length-nCount,nCount)

                string somestring = item.Substring(item.Length - (item.Length - 5), (item.Length - 5));

                string[] lines = somestring.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

                int x1 = int.Parse(lines[1]);
                int y1 = int.Parse(lines[2]);

                int x2 = int.Parse(lines[4]);
                int y2 = int.Parse(lines[5]);

                for (int x = x1; x <= x2; x++)
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        bool lightSwitch = lightArray[x, y];
                        if (toggle == 0) lightSwitch = false;
                        if (toggle == 1) lightSwitch = true;
                        if (toggle == 2) lightSwitch = !lightSwitch;

                        lightArray[x, y] = lightSwitch;
                    }
                }

                //ToggleLights(lightArray, toggle, x1, y1, x2, y2);
            }

            int count = 0;
            foreach (var item in lightArray)
            {
                if (item == true) count++;
            }

            sw.Stop();
            // Write Result
            Console.WriteLine("Number of lights on {0}", count);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #region Part 2
            sw.Restart();
            int[,] lightArray2 = new int[1000, 1000];

            foreach (string item in rawEntries)
            {
                int toggle = 0;
                switch (item.Substring(0, 7))
                {
                    case "toggle ":
                        toggle = 2;
                        break;
                    case "turn on":
                        toggle = 1;
                        break;
                    case "turn of":
                        toggle = 0;
                        break;
                }

                //left somestring.Substring(0,nCount)
                //right somestring.Substring(somestring.Length-nCount,nCount)

                string somestring = item.Substring(item.Length - (item.Length - 5), (item.Length - 5));

                string[] lines = somestring.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

                int x1 = int.Parse(lines[1]);
                int y1 = int.Parse(lines[2]);

                int x2 = int.Parse(lines[4]);
                int y2 = int.Parse(lines[5]);

                for (int x = x1; x <= x2; x++)
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        int lightSwitch = lightArray2[x, y];
                        if (toggle == 0) lightSwitch = -1;
                        if (toggle == 1) lightSwitch = 1;
                        if (toggle == 2) lightSwitch = 2;

                        if (lightArray2[x, y] + lightSwitch < 0)
                        {
                            lightArray2[x, y] = 0;
                        }
                        else
                        {
                            lightArray2[x, y] += lightSwitch;
                        }

                    }
                }

                //ToggleLights(lightArray, toggle, x1, y1, x2, y2);
            }

            int count2 = 0;
            foreach (var item in lightArray2)
            {
                count2 += item;
            }

            //too low 14190930
            // 14190930

            sw.Stop();
            // Write Result
            Console.WriteLine("Brightness on {0}", count2);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
            #endregion
        }

        private static void ToggleLights(bool[,] lightArray, int toggle, int x1, int y1, int x2, int y2)
        {
            for (int x = x1; x < x2; x++)
            {
                for (int y = y1; y < y2; y++)
                {
                    bool lightSwitch = lightArray[x, y];
                    if (toggle == 0) lightSwitch = false;
                    if (toggle == 1) lightSwitch = true;
                    if (toggle == 2) lightSwitch = !lightSwitch;

                    lightArray[x, y] = lightSwitch;
                }
            }
        }


    }
}
