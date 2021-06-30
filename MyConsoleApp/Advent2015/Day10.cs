using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;

namespace Advent2015
{
    class Advent10
    {

        public static void Day10()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 10");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read Input
            string input = "3113322113";
            input = "1";
            #region Part 1         

            char[] inputArray = input.ToCharArray();
            string nextInput = input;
            int charCount = inputArray.Length;
            int position = 0;

            while (position < charCount)
            {
                //start to read from position to change of char
                var working = nextInput.ToCharArray();

                // count of chars, what char


                // add count of char and what char to next input
            }



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
