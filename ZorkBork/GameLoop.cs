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

        public void Start()
        {
            for (; ; )
            {
                Console.WriteLine(Kaart.Instance.GetCurrentPosition());
                var interactieKey = Console.ReadKey().Key;
                if (interactieKey == ConsoleKey.Delete)
                {
                    //Exit game
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
