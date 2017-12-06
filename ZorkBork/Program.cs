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
            Console.WriteLine(kaartItemsCollection.ElementAt(1));
            int interactieKey;
            interactieKey = Console.Read();
        }
    }
}
