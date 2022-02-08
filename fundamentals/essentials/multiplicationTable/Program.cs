using System;

namespace multiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
        int[,] mTable = new int[10, 10];
        for (int row = 0; row < 10; row++)
            for (int col = 0; col < 10; col++)
            {
                mTable[row, col] = (row + 1) * (col + 1);
                Console.Write(mTable[row,col]);
                if (col < 9) Console.Write("\t");
                else Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
