using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;

namespace Advent2015
{
    class Advent12
    {

        public static void Day12()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 12");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read Input
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-12.txt";
            string dataSet = @"";


            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);
            #region Part 1         

            ExpandoObject deserializedProduct = JsonConvert.DeserializeObject<ExpandoObject>(dataSet);

            foreach (var item in deserializedProduct)
            {
                if (item.Value != null)
                {
                    enumerate((dynamic)item.Value);
                }
                item.Key.Contains("red");
            }

            long total = 0;
            using (var reader = new JsonTextReader(new StringReader(inputFile)))
            {
                while (reader.Read())
                    if (reader.TokenType == JsonToken.Integer)
                        total += (long)reader.Value;

            }

            sw.Stop();
            // Write Result
            Console.WriteLine("Answer to Part 1 {0}", total);
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



        static void enumerate<T>(List<T> list)
        {
            Console.WriteLine("Enumerating list of " + typeof(T).FullName);

            foreach (var item in list)
                Console.WriteLine(item);

            Console.WriteLine();
        }

        static void enumerate<T>(T[] array)
        {
            Console.WriteLine("Enumerating array of " + typeof(T).FullName);

            foreach (var item in array)
                Console.WriteLine(item);

            Console.WriteLine();
        }

        static void enumerate(object obj)
        {
            Console.WriteLine("Not enumerating type " + obj.GetType().FullName + " with value " + obj);
            Console.WriteLine();
        }

    }
}
