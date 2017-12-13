using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class ScorePickup : IInteractable
    {

        public override void Interact(Speler speler)
        {
            speler.VerhoogOfVerlaagScore(100);
        }

    }
}
