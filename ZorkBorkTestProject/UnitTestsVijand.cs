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
            var vijand = new Vijand();

            using (ShimsContext.Create())
            {

                ZorkBork.Fakes.ShimRandomWrapper.GetRandomNumber = () =>
                {
                    return 3;
                };

                vijand.Interact(speler);

                Assert.AreEqual(200, speler.Score);

            }
        }

        [TestMethod]
        public void CheckHealthAndScoreWhenLost()
        {
            var speler = new Speler();
            var vijand = new Vijand();

            using (ShimsContext.Create())
            {

                ZorkBork.Fakes.ShimRandomWrapper.GetRandomNumber = () =>
                {
                    return 8;
                };

                vijand.Interact(speler);

                Assert.AreEqual(0, speler.Score);
                Assert.AreEqual(75, speler.Health);

            }
        }
    }
}
