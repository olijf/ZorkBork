using ZorkBork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using System;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class UnitTestsVijand
    {

        [TestMethod]
        public void CheckScoreWhenWon()
        {
            var speler = new Speler();
            var spelerOud = speler;
            var vijand = new Vijand();

            using (ShimsContext.Create())
            {

                ZorkBork.Wrappers.Fakes.ShimRandomWrapper.GetRandomNumber = () =>
                {
                    return 3;
                };

                vijand.Interact(speler);

                Assert.AreEqual(spelerOud.Score, speler.Score);

            }
        }

        [TestMethod]
        public void CheckHealthAndScoreWhenLost()
        {
            var speler = new Speler();
            var spelerOud = speler;
            var vijand = new Vijand();

            using (ShimsContext.Create())
            {

                ZorkBork.Wrappers.Fakes.ShimRandomWrapper.GetRandomNumber = () =>
                {
                    return 8;
                };

                vijand.Interact(speler);

                Assert.AreEqual(spelerOud.Score, speler.Score);
                Assert.AreEqual(spelerOud.Health, speler.Health);

            }
        }
    }
}
