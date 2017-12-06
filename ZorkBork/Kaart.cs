using System;
using System.Collections.Generic;

namespace ZorkBork
{
    public class Kaart : List<KaartItem>
    {

        public void MaakNieuweKaart()
        {
            var Rand = new Random();
            for (int i = 0; i < 32; i++)
            {
                Add(new KaartItem() { Beschrijving = string.Format("ItemID {0}", Rand.Next(10, 100)), InteractieRichting = (Richting)Rand.Next(0, 4) });
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
