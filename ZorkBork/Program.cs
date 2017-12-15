using System;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Threading;

namespace ZorkBork
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeLoading();

            var restoreSaveGame = false;
            if (File.Exists(Settings.GetValue("saveGameFile")))
            {
                Console.WriteLine("Wil je verder gaan met je vorige spel? Toets Enter:");
                restoreSaveGame = Console.ReadKey().Key == ConsoleKey.Enter;
            }

            var gameLoop = new GameLoop(restoreSaveGame);
            gameLoop.VolgendeStap();
        }

        private static void FakeLoading()
        {

            Console.WriteLine("ZorkBork Laden...");
            for (int i = 0; i < 66; i++)
            {
                if(i <= 40 && i >= 30)
                {
                    Thread.Sleep(500);
                    Console.Write("▒");
                }
                Thread.Sleep(50);
                Console.Write("▒");
            }
            Console.WriteLine();
            Console.Write("Laden voltooid!");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}