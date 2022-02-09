using System;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<object> newList = new List<object>();
            newList.Add(7);
            newList.Add(28);
            newList.Add(-1);
            newList.Add(true);
            newList.Add("chair");

            System.Console.WriteLine(newList);

            int num = 0;
            foreach (var obj in newList)
            {
                System.Console.WriteLine(obj);
                if(obj is int) {
                    num += (int) obj;
                }
            }
            System.Console.WriteLine(num);
        }
    }
}
