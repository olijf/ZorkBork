using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZorkBork
{
    public class Sleutels : KaartItem
    {
    }

    public class Vijand : KaartItem
    {
        public new void Interact()
        {
            throw new System.NotImplementedException();
        }
    }
}