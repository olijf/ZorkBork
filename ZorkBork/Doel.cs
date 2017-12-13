using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class Doel : Interactable
    {
        public override void Interact(Speler speler)
        {
            Console.WriteLine("------------------MISSIE GESLAAGD!------------------");
            Console.WriteLine("Score: " + speler.Score);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Druk op Esc om af te sluiten.");
            while(true)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
