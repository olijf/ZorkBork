using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Configuration;

namespace ZorkBork
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(Kaart));
            var kaartItemsCollection = new Kaart();
            int grootte;
            int.TryParse(ConfigurationManager.AppSettings["speelVeldGrootte"], out grootte);
            kaartItemsCollection.SpeelVeldGrootte = grootte;
            kaartItemsCollection.MaakNieuweKaart();
            var kaartBestandsNaam = ConfigurationManager.AppSettings["kaartBestand"];
            using (var streamWriter = new StreamWriter(kaartBestandsNaam))
            {
                serializer.Serialize(streamWriter, kaartItemsCollection);
            }
            using (var streamReader = new StreamReader(kaartBestandsNaam))
            {
                Kaart kaartItems = (Kaart)serializer.Deserialize(streamReader);
                Console.WriteLine(kaartItems);

            }
            /*
            var playerPoint = new Positie(0, 0);
            for (; ; )
            {
                Console.WriteLine(kaartItemsCollection.GetKaartItemAt(playerPoint.x, playerPoint.y));
                var interactieKey = Console.ReadKey().Key;
                switch (interactieKey)
                {
                    case ConsoleKey.LeftArrow:
                        if (kaartItemsCollection.GetKaartItemAt(playerPoint.x, playerPoint.y).InteractieRichting == Richting.Links)
                        {
                            playerPoint.y--;
                        }
                        else
                        {
                            Console.WriteLine("Kan Niet!!!");
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (kaartItemsCollection.GetKaartItemAt(playerPoint.x, playerPoint.y).InteractieRichting == Richting.Omhoog)
                            playerPoint.x++;
                        else
                            Console.WriteLine("Kan Niet!!!");
                        break;
                    case ConsoleKey.RightArrow:
                        if (kaartItemsCollection.GetKaartItemAt(playerPoint.x, playerPoint.y).InteractieRichting == Richting.Rechts)
                            playerPoint.y++;
                        else
                            Console.WriteLine("Kan Niet!!!");
                        break;
                    case ConsoleKey.DownArrow:
                        if (kaartItemsCollection.GetKaartItemAt(playerPoint.x, playerPoint.y).InteractieRichting == Richting.Omlaag)
                            playerPoint.x--;
                        else
                            Console.WriteLine("Kan Niet!!!");
                        break;
                    case ConsoleKey.Delete:
                        Environment.Exit(0);
                        break;
                }
            }*/
        }
    }
}
