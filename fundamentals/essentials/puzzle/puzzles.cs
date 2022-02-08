using System;
using System.Collections.Generic;


namespace Puzzles
{
    class Puzzles
    {
        static void Main(string[] args)
        {
            double headsRatio = TossMultipleCoins(5);
            Console.WriteLine(headsRatio);

            List<string> longNames = Names();
            Console.WriteLine(String.Join(", ", longNames));
        }


        static int[] RandomArray()
        {
            Random r = new Random();
            int[] randNums = new int[10];
            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < 10; i++)
            {
                int rand = r.Next(5, 26);

                if (rand < min)
                {
                    min = rand;
                }

                if (rand > max)
                {
                    max = rand;
                }

                randNums[i] = rand;
            }

            Console.WriteLine($"Min: {min}, Max: {max}");
            return randNums;
        }


        static string TossCoin()
        {
            Random r = new Random();
            int rand = r.Next(0, 2);
            string result = "Heads";

            Console.WriteLine("Tossing a Coin!");

            if (rand == 0)
            {
                result = "Tails";
            }

            Console.WriteLine(result);
            return result;
        }


        static double TossMultipleCoins(int num)
        {
            double headsCount = 0;

            for (int i = 0; i < num; i++)
            {
                string result = TossCoin();

                if (result == "Heads")
                {
                    headsCount++;
                }
            }

            return headsCount / num;
        }


        static List<string> Names()
        {
            List<string> names = new List<string>
            {
                "Todd", "Tiffany", "Charlie", "Geneva", "Sydney"
            };

            List<string> longerNames = new List<string>();

            for (int i = 0; i < names.Count; i++)
            {
                Random r = new Random();
                int rand = r.Next(0, names.Count);

                string temp = names[i];
                names[i] = names[rand];
                names[rand] = temp;
            }

            foreach (string currentName in names)
            {
                if (currentName.Length > 5)
                {
                    longerNames.Add(currentName);
                }
            }

            Console.WriteLine(String.Join(",", names));
            return longerNames;
        }
    }
}