using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZorkBork
{
    [XmlType]
    public class Kaart : List<KaartItem>
    {

        public void MaakNieuweKaart()
        {
            var Rand = new Random();
            for (int i = 0; i < 36; i++)
            {
                var nieuwKaartItem = new KaartItem();
                nieuwKaartItem.Beschrijving = string.Format("Discription {0}", i);
                nieuwKaartItem.InteractieRichting.Add((Richting)Rand.Next(0, 4));
                nieuwKaartItem.InteractieRichting.Add((Richting)Rand.Next(0, 4));
                Add(nieuwKaartItem);
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

        /*public KaartItem GetNewLocation(KaartItem current, Richting richting)
        {
            //var stepSize = 1 * (int.Parse(richting) % 2 == 0) ? Math.Sqrt(this.Count) : 1;
            return this[this.IndexOf(current) + stepSize];
        }
        */
        public KaartItem GetKaartItemAt(int x, int y)
        {
            if (x < 0 || x > 6 || y < 0 || y > 6)
            {
                return this[0];
            }
            return this[x * 6 + y];
        }
    }
}
