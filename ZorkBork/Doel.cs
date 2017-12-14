using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZorkBork.Wrappers;

namespace ZorkBork
{
    public class Doel : Interactable
    {
        public override void Interact(Speler speler)
        {
            ConsoleWrapper.WriteLine("------------------MISSIE GESLAAGD!------------------");
            ConsoleWrapper.WriteLine("Score: " + speler.Score);
            ConsoleWrapper.WriteLine(string.Empty);
            ConsoleWrapper.WriteLine(string.Empty);
            ConsoleWrapper.WriteLine("Druk op Esc om af te sluiten.");
            while(true)
            {
                var info = ConsoleWrapper.ReadKey();
                if (info == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
