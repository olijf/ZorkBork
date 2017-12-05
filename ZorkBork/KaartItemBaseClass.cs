using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    public class KaartItemBaseClass
    {
        public enum Interactie
        {   
            BeweegOmhoog,
            BeweegOmlaag,
            BeweegRechts,
            BeweegLinks
        };
        private string beschrijving;
        
        public string Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }
        private Interactie interactie;

        public Interactie InteractieRichting
        {
            get { return interactie; }
            set { interactie = value; }
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
