using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class KaartItemsCollection : List<KaartItemBaseClass>
    {
        public void MaakNieuweKaart()
        {
            var Rand = new Random();
            for (int i = 0; i < 32; i++)
            {
                Add(new KaartItemBaseClass() { Beschrijving = string.Format("ItemID {0}", Rand.Next(10, 100)) });
            }

        }
        public override string ToString()
        {
            foreach (var item in this)
            {
                var desc = new String.Format("Je staat in {0} je kan de volgende acties uitvoeren {1}", item.Beschrijving, item.);
            }
            return 
        }
    }
}
