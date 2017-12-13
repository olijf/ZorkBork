using System;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;

namespace ZorkBork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game loop
            var gameLoop = new GameLoop();

            gameLoop.VolgendeStap();
        }
    }
}
