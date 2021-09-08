using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent2015
{
    class Advent15
    {
        public class Ingredients
        {
            public Ingredients(string ingredient, int capacity, int durability, int flavour, int texture, int calories)
            {
                this.Ingredient = ingredient;
                this.Capacity = capacity;
                this.Durability = durability;
                this.Flavour = flavour;
                this.Texture = texture;
                this.Calories = calories;
            }

            public string Ingredient { get; set; }
            public int Capacity { get; set; }
            public int Durability { get; set; }
            public int Flavour { get; set; }
            public int Texture { get; set; }
            public int Calories { get; set; }
        }

        public static void Day15()
        {
            Console.WriteLine("Starting Advent of Code 2015 Day 15");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Read Input
            string inputFile = @"D:\Users\U.6074887\Advent2020 Input Files\2015-15.txt";
            string dataSet = @"";
            List<Ingredients> ListOfIngredients = new List<Ingredients>();

            // Parse File
            dataSet = MyConsoleApp.Utilities.FileUtilities.ReadTxtToString(inputFile);

            string[] fullEntryDiv = { "\n" };
            string[] rawEntries = dataSet.Split(fullEntryDiv, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in rawEntries)
            {
                string[] items = item.Split(new string[] { " ", ":", "," }, StringSplitOptions.RemoveEmptyEntries);
                //Frosting: capacity 4, durability -2, flavor 0, texture 0, calories 5
                //Candy: capacity 0, durability 5, flavor - 1, texture 0, calories 8
                //Butterscotch: capacity - 1, durability 0, flavor 5, texture 0, calories 6
                //Sugar: capacity 0, durability 0, flavor - 2, texture 2, calories 1

                string x1 = items[0].ToString();
                var x2 = items[2];

                var newthing = new Ingredients(
                    items[0].ToString(),
                    int.Parse(items[2]),
                    int.Parse(items[4]),
                    int.Parse(items[6]),
                    int.Parse(items[8]),
                    int.Parse(items[10])
                    );

                ListOfIngredients.Add(newthing);
            }

            Tuple<int, int, int, int, int> IngredientsList;
            int currentScore = 0;
            int[] wArray = Enumerable.Range(0, 100).ToArray();
            int[] xArray = Enumerable.Range(0, 100).ToArray();
            int[] yArray = Enumerable.Range(0, 100).ToArray();
            int[] zArray = Enumerable.Range(0, 100).ToArray();

            #region Part 1
            foreach (int w in wArray)
            {
                foreach (int x in xArray)
                {
                    foreach (int y in yArray)
                    {
                        foreach (int z in zArray)
                        {
                            if (w + x + y + z == 100)
                            {
                                int newScore = RateMyCookie(ListOfIngredients, w, x, y, z);
                                if (newScore > currentScore)
                                {
                                    currentScore = newScore;
                                    IngredientsList = new Tuple<int, int, int, int, int>(w, x, y, z, newScore);
                                }
                            }
                        }
                    }
                }
            }



            //192080000 too high
            //200000000
            //18965440
            //15862900

            sw.Stop();
            // Write Result
            Console.WriteLine("Answer to Part 1 {0}", currentScore);
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

        private static int RateMyCookie(List<Ingredients> ListOfIngredients, int w, int x, int y, int z)
        {
            int capacityScore = w * ListOfIngredients[0].Capacity + x * ListOfIngredients[1].Capacity + y * ListOfIngredients[2].Capacity + z * ListOfIngredients[3].Capacity;
            int durabilityScore = w * ListOfIngredients[0].Durability + x * ListOfIngredients[1].Durability + y * ListOfIngredients[2].Durability + z * ListOfIngredients[3].Durability;
            int flavourScore = w * ListOfIngredients[0].Flavour + x * ListOfIngredients[1].Flavour + y * ListOfIngredients[2].Flavour + z * ListOfIngredients[3].Flavour;
            int textureScore = w * ListOfIngredients[0].Texture + x * ListOfIngredients[1].Texture + y * ListOfIngredients[2].Texture + z * ListOfIngredients[3].Texture;

            int calorieCount = w * ListOfIngredients[0].Calories + x * ListOfIngredients[1].Calories + y * ListOfIngredients[2].Calories + z * ListOfIngredients[3].Calories;
            if (calorieCount != 500) return 0;

            capacityScore = capacityScore < 0 ? 0 : capacityScore;
            durabilityScore = durabilityScore < 0 ? 0 : durabilityScore;
            flavourScore = flavourScore < 0 ? 0 : flavourScore;
            textureScore = textureScore < 0 ? 0 : textureScore;

            int cookieScore = capacityScore * durabilityScore * flavourScore * textureScore;
            return cookieScore;
        }
    }
}
