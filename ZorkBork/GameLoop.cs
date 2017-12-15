using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using ZorkBork.Wrappers;

namespace ZorkBork
{

    public class GameLoop
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
            ConsoleWrapper.WriteLine(_kaart.GetCurrentPosition());
            var interactieKey = ConsoleWrapper.ReadKey();
            VerwerkInput(interactieKey,VolgendeStap);
        }

        private void VerwerkInput(ConsoleKey interactieKey, Action callBack)
        {
            if (interactieKey == ConsoleKey.Delete)
            {
                SaveGame();
                return;
            }
            else if (interactieKey == ConsoleKey.E)
            {
                InteractMetHuidigeInteractable();
            }
            else if (interactieKey == ConsoleKey.Escape)
            {
                Afsluitmenu();
            }
            else
            {
                _kaart.UpdatePositie((Richting)interactieKey);
            }
            callBack();
        }

        private void Afsluitmenu()
        {
            Console.WriteLine("Weet je zeker dat je wilt afsluiten? (Y/N)");
            String input = Console.ReadLine();
            if (input == "Y")
            {
                Environment.Exit(0);
            }
            else if (input == "N")
            {
                Console.WriteLine("Afsluiten geannuleerd.");
            }
            else
            {
                Console.WriteLine("Kies \"Y\" of \"N\".");
                Afsluitmenu();
            }
        }

        private void SaveGame()
        {
            var serializer = new XmlSerializer(typeof(Kaart));
            using (var streamWriter = new StreamWriter(@"SaveGame.xml"))
            {
                serializer.Serialize(streamWriter, _kaart);
            }
        }

        private void InteractMetHuidigeInteractable()
        {
            var interactable = _kaart.GetCurrentPosition().GetInteractable();
            if (interactable != null)
            {
                interactable.Interact(_speler);
            }
            else
            {
                ConsoleWrapper.WriteLine("E is hier geen geldige keuze");
            }
        }
    }
}
