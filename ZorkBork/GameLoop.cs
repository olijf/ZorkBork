using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{

    class GameLoop
    {
        private Speler _speler;

        public GameLoop(Speler speler)
        {
            _speler = speler;
        }

        public void Run()
        {
            // https://stackoverflow.com/a/2611529
            while(true)
            {
                Console.WriteLine(Kaart.Instance.GetCurrentPosition());
                var interactieKey = Console.ReadKey().Key;
                if (interactieKey == ConsoleKey.Delete)
                {
                    Environment.Exit(0);

                }
                else
                {
                    Kaart.Instance.UpdatePositie((Richting)interactieKey);
                }
            }
        }
    }
}
