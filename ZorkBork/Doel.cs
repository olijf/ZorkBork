using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    class Doel : IInteractable
    {
        public override void Interact(Speler speler)
        {
            Console.WriteLine("------------------MISSIE GESLAAGD!------------------");
            Console.WriteLine("Score: " + speler.Score);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Druk op Esc om af te sluiten.");
            ConsoleKeyInfo info = Console.ReadKey();
            while(true)
            {
                if (info.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
