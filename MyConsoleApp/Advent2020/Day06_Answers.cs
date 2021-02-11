using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Advent2020
{
    public class Day06_temp
    {
        private const int V = 0;

        public static bool Day06()
        {
            Console.WriteLine("Starting Advent of Code Day 06 \r\n");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day06.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);


            string[] fullEntryDiv = { "\n\n", "\r\n\r\n" };
            string[] entries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);
            List<string> replies = new List<string>();
            List<int> answerTotals = new List<int>();
            int result = 0;

            foreach (string entry in entries)
            {
                char[] charArr = entry.Where(c => !Char.IsWhiteSpace(c)).ToArray();
                char[] quest = charArr.Distinct().ToArray();
                char[] az = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();
                /*
                - array2.Except(array1)
                - array1.Except(array2)
                - array1.Intersect(array2)
                */
                string answer = String.Join("", az.Intersect(quest));
                result += answer.Length;
                //Console.WriteLine(answer + "-" + result);
            }

            Console.WriteLine("Sum Total: " + result);

            // Part 2 find matching answers in ALL rows of Entry


            int result2 = 0;
            foreach (string entry in entries)
            {
                string[] groupDiv = { "\r\n" };
                string[] individuals = entry.Split(groupDiv, System.StringSplitOptions.RemoveEmptyEntries);
                Dictionary<char, int> atoz = Enumerable.Range('a', 'z' - 'a' + 1).ToDictionary(i => (char)i, i => 0);

                int max = individuals.Count() - 1;
                for (int i = 0; i < individuals.Count(); i++)
                {
                    char[] ans1 = individuals[i].Distinct().ToArray();
                    foreach (char item in ans1)
                    {
                        atoz[item] = atoz[item] + 1;
                    }
                }
                var xx = atoz.Where(x => x.Value == individuals.Count()).Count();
                result2 += atoz.Where(x => x.Value == individuals.Count()).Count();
            }
            Console.WriteLine("Sum Total: " + result2);

            Console.WriteLine("\r\nGoodbye World");

            return true;
        }
    }
}
