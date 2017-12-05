using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    class Program
    {
        static void Main(string[] args)
        {
            var kaartItemsCollection = new KaartItemsCollection();
            kaartItemsCollection.MaakNieuweKaart();
            Console.WriteLine(kaartItemsCollection.ElementAt(1));
            int interactieKey;
            interactieKey = Console.Read();
        }
    }
}
