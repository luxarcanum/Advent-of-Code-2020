using System;
using System.Linq;

namespace Advent2015
{
    class Advent01
    {
        public static void Day01()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 01");
            // Read File
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-01.txt";
            string dataSet = @"";
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);
            // Parse File
            char[] instructions = dataSet.ToCharArray();

            //Count items
            int ups = instructions.Where(x => x == '(').Count();
            int downs = instructions.Where(x => x == ')').Count();

            // Write Result
            Console.WriteLine("Ups {0} - Downs {1} = Final floor {2}", ups, downs, (ups - downs));

            #region Part 2
            int count = 0;
            int floor = 0;
            foreach (char instruction in instructions)
            {
                if (instruction == '(') { floor++; }
                if (instruction == ')') { floor--; }
                count++;
                if (floor < 0) { break; }
            }

            Console.WriteLine("Instruction {0} took Santa into the basement.", count);
            #endregion
        }

    }
}
