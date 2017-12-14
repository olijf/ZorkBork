﻿using System;
using System.IO;
using System.Xml.Serialization;
using ZorkBork.Wrappers;

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
            ConsoleWrapper.WriteLine(_kaart.GetCurrentPosition());
            var interactieKey = ConsoleWrapper.ReadKey();
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
            else
            {
                _kaart.UpdatePositie((Richting)interactieKey);
            }
            callBack();
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
                ConsoleWrapper.WriteLine("E is hier geen geldige keuze");
            }
        }
    }
}
