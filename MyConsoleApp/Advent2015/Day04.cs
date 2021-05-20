using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Advent2015
{
    class Advent04
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

        public static void Day04()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 04");
            Stopwatch sw = new Stopwatch();

            // Read File
            //If your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes(000001dbbfa...), and it is the lowest such number to do so.
            //If your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....sw.Start();

            string inputKey = "bgvyzdsv";
            //inputKey = "iwrupvqb";
            sw.Start();
            //string hash = CreateMD5Hash(inputKey);
            //Console.WriteLine("Hash {0}.", hash);

            for (int i = 0; i < 10000000; i++)
            {
                string input = inputKey + i.ToString();
                string hash = CreateMD5Hash(input);
                //Console.WriteLine(hash);
                if (hash.Substring(0, 5) == "00000")
                {
                    sw.Stop();
                    Console.WriteLine("Found it!!!!!!!!!!!!!!");
                    Console.WriteLine(input);
                    Console.WriteLine(hash);
                    break;
                }
            }

            // Write Result

            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #region Part 2
            sw.Restart();
            for (int i = 0; i < 1000000000; i++)
            {
                string input = inputKey + i.ToString();
                string hash = CreateMD5Hash(input);
                //Console.WriteLine(hash);
                if (hash.Substring(0, 6) == "000000")
                {
                    sw.Stop();
                    Console.WriteLine("Found it!!!!!!!!!!!!!!");
                    Console.WriteLine(input);
                    Console.WriteLine(hash);
                    break;
                }
            }
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #endregion
        }
        public static string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
