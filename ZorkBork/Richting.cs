using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZorkBork
{
    public enum Richting
    {
        Links = ConsoleKey.LeftArrow,
        Omhoog = ConsoleKey.UpArrow,
        Rechts = ConsoleKey.RightArrow,
        Omlaag = ConsoleKey.DownArrow,
        Leeg
    }
}