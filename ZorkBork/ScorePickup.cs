using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    class ScorePickup : IInteractable
    {

        public void Interact(Speler speler)
        {
            speler.VerhoogOfVerlaagScore(100);
        }

    }
}
