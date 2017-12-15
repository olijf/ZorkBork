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

            if (File.Exists(Settings.GetValue("saveGameFile")))
            {
                Console.WriteLine("Wil je verder gaan met je vorige spel? Toets Enter:");
                bool restoreSaveGame = Console.ReadKey().Key == ConsoleKey.Enter;

                var gameLoop = new GameLoop(restoreSaveGame);
                gameLoop.VolgendeStap();
            }
        }
    }
}
