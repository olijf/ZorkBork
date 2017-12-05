using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class KaartItemBaseClass
    {
        public enum Richting
        {   
            Omhoog,
            Omlaag,
            Rechts,
            Links
        };
        private string beschrijving;
        
        public string Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }
        private Richting interactieRichting;

        public Richting InteractieRichting
        {
            get { return interactieRichting; }
            set { interactieRichting = value; }
        }


        public void Interact()
        {
            throw new NotImplementedException();
        }

        public bool InteractionHasHappened()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return String.Format("Je staat in {0} je kan de volgende richting uit {1}", Beschrijving, InteractieRichting);
        }
    }
}
