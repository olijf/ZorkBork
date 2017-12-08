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
            //Initieren speler 
            var speler = new Speler();
            Kaart.Instance.SpeelVeldGrootte = 10;

            var serializer = new XmlSerializer(typeof(ZorkBork.Kaart));
            using (var streamWriter = new StreamWriter(@"map1.xml"))
            {
                serializer.Serialize(streamWriter, Kaart.Instance);
            }

            //Game loop
            var GL = new GameLoop(speler);

            GL.Start();
        }
    }
}
