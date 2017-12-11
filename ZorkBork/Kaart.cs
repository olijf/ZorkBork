using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ZorkBork
{
    [XmlType]
    public class Kaart : List<KaartItem>
    {
        private static Kaart instance;
        [XmlAttribute("Positie")]
        public Positie Positie = new Positie { x = 0, y = 0 };

        private Kaart()
        {

        }
        public static Kaart Instance
        {
            get
            {
                if (instance == null)
                {
                    var serializer = new XmlSerializer(typeof(Kaart));
                    using (var streamReader = new StreamReader(Settings.GetValue("kaartBestand")))
                    {
                        instance = (Kaart)serializer.Deserialize(streamReader);
                        instance.SpeelVeldGrootte = Settings.GetValueAsInt("speelVeldGrootte");
                    };
                }
                return instance;
            }
        }
        [XmlAttribute("SpeelVeldGrootte")]
        public int SpeelVeldGrootte { get; set; }

        /*
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
        

        */
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
                    Positie.y = RichtingOK(richting, Positie.y + 1) ? Positie.y + 1 : Positie.y;
                    break;
                case Richting.Omlaag:
                    Positie.y = RichtingOK(richting, Positie.y - 1) ? Positie.y - 1 : Positie.y;
                    break;
                case Richting.Rechts:
                    Positie.x = RichtingOK(richting, Positie.x + 1) ? Positie.x + 1 : Positie.x;
                    break;
                case Richting.Links:
                    Positie.x = RichtingOK(richting, Positie.x - 1) ? Positie.x - 1 : Positie.x;
                    break;
            }
        }

        private bool RichtingOK(Richting richting, int bound)
        {
            var r = GetCurrentPosition().IsRichtingAllowed(richting);
            if(!r)
            Console.WriteLine("dat kan niet!");
            return r && BoundsCheck(bound);
        }

        private bool BoundsCheck(int nieuweWaarde)
        {
            if (nieuweWaarde < SpeelVeldGrootte && nieuweWaarde >= 0)
            {
                return true;
            }
            return false;
        }

        public KaartItem GetCurrentPosition()
        {
            return this[Positie.y * SpeelVeldGrootte + Positie.x];
        }
    }
}
