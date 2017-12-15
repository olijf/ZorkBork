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
            int randomNumber = Wrappers.RandomWrapper.GetRandomNumber();

            //0-4 = win, 5-9 = lose

            if(randomNumber < 5)
            {
                speler.VerhoogOfVerlaagScore(200);
                Console.WriteLine("Gewonnen!\nScore: {0}\nHealth: {1}", speler.Score, speler.Health);
            } else
            {
                speler.VerhoogOfVerlaagScore(-200);
                speler.VerhoogOfVerlaagHealth(-25);
                Console.WriteLine("Verloren:(\nScore: {0}\nHealth: {1}", speler.Score, speler.Health);
            }
        }
    }
}
