using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START");

            Ninja newNinja = new Ninja("lizard", 5,5);
            Wizard newWizard = new Wizard("harry", 10,10);
            Samurai newSamuari = new Samurai("jennifer", 10,10,10);

// TESTING


            newSamuari.DispayInfo();
            newNinja.Attack(newSamuari);
            newSamuari.DispayInfo();
            newWizard.Attack(newSamuari);
            newSamuari.DispayInfo();
            System.Console.WriteLine("---- attacking ----");
            newWizard.DispayInfo();
            newSamuari.Attack(newWizard);
            newWizard.DispayInfo();
            System.Console.WriteLine("---- meditating ----");
            newSamuari.DispayInfo();
            newSamuari.Meditate();
            newSamuari.DispayInfo();
            System.Console.WriteLine("---- stealing ----");
            newNinja.DispayInfo();
            newNinja.Steal(newSamuari);
            newNinja.DispayInfo();
        }
    }
}