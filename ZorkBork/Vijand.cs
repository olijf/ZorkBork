using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    class Vijand : IInteractable
    {
        public override void Interact(Speler speler)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 10);

            //0-4 = win, 5-9 = lose

            if(randomNumber < 5)
            {
                speler.VerhoogOfVerlaagScore(200);
            } else
            {
                speler.VerhoogOfVerlaagScore(-200);
                speler.VerhoogOfVerlaagHealth(-25);
            }
        }
    }
}
