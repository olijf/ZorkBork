using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ZorkBork.Extensions;
namespace ZorkBork
{
    [XmlType]
    public class KaartItem
    {

        private string beschrijving;

        [XmlElement]
        public string Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }
        private List<Richting> interactieRichting;

        [XmlElement]
        public List<Richting> InteractieRichting
        {
            get { return interactieRichting; }
            set { interactieRichting = value; }
        }
        [XmlElement]
        public List<IInteractable> interacties;

        public bool IsRichtingAllowed(Richting richting)
        {
            foreach (var item in interactieRichting)
            {
                if (richting == item)
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            string returnString = String.Format("Je staat in {0} je kan de volgende richting uit: ", Beschrijving);
            foreach (var item in InteractieRichting)
            {
                returnString += String.Format("{0} ", item);
            }
            if (interacties.Count > 0)
            {
                returnString += String.Format("{0}daarnaast kan je ", Environment.NewLine);
                foreach (var item in interacties)
                {
                    returnString += String.Format("{0} ", item);
                }
            }
            return returnString;
        }

        public IInteractable GetInteractable()
        {
            return interacties.Pop();
        }
    }
}
