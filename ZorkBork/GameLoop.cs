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
        private Kaart _kaart;

        public GameLoop()
        {
            //Initieren speler 
            _speler = new Speler();
            _kaart = Kaart.LeesXML();            
        }

        public void VolgendeStap()
        {
            // https://stackoverflow.com/a/2611529
            Console.WriteLine(_kaart.GetCurrentPosition());
            /*
            foreach (var item in _kaart.KaartItemList)
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
                    serializer.Serialize(streamWriter, _kaart);
                }
                Environment.Exit(0);
            }
            else if (interactieKey == ConsoleKey.E)
            {
                var interactable = _kaart.GetCurrentPosition().GetInteractable();
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
                _kaart.UpdatePositie((Richting)interactieKey);
            }
            VolgendeStap();
        }
    }
}
