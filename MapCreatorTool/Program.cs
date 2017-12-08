using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MapCreatorTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(ZorkBork.Kaart));
            var kaartItemsCollection = ZorkBork.Kaart.Instance;
            kaartItemsCollection.SpeelVeldGrootte = 10;
            var kaartItemRichting = new List<ZorkBork.Richting>();
            kaartItemRichting.Add(ZorkBork.Richting.Omlaag);
            var kaartItem = new ZorkBork.KaartItem()
            {
                Beschrijving = String.Empty,
                InteractieRichting = kaartItemRichting
            };

            kaartItemsCollection.Add(kaartItem);
            for (; ; )
            {
                Console.WriteLine(kaartItemsCollection.AsDrawing());
                var interactieKey = Console.ReadKey().Key;
                switch (interactieKey)
                {
                    case ConsoleKey.LeftArrow:

                        AddNewKaartItem(kaartItemsCollection, ZorkBork.Richting.Links);
                        break;
                    case ConsoleKey.UpArrow:
                        AddNewKaartItem(kaartItemsCollection, ZorkBork.Richting.Omhoog);
                        break;
                    case ConsoleKey.RightArrow:
                        AddNewKaartItem(kaartItemsCollection, ZorkBork.Richting.Rechts);
                        break;
                    case ConsoleKey.DownArrow:
                        AddNewKaartItem(kaartItemsCollection, ZorkBork.Richting.Omlaag);
                        break;
                    case ConsoleKey.Spacebar:
                        AddNewKaartItem(kaartItemsCollection, ZorkBork.Richting.Leeg);
                        break;
                    case ConsoleKey.Delete:
                        using (var streamWriter = new StreamWriter(@"map.xml"))
                        {
                            serializer.Serialize(streamWriter, kaartItemsCollection);
                        }
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void AddNewKaartItem(ZorkBork.Kaart kaartItemsCollection, ZorkBork.Richting Richting)
        {
            var kaartItemRichting1 = new List<ZorkBork.Richting>();
            kaartItemRichting1.Add(Richting);
            var kaartItem1 = new ZorkBork.KaartItem()
            {
                Beschrijving = String.Empty,
                InteractieRichting = kaartItemRichting1
            };

            kaartItemsCollection.Add(kaartItem1);
        }
    }
}
