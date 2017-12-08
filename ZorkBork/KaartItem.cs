using System;
using System.Collections.Generic;
using System.Xml.Serialization;

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


        public void Interact()
        {
            throw new NotImplementedException();
        }

        public bool InteractionHasHappened()
        {
            
            throw new NotImplementedException();
        }
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
                returnString += String.Format("{0} ",item);
            }
            return returnString;
        }
    }
}
