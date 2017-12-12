﻿using System;
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
