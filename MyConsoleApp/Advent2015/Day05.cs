using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Advent05
    {
        public static void Day05()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 05");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read File
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-05.txt";
            string dataSet = @"";
            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            // Nice Strings 
            // It contains at least three vowels(aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
            // It contains at least one letter that appears twice in a row, like xx, abcdde(dd), or aabbccdd(aa, bb, cc, or dd).
            // It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
            int nice = 0;
            //List<string> vowels = new List<string>() { "a", "e", "i", "o", "u" };
            List<string> badStuff = new List<string>() { "ab", "cd", "pq", "xy" };

            foreach (string item in rawEntries)
            {
                List<char> norn = new List<char>();
                norn.AddRange(item);

                //int countvowel = vowels.Count(item.Contains);

                int vowels = norn.Where(x => x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u').Count();

                bool doublers = Regex.IsMatch(item, "([a-zA-Z])\\1{" + (1) + "}");

                bool badCombos = badStuff.Any(item.Contains);

                if (vowels > 2 && doublers && !badCombos)
                {
                    nice++;
                }
            }

            sw.Stop();
            // Write Result
            Console.WriteLine("Nice strings {0}", nice);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #region Part 2
            sw.Restart();
            // It contains a pair of any two letters that appears at least twice in the string without overlapping,
            // like xyxy (xy) or aabcdefgaa (aa), but not like aaa (aa, but it overlaps).
            // It contains at least one letter which repeats with exactly one letter between them,
            // like xyx, abcdefeghi(efe), or even aaa.
            foreach (string item in rawEntries)
            {
                char[] bits = item.ToCharArray();
                for (int i = 0; i < item.Length; i++)
                {
                    // Rule 1: for each index of bits add pairs to dictionary
                    // Rule 2: for each index of bits check and add pairs to dictionary if they match
                }
                //Rule 1: find duplicates in dictonary where index is not adjacent

                //Rule 2: count dictionary or just increment earlier

                // Increment new nice count if conditions met
            }

            sw.Stop();

            Console.WriteLine("Elapsed Part 2: {0}", sw.Elapsed);

            #endregion
        }

    }
}
