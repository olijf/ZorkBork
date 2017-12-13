using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class Sleutel : IInteractable
    {

        public override void Interact(Speler speler)
        {
            speler.VoegSleutelToe("De sleutel");
        }
    }
}
