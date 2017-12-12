using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{

    class GameLoop
    {
        private static GameLoop instance;
        public static GameLoop Instance
        {
            get
            {
                if (instance != null)
                {
                    instance = new GameLoop();
                }
                return instance;
            }
        }
        private GameLoop() { }
        public void VolgendeStap()
        {
            // https://stackoverflow.com/a/2611529
            Console.WriteLine(Kaart.Instance.GetCurrentPosition());
            var interactieKey = Console.ReadKey().Key;
            if (interactieKey == ConsoleKey.Delete)
            {
                Environment.Exit(0);
            }
            else if (interactieKey == ConsoleKey.E)
            {
                Kaart.Instance.GetCurrentPosition().Interact();
            }
            else
            {
                Kaart.Instance.UpdatePositie((Richting)interactieKey);
            }
            VolgendeStap();
        }
    }
}
