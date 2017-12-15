using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class ScorePickup : Interactable
    {
        private int _score = 100;

        public override void Interact(Speler speler)
        {
            speler.VerhoogOfVerlaagScore(_score);
        }

        public int GetScore()
        {
            return _score;
        }
    }
}
