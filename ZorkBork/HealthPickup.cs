using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZorkBork.Wrappers;

namespace ZorkBork
{
    [XmlInclude(typeof(Interactable))]
    public class HealthPickup : Interactable
    {
        public override void Interact(Speler speler)
        {
            speler.VerhoogOfVerlaagHealth(100);
            Console.WriteLine("je hebt een health pickup gescoord!!!");
        }
    }
}
