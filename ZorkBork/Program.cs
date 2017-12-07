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

            //Kaart laden
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

            //Initieren speler 
            var speler = new Speler();

            //Game loop
            var GL = new GameLoop(kaartItemsCollection, speler);

            GL.Start();
            }
        }
    }
}
