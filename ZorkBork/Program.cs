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
            var kaartItemsList = new Kaart();
            int.TryParse(ConfigurationManager.AppSettings["speelVeldGrootte"], out int grootte);
            kaartItemsList.SpeelVeldGrootte = grootte;
            kaartItemsList.MaakNieuweKaart();
            var kaartBestandsNaam = ConfigurationManager.AppSettings["kaartBestand"];
            using (var streamWriter = new StreamWriter(kaartBestandsNaam))
            {
                serializer.Serialize(streamWriter, kaartItemsList);
            }
            using (var streamReader = new StreamReader(kaartBestandsNaam))
            {
                Kaart kaartItems = (Kaart)serializer.Deserialize(streamReader);
                Console.WriteLine(kaartItems);

            }

            //Initieren speler 
            var speler = new Speler();

            //Game loop
            var GL = new GameLoop(kaartItemsList, speler);

            GL.Start();
        }
    }
}
