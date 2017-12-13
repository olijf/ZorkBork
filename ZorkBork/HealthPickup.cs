using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorkBork
{
    [XmlInclude(typeof(IInteractable))]
    public class HealthPickup : IInteractable
    {
        public override void Interact(Speler speler)
        {
            speler.VerhoogOfVerlaagHealth(100);
            Console.WriteLine("je hebt een health pickup gescoord!!!");
        }
    }
}
