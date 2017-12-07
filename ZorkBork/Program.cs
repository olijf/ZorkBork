using System;
using System.IO;
using System.Xml.Serialization;

namespace ZorkBork
{
    class Program
    {
        static void Main(string[] args)
        {

            //Kaart laden
            var serializer = new XmlSerializer(typeof(Kaart));
            var kaartItemsCollection = new Kaart();
            kaartItemsCollection.MaakNieuweKaart();
            using (var streamWriter = new StreamWriter(@"map.xml"))
            {
                serializer.Serialize(streamWriter, kaartItemsCollection);
            }
            using (var streamReader = new StreamReader(@"map.xml"))
            {
                Kaart kaartItems = (Kaart)serializer.Deserialize(streamReader);
                Console.WriteLine(kaartItems);

            }

            //Initieren speler 
            var speler = new Speler();

            //Game loop
            var GL = new GameLoop(kaartItemsCollection, speler);

            GL.Start();
            }
        }
    }
}
