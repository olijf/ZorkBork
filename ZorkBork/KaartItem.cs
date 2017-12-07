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
        public override string ToString()
        {
            return String.Format("Je staat in {0} je kan de volgende richting uit {1}", Beschrijving, InteractieRichting);
        }
    }
}
