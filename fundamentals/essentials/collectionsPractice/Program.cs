using System;
using System.Collections.Generic;

namespace collectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }

            string[] names = { "Tim", "Martin", "Nikki", "Sara" };
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            bool[] boolArr = new bool[11];
            for (int i = 0; i < boolArr.Length; i += 2)
            {
                boolArr[i] = true;
                Console.WriteLine(boolArr[i]);
            }

            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Strawberry");
            flavors.Add("Chocolate");
            flavors.Add("Raspberry");
            flavors.Add("Fudge");
            Console.WriteLine(flavors);
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            Random random = new Random();
            Dictionary<string, string> person = new Dictionary<string, string>();
            for (int i = 0; i < names.Length; i++)
            {
                person.Add(names[i], flavors[random.Next(flavors.Count)]);
            }

            foreach (KeyValuePair<string, string> entry in person)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}

