using System;
using System.Linq;

namespace ZorkBork
{
    class Program
    {
        static void Main(string[] args)
        {
            var kaartItemsCollection = new Kaart();
            kaartItemsCollection.MaakNieuweKaart();
            var playerPoint = new Positie(0, 0);
            for (; ; )
            {
                Console.WriteLine(kaartItemsCollection.GetKaartItemAt(playerPoint.x,playerPoint.y));
                var interactieKey = Console.ReadKey().Key;
                switch (interactieKey)
                {
                    case ConsoleKey.LeftArrow:
                        playerPoint.y--;
                        break;
                    case ConsoleKey.UpArrow:
                        playerPoint.x++;
                        break;
                    case ConsoleKey.RightArrow:
                        playerPoint.y++;
                        break;
                    case ConsoleKey.DownArrow:
                        playerPoint.x--;
                        break;
                    case ConsoleKey.Delete:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
