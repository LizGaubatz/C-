using System;

namespace RandomPassGen.Models
{
    public class Password
    {
        public static Random rand = new Random();

        public static string Main = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public string WordPass;

        public Password()
        {
            for (int i = 0; i < 11; i++)
            {
                char r = Main[rand.Next(0, Main.Length)];
                WordPass += r;
            }
            
        }
    }
}