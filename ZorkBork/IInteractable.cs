﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    interface IInteractable
    {

        void Interact(Speler speler);

      /*   private bool _beschikbaar;
         private T _waarde;

        public Interactable(T waarde);
        {
            _beschikbaar = true;
            _waarde = waarde;
        }

        abstract public T Gebruik();
            {
                _beschikbaar = false;
                return _waarde;
            }

        abstract public bool IsBeschikbaar();
        {
            return _beschikbaar;
        }*/

    }
}