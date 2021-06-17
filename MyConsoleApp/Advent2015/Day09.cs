using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent2015
{
    class Advent09
    {
        public class Route
        {
            public string _start;
            public string _finish;
            public int _distance;

            public string Start // property
            {
                get { return _start; } // get method
                set { _start = value; } // set method
            }

            public string Finish // property
            {
                get { return _finish; } // get method
                set { _finish = value; } // set method
            }

            public int Distance
            {
                get { return _distance; }
                set { _distance = value; }

            }

            public Route(string Start, string Finish, int Distance)
            {
                _start = Start;
                _finish = Finish;
                _distance = Distance;
            }
        }

        public class AtoH
        {
            public string _destA;
            public string _destB;
            public string _destC;
            public string _destD;
            public string _destE;
            public string _destF;
            public string _destG;
            public string _destH;
            public int _atoB;
            public int _btoC;
            public int _ctoD;
            public int _dtoE;
            public int _etoF;
            public int _ftoG;
            public int _gtoH;
            public int _total;

            public string DestA // property
            {
                get { return _destA; } // get method
                set { _destA = value; } // set method
            }

            public string DestB // property
            {
                get { return _destB; } // get method
                set { _destB = value; } // set method
            }
            public string DestC // property
            {
                get { return _destC; } // get method
                set { _destC = value; } // set method
            }
            public string DestD // property
            {
                get { return _destD; } // get method
                set { _destD = value; } // set method
            }
            public string DestE // property
            {
                get { return _destE; } // get method
                set { _destE = value; } // set method
            }
            public string DestF // property
            {
                get { return _destF; } // get method
                set { _destF = value; } // set method
            }
            public string DestG // property
            {
                get { return _destG; } // get method
                set { _destG = value; } // set method
            }
            public string DestH // property
            {
                get { return _destH; } // get method
                set { _destH = value; } // set method
            }

            public int AtoB
            {
                get { return _atoB; }
                set { _atoB = value; }
            }
            public int BtoC
            {
                get { return _btoC; }
                set { _btoC = value; }
            }
            public int CtoD
            {
                get { return _ctoD; }
                set { _ctoD = value; }
            }
            public int DtoE
            {
                get { return _dtoE; }
                set { _dtoE = value; }
            }
            public int EtoF
            {
                get { return _etoF; }
                set { _etoF = value; }
            }
            public int FtoG
            {
                get { return _ftoG; }
                set { _ftoG = value; }
            }
            public int GtoH
            {
                get { return _gtoH; }
                set { _gtoH = value; }

            }

            public int Total
            {
                get
                {
                    _total = AtoB + BtoC + CtoD + DtoE + EtoF + FtoG + GtoH;
                    return _total;
                }
                set { _total = value; }

            }

            public AtoH(string DestA, int AtoB, string DestB, int BtoC, string DestC, int CtoD, string DestD, int DtoE, string DestE, int EtoF, string DestF, int FtoG, string DestG, int GtoH, string DestH)
            {
                _destA = DestA;
                _destB = DestB;
                _destC = DestC;
                _destD = DestD;
                _destE = DestE;
                _destF = DestF;
                _destG = DestG;
                _destH = DestH;
                _atoB = AtoB;
                _btoC = BtoC;
                _ctoD = CtoD;
                _dtoE = DtoE;
                _etoF = EtoF;
                _ftoG = FtoG;
                _gtoH = GtoH;
            }
        }

        public static void Day09()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 09");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read File
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-09.txt";
            string dataSet = @"";

            dataSet = "London to Dublin = 464" +
                "London to Belfast = 518" +
                "Dublin to Belfast = 141";

            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            List<Route> routes = new List<Route>();
            List<string> tempDestinations = new List<string>();

            foreach (string row in rawEntries)
            {
                string[] items = row.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                routes.Add(new Route(
                    items[0],
                    items[2],
                    Convert.ToInt32(items[4])
                    ));
                routes.Add(new Route(
                    items[2],
                    items[0],
                    Convert.ToInt32(items[4])
                    ));
                tempDestinations.Add(items[0]);
                tempDestinations.Add(items[2]);
            }

            List<string> destinations = tempDestinations.Select(x => x.ToString()).Distinct().ToList();

            #region Part 1         
            //London to Dublin = 464
            //London to Belfast = 518
            //Dublin to Belfast = 141
            List<AtoH> possibleRoutes = new List<AtoH>();

            foreach (var destA in destinations)
            {
                foreach (var destB in destinations.Except(new List<string>() { destA }))
                {
                    foreach (var destC in destinations.Except(new List<string>() { destA, destB }))
                    {
                        foreach (var destD in destinations.Except(new List<string>() { destA, destB, destC }))
                        {
                            foreach (var destE in destinations.Except(new List<string>() { destA, destB, destC, destD }))
                            {
                                foreach (var destF in destinations.Except(new List<string>() { destA, destB, destC, destD, destE }))
                                {
                                    foreach (var destG in destinations.Except(new List<string>() { destA, destB, destC, destD, destE, destF }))
                                    {
                                        foreach (var destH in destinations.Except(new List<string>() { destA, destB, destC, destD, destE, destF, destG }))
                                        {
                                            possibleRoutes.Add(new AtoH(
                                               destA,
                                               routes.Where(x => x.Start == destA && x.Finish == destB).Select(x => x.Distance).FirstOrDefault(),
                                               destB,
                                               routes.Where(x => x.Start == destB && x.Finish == destC).Select(x => x.Distance).FirstOrDefault(),
                                               destC,
                                               routes.Where(x => x.Start == destC && x.Finish == destD).Select(x => x.Distance).FirstOrDefault(),
                                               destD,
                                               routes.Where(x => x.Start == destD && x.Finish == destE).Select(x => x.Distance).FirstOrDefault(),
                                               destE,
                                               routes.Where(x => x.Start == destE && x.Finish == destF).Select(x => x.Distance).FirstOrDefault(),
                                               destF,
                                               routes.Where(x => x.Start == destF && x.Finish == destG).Select(x => x.Distance).FirstOrDefault(),
                                               destG,
                                               routes.Where(x => x.Start == destG && x.Finish == destH).Select(x => x.Distance).FirstOrDefault(),
                                               destH
                                               ));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

            int shortest = possibleRoutes.Min(x => x.Total);

            AtoH sr = possibleRoutes.Where(x => x.Total == shortest).FirstOrDefault();

            sw.Stop();
            // Write Result

            Console.WriteLine("{0} => {1} = {2}", sr.DestA, sr.AtoB, sr.DestB);
            Console.WriteLine("{0} => {1} = {2}", sr.DestB, sr.BtoC, sr.DestC);
            Console.WriteLine("{0} => {1} = {2}", sr.DestC, sr.CtoD, sr.DestD);
            Console.WriteLine("{0} => {1} = {2}", sr.DestD, sr.DtoE, sr.DestE);
            Console.WriteLine("{0} => {1} = {2}", sr.DestE, sr.EtoF, sr.DestF);
            Console.WriteLine("{0} => {1} = {2}", sr.DestF, sr.FtoG, sr.DestG);
            Console.WriteLine("{0} => {1} = {2}", sr.DestG, sr.GtoH, sr.DestH);

            Console.WriteLine("Shortest Distance A-Z {0}", shortest);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            #endregion

            #region Part 2
            sw.Restart();

            int longest = possibleRoutes.Max(x => x.Total);
            AtoH lr = possibleRoutes.Where(x => x.Total == longest).FirstOrDefault();
            sw.Stop();
            // Write Result
            Console.WriteLine("{0} => {1} = {2}", lr.DestA, lr.AtoB, lr.DestB);
            Console.WriteLine("{0} => {1} = {2}", lr.DestB, lr.BtoC, lr.DestC);
            Console.WriteLine("{0} => {1} = {2}", lr.DestC, lr.CtoD, lr.DestD);
            Console.WriteLine("{0} => {1} = {2}", lr.DestD, lr.DtoE, lr.DestE);
            Console.WriteLine("{0} => {1} = {2}", lr.DestE, lr.EtoF, lr.DestF);
            Console.WriteLine("{0} => {1} = {2}", lr.DestF, lr.FtoG, lr.DestG);
            Console.WriteLine("{0} => {1} = {2}", lr.DestG, lr.GtoH, lr.DestH);

            Console.WriteLine("Longest Distance A-Z {0}", longest);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
            #endregion
        }

    }
}
