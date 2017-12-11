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
            //Initieren speler 
            var speler = new Speler();

            //Game loop
            var gameLoop = new GameLoop(speler);

            gameLoop.VolgendeStap();
        }
    }
}
