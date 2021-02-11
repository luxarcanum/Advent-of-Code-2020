using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyConsoleApp.Advent2020
{
    public class Day04_Passports
    {
        public static bool Day04()
        {
            Console.WriteLine("Starting Advent of Code Day 04");

            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\Day04.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            //      System.Console.WriteLine("Original text: '" + dataSet);
            string[] fullEntryDiv = { "\n\n", "\r\r", "\r\n\r\n" };
            string[] dictDiv = { " ", "\n", "\r", "\r\n" };
            char[] keyPairDiv = { ':' };

            List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();

            string[] entries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(entries.Length + " words in text:");

            foreach (var entry in entries)
            {
                //Console.WriteLine("Full Passport entry: " + entry);
                string[] items = entry.Split(dictDiv, System.StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, string> passport = new Dictionary<string, string>();
                foreach (var item in items)
                {
                    //Console.WriteLine("Fields: " + item);

                    string[] field = item.Split(':');
                    //  byr (Birth Year) - four digits; at least 1920 and at most 2002.
                    if (field[0] == "byr")
                    {
                        if (field[1].Length == 4 && Int32.Parse(field[1]) >= 1920 && Int32.Parse(field[1]) <= 2002)
                        { }
                        else { field[0] = "!byr"; }
                    }
                    //  iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                    if (field[0] == "iyr")
                    {
                        if (field[1].Length == 4 && Int32.Parse(field[1]) >= 2010 && Int32.Parse(field[1]) <= 2020)
                        { }
                        else { field[0] = "!iyr"; }
                    }
                    //  eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                    if (field[0] == "eyr")
                    {
                        if (field[1].Length == 4 && Int32.Parse(field[1]) >= 2020 && Int32.Parse(field[1]) <= 2030)
                        { }
                        else { field[0] = "!eyr"; }
                    }
                    //  hgt (Height) - a number followed by either cm or in:
                    //  If cm, the number must be at least 150 and at most 193.
                    //  If in, the number must be at least 59 and at most 76.
                    if (field[0] == "hgt")
                    {//int.TryParse(myStr, out a);
                        int def;
                        var xl = Int32.TryParse(field[1].Substring(0, field[1].Length - 2), out def);
                        var xr = field[1].Substring(field[1].Length - 2);
                        //Console.WriteLine(xl + "-" + xr);
                        if ((xr == "cm" && def >= 150 && def <= 193)
                            ||
                            (xr == "in" && def >= 59 && def <= 76))
                        { }
                        else { field[0] = "!hgt"; }
                        //  Console.WriteLine(field[0] + " : " + field[1]);
                    }

                    //  hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                    if (field[0] == "hcl")
                    {
                        Regex myRegex = new Regex("^#[a-fA-F0-9]+$");
                        if (myRegex.IsMatch(field[1]))
                        { }
                        else { field[0] = "!hcl"; }
                        //Console.WriteLine(field[0] + " : " + field[1]);
                    }
                    //  ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                    if (field[0] == "ecl")
                    {
                        string[] eyes = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                        if (eyes.Any(s => field[1].Contains(s)))
                        { }
                        else { field[0] = "!ecl"; }
                    }
                    //  pid (Passport ID) - a nine-digit number, including leading zeroes.
                    if (field[0] == "pid")
                    {
                        int def = 0;
                        if (field[1].Length == 9 && int.TryParse(field[1], out def))
                        { }
                        else { field[0] = "!pid"; }
                    }
                    //  cid (Country ID) - ignored, missing or not. 
                    passport.Add(field[0], field[1]);
                    //      Console.WriteLine(field[0] + " : " + field[1]);
                }
                passports.Add(passport);
            }
            // Part B: access (and print) values.
            string[] fields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            int result = 0;
            foreach (var passport in passports)
            {
                //          bool contains = passport.Any(x => x.Key.Contains("cid"));
                bool contains = fields.All(passport.ContainsKey); //true

                //Console.WriteLine(contains);
                if (contains) result++;
            }

            Console.WriteLine(result + " valid Passports.");

            return true;
        }
    }
}
