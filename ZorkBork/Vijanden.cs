using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZorkBork
{

    public class Vijand : KaartItem
    {
        public new void Interact()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Konijn : Vijand
    {
    }

    public class Olifant : Vijand
    {
    }

    public class Pelikaan : Vijand
    {
    }
}