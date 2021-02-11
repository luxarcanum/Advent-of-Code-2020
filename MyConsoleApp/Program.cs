using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! \r\n");

            Console.WriteLine("Advent of Code, pick a day number");
            Console.WriteLine("01: Expenses");
            Console.WriteLine("02: Passwords");
            Console.WriteLine("03: Tobbogan");
            Console.WriteLine("04: Passports");
            Console.WriteLine("05: Plane Seats");
            Console.WriteLine("06: Answers");
            Console.WriteLine("07: ");
            Console.WriteLine("08: Navigation");
            Console.WriteLine("09: Data Ports");
            Console.WriteLine("10: Adapater Array");
            Console.WriteLine("11: ");
            //Console.WriteLine("12: ");
            //Console.WriteLine("13: ");
            //Console.WriteLine("14: ");
            //Console.WriteLine("15: ");
            //Console.WriteLine("16: ");
            //Console.WriteLine("17: ");
            //Console.WriteLine("18: ");
            //Console.WriteLine("19: ");
            //Console.WriteLine("20: ");
            //Console.WriteLine("21: ");
            //Console.WriteLine("22: ");
            //Console.WriteLine("23: ");
            //Console.WriteLine("24: ");
            //Console.WriteLine("25: ");

            string menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    Advent2020.Day01_Expenses.Day01();
                    break;
                case "2":
                    Advent2020.Day02_Passwords.Day02();
                    break;
                case "3":
                    Advent2020.Day03_Tobbogan.Day03();
                    break;
                case "4":
                    Advent2020.Day04_Passports.Day04();
                    break;
                case "5":
                    Advent2020.Day05_PlaneSeats.Day05();
                    break;
                case "6":
                    Advent2020.Day06_temp.Day06();
                    break;
                case "7":
                    Advent2020.Day07_temp.Day07();
                    break;
                case "8":
                    Advent2020.Day08_Navigation.Day08();
                    break;
                case "9":
                    Advent2020.Day09_Dataports.Day09();
                    break;
                case "10":
                    Advent2020.Day10_AdapaterArray.Day10();
                    break;
                case "e":
                    // Statement
                    break;
                default:
                    break;
            }

            Console.WriteLine("\r\nGoodbye World! \r");
        }
    }
}
