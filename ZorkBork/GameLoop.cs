using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{

    class GameLoop
    {
        private Kaart _kaartItemsCollection;
        private Speler _speler;

        public GameLoop(Kaart kaartItemsCollection, Speler speler)
        {
            _kaartItemsCollection = kaartItemsCollection;
            _speler = speler;
        }

        public void Start()
        {
            for (; ; )
            {
                Console.WriteLine(_kaartItemsCollection.GetCurrentPosition());
                var interactieKey = Console.ReadKey().Key;
                if (interactieKey == ConsoleKey.Delete)
                {
                    //Exit game
                    Environment.Exit(0);

                }
                else
                {
                    _kaartItemsCollection.UpdatePositie((Richting)interactieKey);
                }
            }
        }
    }
}
