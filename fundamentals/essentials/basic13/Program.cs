using System;
using System.Collections.Generic;

namespace basic13
{
    public class Program
    {
        public static void PrintNumbers()
        {
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void PrintOdds()
        {
            for (int i = 1; i < 256; i = i + 2)
            {
                Console.WriteLine(i);
            }
        }
        public static void printSum()
        {
            int sum = 0;
            for (int i = 0; i < 256; i = i + 1)
            {
                sum += i;
                Console.WriteLine("New number: {0} Sum: {1}", i, sum);
            }
        }
        public static void LoopArray(int[] numbers)
        {
            foreach (int val in numbers)
            {
                Console.WriteLine(val);
            }
        }
        public static int findMax(int[] numbers)
        {
            int max = numbers[0];
            foreach (int val in numbers)
            {
                if (val > max)
                {
                    max = val;
                }
            }
            return max;
        }
        public static int GetAverage(int[] numbers)
        {
            int sum = 0;
            foreach (int val in numbers)
            {
                sum += val;
            }
            return sum / numbers.Length;
        }
        public static int[] oddArray()
        {
            List<int> nums = new List<int>();
            for (int i = 1; i < 256; i+=2)
            {
                nums.Add(i);
            }
            int [] result = nums.ToArray();
            return result;
        }
        public static int greaterThanY(int [] numbers, int y)
        {
            int count = 0;
            foreach (int num in numbers)
            {
                if (num > y)
                {
                    count++;
                }
            }
            return count;
        }
        
        public static Array squareArrayValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] *= numbers[i];
            }
            return numbers;
        }

        public static Array EliminateNegatives(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
            }
            return numbers;
        }

        public static void MinMaxAvg(int[] numbers)
        {
            int sum = 0;
            int min = numbers[0];
            int max = numbers[0];
            foreach (int val in numbers)
            {
                sum += val;
                if (val < min)
                {
                    min = val;
                }
                else if (val > max)
                {
                    max = val;
                }
            }
            Console.WriteLine("Min: {0}. Max: {1}. Avg: {2}.", min, max, sum/numbers.Length);
        }

        public static Array ShiftValues(int[] numbers)
        {
            for (var i = 1; i < numbers.Length; i++)
            {
                numbers[i-1] = numbers[i];
            }
            numbers[numbers.Length-1] = 0;
            return numbers;
        }
        public static object[] NumToString(int[] numbers)
        {
            List<object> holder = new List<object>();
            foreach (int val in numbers)
            {
                if (val < 0)
                {
                    holder.Add("Dojo");
                }
                else
                {
                    holder.Add(val);
                }
            }
            object[] result = holder.ToArray();
            return result;
        }

        public static void Main(string[] args)
        {
            PrintNumbers();
            PrintOdds();
            printSum();
        }
    }
}


