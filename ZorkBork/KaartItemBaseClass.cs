using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class KaartItemBaseClass
    {
        private string beschrijving;
        
        public string Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }

        public bool InteractionHasHappened()
        {
            throw new NotImplementedException();
        }
    }
}
