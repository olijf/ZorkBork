using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZorkBork;
using ZorkBork.Wrappers;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class GameLoopTest
    {
        public void RunGame()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimKaart.LeesXML = () =>
                {
                    return KaartTest.CreateKaart2x2();
                };
                var gameLoop = new GameLoop();

                using (var writer = new StringWriter())
                {
                    gameLoop.
                    Console.SetOut(writer);
                }

            }
        }

    }
}
