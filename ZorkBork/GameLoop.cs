using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
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

        public void VolgendeStap()
        {
            // https://stackoverflow.com/a/2611529
            Console.WriteLine(Kaart.Instance.GetCurrentPosition());
            /*
            foreach (var item in Kaart.Instance.KaartItemList)
            {
                item.interacties.Add(new HealthPickup());
                item.interacties.Add(new ScorePickup());
                item.interacties.Add(new Vijand());
                item.interacties.Add(new Doel());
            }
            */
            var interactieKey = Console.ReadKey().Key;
            if (interactieKey == ConsoleKey.Delete)
            {
                var serializer = new XmlSerializer(typeof(Kaart));
                using (var streamWriter = new StreamWriter(@"map.xml"))
                {
                    serializer.Serialize(streamWriter, Kaart.Instance);
                }
                Environment.Exit(0);
            }
            else if (interactieKey == ConsoleKey.E)
            {
                var interactable = Kaart.Instance.GetCurrentPosition().GetInteractable();
                if (interactable != null)
                {
                    interactable.Interact(_speler);
                }
                else { 
                    Console.WriteLine("E is hier geen geldige keuze");
                }
            }
            else
            {
                Kaart.Instance.UpdatePositie((Richting)interactieKey);
            }
            VolgendeStap();
        }
    }
}
