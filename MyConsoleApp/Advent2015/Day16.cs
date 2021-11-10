using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Advent2015
{
    class Advent16
    {
        public class Aunt
        {
            //public Aunties(int sue, int children, int cats, int samoyeds, int pomeranians, int akitas, int vizslas, int goldfish, int trees, int cars, int perfumes)
            //{
            //    Sue = sue;
            //    Children = children;
            //    Cats = cats;
            //    Samoyeds = samoyeds;
            //    Pomeranians = pomeranians;
            //    Akitas = akitas;
            //    Vizslas = vizslas;
            //    Goldfish = goldfish;
            //    Trees = trees;
            //    Cars = cars;
            //    Perfumes = perfumes;
            //}
            //children: 3
            //cats: 7
            //samoyeds: 2
            //pomeranians: 3
            //akitas: 0
            //vizslas: 0
            //goldfish: 5
            //trees: 3
            //cars: 2
            //perfumes: 1
            public Aunt(int sue, Dictionary<string, int> things)
            {
                Sue = sue;
                Things = things;
            }
            public int Sue { get; set; }
            public Dictionary<string, int> Things { get; set; }
            //public int Children { get; set; }
            //public int Cats { get; set; }
            //public int Samoyeds { get; set; }
            //public int Pomeranians { get; set; }
            //public int Akitas { get; set; }
            //public int Vizslas { get; set; }
            //public int Goldfish { get; set; }
            //public int Trees { get; set; }
            //public int Cars { get; set; }
            //public int Perfumes { get; set; }

        }

        public static void Day16()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 16");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read Input
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-16.txt";
            string dataSet = @"";
            List<Aunt> Aunties = new List<Aunt>();

            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in rawEntries)
            {
                string[] items = item.Split(new string[] { " ", ":", "," }, StringSplitOptions.RemoveEmptyEntries);
                //Sue 2: goldfish: 7, trees: 1, akitas: 0
                //Sue 3: cars: 10, akitas: 6, perfumes: 7
                //Sue 4: perfumes: 2, vizslas: 0, cars: 6

                var newSue = new Aunt(
                    int.Parse(items[1]),
                    new Dictionary<string, int>
                    {
                        { items[2].ToString(), int.Parse(items[3]) },
                        { items[4].ToString(), int.Parse(items[5]) },
                        { items[6].ToString(), int.Parse(items[7]) }
                    }
                    );
                Aunties.Add(newSue);
            }
            //children: 3
            //cats: 7
            //samoyeds: 2
            //pomeranians: 3
            //akitas: 0
            //vizslas: 0
            //goldfish: 5
            //trees: 3
            //cars: 2
            //perfumes: 1

            Dictionary<string, int> targetSue = new Dictionary<string, int>
            {
                { "children", 3 },
                { "cats", 7 },
                { "samoyeds", 2 },
                { "pomeranians", 3 },
                { "akitas", 0 },
                { "vizslas", 0 },
                { "goldfish", 5 },
                { "trees", 3 },
                { "cars", 2 },
                { "perfumes", 1 }
            };



            #region Part 1


            sw.Stop();
            // Write Result
            Console.WriteLine("Answer to Part 1 {0}", 1);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #endregion

            #region Part 2
            sw.Restart();

            sw.Stop();
            // Write Result
            Console.WriteLine("Answer to Part 2 {0}", 2);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
            #endregion
        }

    }
}
