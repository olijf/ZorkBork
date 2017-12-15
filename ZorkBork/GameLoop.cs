using Colorful;
using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using Console = Colorful.Console;

namespace ZorkBork
{

    public class GameLoop
    {
        private Speler _speler;
        private Kaart _kaart;

        public GameLoop(bool restoreSaveGame)
        {
            //Initieren speler 
            _speler = new Speler();
            if (restoreSaveGame)
                _kaart = Kaart.LeesXML(Settings.GetValue("saveGameFile"));
            else
                _kaart = Kaart.LeesXML(Settings.GetValue("kaartBestand"));
        }

        public void VolgendeStap()
        {
            StyleSheet styleSheet = new StyleSheet(Color.White);
            styleSheet.AddStyle("Je kan de volgende richting uit:", Color.MediumSlateBlue);
            styleSheet.AddStyle("Je kunt interacteren", Color.Red);
            Console.WriteLineStyled(_kaart.GetCurrentPosition().ToString(), styleSheet);
            var interactieKey = Console.ReadKey().Key;
            VerwerkInput(interactieKey, VolgendeStap);
        }

        public void VerwerkInput(ConsoleKey interactieKey, Action callBack)
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
            var input = Console.ReadKey().Key;
            if (input == ConsoleKey.Y)
            {
                Environment.Exit(0);
            }
            else if (input == ConsoleKey.N)
            {
                Console.WriteLine("Afsluiten geannuleerd.");
            }
            else
            {
                Console.WriteLine("Kies \"Y\" of \"N\".");
                Afsluitmenu();
            }
        }

        public void SaveGame()
        {
            var serializer = new XmlSerializer(typeof(Kaart));
            using (var streamWriter = new StreamWriter(Settings.GetValue("saveGameFile")))
            {
                serializer.Serialize(streamWriter, _kaart);
            }
        }

        public void InteractMetHuidigeInteractable()
        {
            var interactable = _kaart.GetCurrentPosition().GetInteractable();
            if (interactable != null)
            {
                interactable.Interact(_speler);
            }
            else
            {
                Console.WriteLine("E is hier geen geldige keuze");
            }
        }
    }
}
