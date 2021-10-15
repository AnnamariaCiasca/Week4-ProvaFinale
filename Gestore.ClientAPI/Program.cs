using System;

namespace Gestore.ClientAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Premi un tasto quando le API sono partite.");
            Console.ReadKey();

            MainMenu.Start();
        }
    }
}
