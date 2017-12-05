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
                Add(new KaartItemBaseClass() { Beschrijving = string.Format("ItemID {0}", Rand.Next(10, 100)), InteractieRichting = (KaartItemBaseClass.Richting)Rand.Next(0, 4) });
            }

        }
        public override string ToString()
        {
            var desc = String.Empty;
            foreach (var item in this)
            {
                desc += String.Format("{0} {1}",item, Environment.NewLine);
            }
            return desc;
        }
    }
}
