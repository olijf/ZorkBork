﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Richting> interactieRichting = new List<Richting>();

        [XmlElement]
        public List<Richting> InteractieRichting
        {
            get { return interactieRichting; }
            set { interactieRichting = value; }
        }

        [XmlArray("InterActies")]
        [XmlArrayItem(nameof(HealthPickup), typeof(HealthPickup))]
        [XmlArrayItem(nameof(ScorePickup), typeof(ScorePickup))]
        [XmlArrayItem(nameof(Doel), typeof(Doel))]
        [XmlArrayItem(nameof(Vijand), typeof(Vijand))]
        public List<Interactable> interacties = new List<Interactable>();

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
            string returnString = String.Format("{0}{1}Je kan de volgende richting uit: ", Beschrijving, Environment.NewLine);
            foreach (var item in InteractieRichting)
            {
                returnString += String.Format("{0} ", item);
            }
            if (interacties.Count > 0)
            {
                returnString += String.Format("{0}Je kunt interacteren ", Environment.NewLine);
                foreach (var item in interacties)
                {
                    returnString += String.Format("{0} ", item);
                }
            }
            return returnString;
        }
        public Interactable GetInteractable()
        {
            return interacties.Pop();
        }
    }
}
