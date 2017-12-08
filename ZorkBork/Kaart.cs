using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZorkBork
{
    [XmlType]
    public class Kaart : List<KaartItem>
    {
        private Positie Positie;
        public Kaart()
        {
            Positie = new Positie(0, 0);
        }
        public int SpeelVeldGrootte { get; set; }

        public void MaakNieuweKaart()
        {
            var Rand = new Random();
            for (int i = 0; i < SpeelVeldGrootte * SpeelVeldGrootte; i++)
            {
                var nieuwKaartItem = new KaartItem();
                nieuwKaartItem.Beschrijving = string.Format("Discription {0}", i);
                var nieuwRichting = new List<Richting>();
                nieuwRichting.Add(Richting.Omhoog);
                nieuwRichting.Add(Richting.Omlaag);
                nieuwRichting.Add(Richting.Links);
                nieuwRichting.Add(Richting.Rechts);
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

        public void UpdatePositie(Richting richting)
        {
            switch (richting)
            {
                case Richting.Omhoog:
                    Positie.y = BoundsCheck(Positie.y + 1) ? Positie.y + 1 : Positie.y;
                    break;
                case Richting.Omlaag:
                    Positie.y = BoundsCheck(Positie.y - 1) ? Positie.y - 1 : Positie.y;
                    break;
                case Richting.Rechts:
                    Positie.x = BoundsCheck(Positie.x + 1) ? Positie.x + 1 : Positie.x;
                    break;
                case Richting.Links:
                    Positie.x = BoundsCheck(Positie.x - 1) ? Positie.x - 1 : Positie.x;
                    break;
            }
        }

        private bool BoundsCheck(int nieuweWaarde)
        {
            if (nieuweWaarde <= SpeelVeldGrootte || nieuweWaarde > 0)
                return false;
            return true;
        }

        public KaartItem GetCurrentPosition()
        {
            return this[Positie.x * SpeelVeldGrootte + Positie.y];
        }
    }
}
