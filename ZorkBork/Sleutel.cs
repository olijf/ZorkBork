﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork
{
    class Sleutel : IInteractable
    {

        public override void Interact(Speler speler)
        {
            speler.VoegSleutelToe("De sleutel");
        }
    }
}
