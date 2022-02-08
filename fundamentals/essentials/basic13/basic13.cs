using System;

namespace basic13
{
    public static class Basic
    {
        public static void PrintNumbers()
        {
            for(var num = 1; num <= 255; num++)
            {
                Console.WriteLine(num);
            }
        }
        public static void PrintOdds()
        {
            for(var num = 1; num <= 255; num++)
            {
                if(num % 2 != 0)
                    Console.WriteLine(num);
            }
        }
        public static void PrintSum()
        {
            int sum = 0;
            for(var num = 0; num <= 255; num++)
            {
                sum += num;
                Console.WriteLine($"New number: {num} Sum: {sum}");
            }
        }
        public static void LoopArray(object[] arr)
        {
            foreach(var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        public static int FindMax(int[] numbers)
        {
            // set curr max to smallest number possible
            int currMax = Int32.MinValue;
            foreach(int num in numbers)
            {
                if(currMax < num)
                    currMax = num;
            }
            Console.WriteLine($"Max is {currMax}");
            return currMax;
        }
        public static float GetAverage(int[] numbers)
        {
            int sum = 0;
            foreach(int num in numbers)
                sum += num;

            float avg = (float)sum / numbers.Length;
            Console.WriteLine($"Average is {avg}");
            return avg;
        }
        public static int[] OddArray()
        {
            // first we must find size of array
            int size = (255/2) + 1;

            // now we can make array, with size
            int[] odds = new int[size];

            int i = 0;
            for(int num = 1; num <= 255; num+=2)
            {
                odds[i] = num;
                i++;
            }
            return odds;
        }
        public static int GreaterThanY(int[] numbers, int y)
        {
            int total = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] > y)
                    total++;
            }
            return total;
        }
        public static void SquareArrayValues(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] * numbers[i];
            }
        }
        public static void EliminateNegatives(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] < 0)
                    numbers[i] = 0;
            }
        }

        public static void MinMaxAverage(int[] numbers)
        {
            int currMin = Int32.MaxValue,
                currMax = Int32.MinValue,
                sum = 0;
            
            foreach(int num in numbers)
            {
                sum += num;
                if(currMax < num)
                    currMax = num;
                if(currMin > num)
                    currMin = num;
            }
            Console.WriteLine($"Min: {currMin}");
            Console.WriteLine($"Max: {currMax}");
            Console.WriteLine($"Average: {(float)sum / numbers.Length}");
        }
        public static void ShiftArrayValues(int[] numbers)
        {
            for(int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = numbers[i + 1];
            }
            numbers[numbers.Length - 1] = 0;
        }

        public static object[] NumToString(int[] numbers)
        {
            object[] newArr = new object[numbers.Length];
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] < 0)
                    newArr[i] = "Dojo";
                else
                    newArr[i] = numbers[i];
            }
            return newArr;
        }

    }
}