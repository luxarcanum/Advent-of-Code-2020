using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Advent2023
{
    public class Day04_ScratchCards
    {
        public class ScratchCard
        {
            public int CardId { get; set; }
            public List<int> WinningNumbers { get; set; }
            public List<int> YourNumbers { get; set; }
            public int Points { get; set; }

            public ScratchCard() { }
        }

        public static bool Day04()
        {
            Console.WriteLine("Starting Advent of Code Day 04");

            string inputFile = @"S:\Advent 2023\input4.txt";
            //string inputFile = @"S:\Advent 2023\input-04.txt";
            string dataSet = @"";

            dataSet = Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            //Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            //Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            //Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            //Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            //Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            //Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11

            List<ScratchCard> cards = new List<ScratchCard>();

            // seperate Data into List/array/class etc
            foreach (string raw in rawEntries)
            {   
                //get Game
                string[] lines = raw.Split(new string[] { ":", "|" }, StringSplitOptions.RemoveEmptyEntries);
                string[] card = lines[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int cardId = int.Parse(card[1]);
                //for each winning numbers
                List<int> winningNumbers = new List<int>();
                foreach (var num in lines[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    winningNumbers.Add(int.Parse(num));
                }
                //for each Your numbers
                List<int> yourNumbers = new List<int>();
                foreach (var num in lines[2].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    yourNumbers.Add(int.Parse(num));
                }

                cards.Add(new ScratchCard()
                {
                    CardId = cardId,
                    WinningNumbers = winningNumbers,
                    YourNumbers = yourNumbers,
                    Points = 0,
                });
            }

            #region Part 1
            foreach (var card in cards)
            {
                //int numWins = 0;
                //foreach (var winningNumber in card.WinningNumbers)
                //{
                //    foreach (var yourNumber in card.YourNumbers)
                //    {
                //        if (winningNumber == yourNumber)
                //        {
                //            numWins++;
                //        }
                //    }
                //}
                int numWins = NumbberOfWins(card);
                card.Points = numWins > 0 ? NumberOfPoints(numWins) : 0;

                Console.WriteLine("Card ID: {0} Wins: {1}  Points: {2}", card.CardId, numWins, card.Points);
            }

            Console.WriteLine("Total Points: {0}", cards.Sum(x => x.Points));

            #endregion

            #region Part 2
            // This won't work because the collection is getting modified.
            // Backwards won't work as it adds to the end of the list.
            // probably need to do a for loop, tracking the position, and each time it adds an entry, 
            // break, re-sort the list and resume from tracked position.

            foreach (var card in cards)
            {
                int numWins = NumbberOfWins(card);
                if (numWins > 0)
                {
                    int startId = card.CardId;
                    int endId = card.CardId + numWins;
                    for (int i = startId; i < endId; i++)
                    {
                        cards.Add(cards.Where(x => x.CardId == i).FirstOrDefault());
                    }
                }
            }

            Console.WriteLine("Total Cards: {0}", cards.Count());
            #endregion
            return true;
        }

        private static int NumbberOfWins(ScratchCard card)
        {
            int numWins = 0;
            foreach (var winningNumber in card.WinningNumbers)
            {
                foreach (var yourNumber in card.YourNumbers)
                {
                    if (winningNumber == yourNumber)
                    {
                        numWins++;
                    }
                }
            } 
            return numWins;
        }


        private static int NumberOfPoints(int numWins)
        {
            int points = 1;
            for (int i = 0; i < numWins - 1; i++)
            {
                points = points * 2;
            }
            return points;
        }
       
    }
}
