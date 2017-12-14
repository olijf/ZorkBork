using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class Vijand : Interactable
    {
        public override void Interact(Speler speler)
        {
            int randomNumber = RandomWrapper.GetRandomNumber();

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
