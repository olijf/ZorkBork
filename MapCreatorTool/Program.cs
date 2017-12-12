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
        public static string AsDrawing()
        {
            var desc = String.Empty;
            for (int i = 0; i < ZorkBork.Kaart.Instance.KaartItemList.Count; i++)
            {
                //todo fix uitprint dingus
                //desc += String.Format("{0}{1}", InteractieRichtingSymbool(ZorkBork.Kaart.Instance[i].InteractieRichting.[0]), "\t");
                if (i % ZorkBork.Kaart.Instance.SpeelVeldGrootte == 0)
                    desc += Environment.NewLine;
            }
            return desc;

        }
        private string InteractieRichtingSymbool(List<ZorkBork.Richting> interactieRichting)
        {
            switch (interactieRichting[0])
            {
                case ZorkBork.Richting.Omhoog:
                    return "▲";
                case ZorkBork.Richting.Omlaag:
                    return "▼";
                case ZorkBork.Richting.Rechts:
                    return "►";
                case ZorkBork.Richting.Links:
                    return "◄";
                default:
                    return " ";
            }
        }
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

            kaartItemsCollection.KaartItemList.Add(kaartItem);
            for (; ; )
            {
                Console.WriteLine(AsDrawing());
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
            var kaartItemRichting = new List<ZorkBork.Richting>();
            kaartItemRichting.Add(Richting);
            var kaartItem1 = new ZorkBork.KaartItem()
            {
                Beschrijving = String.Empty,
                InteractieRichting = kaartItemRichting
            };

            kaartItemsCollection.KaartItemList.Add(kaartItem1);
        }


    }
}
