using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class ScorePickup : Interactable
    {

        public override void Interact(Speler speler)
        {
            speler.VerhoogOfVerlaagScore(100);
        }

    }
}
