using System;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;

namespace ZorkBork
{
    class Program
    {
        static void Main(string[] args)
        {
            var restoreSaveGame = false;
            if (File.Exists(Settings.GetValue("saveGameFile")))
            {
                Console.WriteLine("Wil je verder gaan met je vorige spel? Toets Enter:");
                restoreSaveGame = Console.ReadKey().Key == ConsoleKey.Enter;
            }

            var gameLoop = new GameLoop(restoreSaveGame);
            gameLoop.VolgendeStap();
        }
    }
}