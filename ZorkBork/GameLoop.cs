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
                Console.WriteLine(_kaartItemsCollection.GetKaartItemAt(_speler.Positie.X, _speler.Positie.Y));
                var interactieKey = Console.ReadKey().Key;
                switch (interactieKey)
                {
                    case ConsoleKey.LeftArrow:
                        _speler.UpdatePositie((int)Richting.Rechts);
                        break;
                    case ConsoleKey.UpArrow:
                        _speler.UpdatePositie((int)Richting.Omhoog);
                        break;
                    case ConsoleKey.RightArrow:
                        _speler.UpdatePositie((int)Richting.Rechts);
                        break;
                    case ConsoleKey.DownArrow:
                        _speler.UpdatePositie((int)Richting.Omlaag);
                        break;
                    case ConsoleKey.Delete:
                        //Exit game
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
