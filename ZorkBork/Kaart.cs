using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZorkBork
{
    [XmlType]
    public class Kaart : List<KaartItem>
    {
        public int SpeelVeldGrootte { get; set; }

        public void MaakNieuweKaart()
        {
            var Rand = new Random();
            for (int i = 0; i < SpeelVeldGrootte * SpeelVeldGrootte; i++)
            {
                var nieuwKaartItem = new KaartItem();
                nieuwKaartItem.Beschrijving = string.Format("Discription {0}", i);
                var nieuwRichting = new List<Richting>();
                nieuwRichting.Add((Richting)Rand.Next(0, 3));
                nieuwRichting.Add((Richting)Rand.Next(0, 3));
                nieuwKaartItem.InteractieRichting = nieuwRichting;
                Add(nieuwKaartItem);
            }

        }

        public string AsDrawing()
        {
            var desc = String.Empty;
            for (int i = 0; i < Count; i++)
            {
                desc += String.Format("{0}{1}", InteractieRichtingSymbool(this[i].InteractieRichting), "\t");
                if (i % SpeelVeldGrootte == 0)
                    desc += Environment.NewLine;
            }
            return desc;

        }

        private string InteractieRichtingSymbool(List<Richting> interactieRichting)
        {
            switch (interactieRichting[0])
            {
                case Richting.Omhoog:
                    return "▲";
                case Richting.Omlaag:
                    return "▼";
                case Richting.Rechts:
                    return "►";
                case Richting.Links:
                    return "◄";
                default:
                    return " ";
            }
        }

        public override string ToString()
        {
            var desc = String.Empty;
            foreach (var item in this)
            {
                desc += String.Format("{0} {1}", item, Environment.NewLine);
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
            if (x < 0 || x > SpeelVeldGrootte || y < 0 || y > SpeelVeldGrootte)
            {
                return this[0];
            }
            return this[x * SpeelVeldGrootte + y];
        }
    }
}
