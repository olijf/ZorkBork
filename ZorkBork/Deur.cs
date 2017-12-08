using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZorkBork
{
    public class Deur : KaartItem
    {
        public new void Interact()
        {
            Console.WriteLine("krakaa");
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