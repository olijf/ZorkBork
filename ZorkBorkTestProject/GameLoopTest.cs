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
        [TestMethod]
        public void CallBackTest()
        {
            var callBack = false;
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimKaart.LeesXMLString = (_) =>
                {
                    return KaartTest.CreateKaart2x2();
                };
                var gameLoop = new GameLoop(false);
                gameLoop.VerwerkInput(ConsoleKey.UpArrow, () => callBack = true);
                Assert.IsTrue(callBack);
            }
        }
        [TestMethod]
        public void AnderTestTestDieNogMoetWordenGevuld()
        {
            var callBack = false;
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimKaart.LeesXMLString = (_) =>
                {
                    return KaartTest.CreateKaart2x2();
                };
                var gameLoop = new GameLoop(false);
                gameLoop.VerwerkInput(ConsoleKey.UpArrow, () => callBack = true);
                Assert.IsTrue(callBack);
            }
        }

    }
}
