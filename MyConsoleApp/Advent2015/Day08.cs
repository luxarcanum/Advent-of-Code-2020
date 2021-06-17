using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Advent08
    {

        public static void Day08()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 08");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read File
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-08.txt";
            string dataSet = "";
            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n", "\r" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            string str1 = $"";
            string str2 = $"abc";
            string str3 = $"aaa\"aaa";
            string str4 = $"\x27";

            // "" is 2 characters of code(the two double quotes), but the string contains zero characters.
            // "abc" is 5 characters of code, but 3 characters in the string data.
            // "aaa\"aaa" is 10 characters of code, but the string itself contains six "a" characters and a single, escaped quote character, for a total of 7 characters in the string data.
            // "\x27" is 6 characters of code, but the string itself contains just one - an apostrophe(')

            string str1c = @"" + Regex.Unescape(ToLiteral(str1)).Replace("\"", "yy").Replace("\\", "yy");
            int str1d = str1c.Length;

            string str2c = (str2.Replace("\n", null).Replace("\r", null)).Replace("\"", "yy").Replace("\\", "yy");
            int str2d = str2c.Length;

            string str3c = (str3.Replace("\n", null).Replace("\r", null)).Replace("\"", "yy").Replace("\\", "yy");
            int str3d = str3c.Length;

            var str4c = Regex.Unescape(ToLiteral(Regex.Unescape(str4))).ToCharArray();
            int str4d = str4c.Length;

            // str1 0 2 6
            // str2 3 5 9 
            // str3 7 10 16
            // str4 1 6 11

            int inStr = 0;
            int inMem = 0;
            int inEscaped = 0;

            foreach (var item in rawEntries)
            {
                inStr += item.Replace("\n", null).Replace("\r", null).Length;
                inMem += Regex.Unescape(item.Replace("\n", null).Replace("\r", null)).Length - 2;
                inEscaped += Regex.Escape(item).Length;
            }

            #region Part 1         
            int inString = dataSet.Replace("\n", null).Replace("\r", null).Length;
            int inMemory = Regex.Unescape(dataSet.Replace("\n", null).Replace("\r", null)).Length - (2 * dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries).Length);

            int memory = inString - inMemory;
            int alt = inStr - inMem;
            int part2 = inEscaped - inString;

            sw.Stop();
            // Write Result
            Console.WriteLine("Answer to Part 1 {0}", memory);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #endregion

            #region Part 2
            sw.Restart();

            sw.Stop();
            // Write Result
            Console.WriteLine("Answer to Part 2 {0}", part2);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
            #endregion
        }


        private static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }
    }
}
