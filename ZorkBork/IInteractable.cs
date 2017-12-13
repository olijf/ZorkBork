using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorkBork
{
    public abstract class IInteractable
    {

        public abstract void Interact(Speler speler);

    }
}
