using System;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = new int[]
            {
                23, 34, 12, 51, 1, 2, -1, -244, 1000
            };
            // Example of calling Basic13 Methods
            int[] odds = Basic.OddArray();
            object[] objArr = Basic.NumToString(testArray);
        }
    }
}