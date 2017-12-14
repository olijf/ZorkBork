using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ZorkBork
{
    [XmlType]
    public class Kaart
    {
        private Kaart instance;

        [XmlElement]
        public Positie Positie = new Positie { x = 0, y = 0 };

        [XmlElement]
        public int SpeelVeldGrootte;

        [XmlElement("KaartItem")]
        public List<KaartItem> KaartItemList = new List<KaartItem>();
        
        public static Kaart LeesXML()
        {
            Kaart result = null;
            var serializer = new XmlSerializer(typeof(Kaart));
            using (var streamReader = new StreamReader(Settings.GetValue("kaartBestand")))
            {
                result = (Kaart)serializer.Deserialize(streamReader);
            };
            return result;
        }

        public override string ToString()
        {
            var desc = String.Empty;
            foreach (var item in KaartItemList)
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
            if (!r)
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
            return KaartItemList[Positie.y * SpeelVeldGrootte + Positie.x];
        }
    }
}
