using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZorkBork;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class UnitTestSpeler
    {
        [TestMethod]
        public void SpelerClassExists()
        {
            var speler = Speler.Instance;
            Assert.IsNotNull(speler);
        }

        [TestMethod]
        public void PlayerScoreIsZero()
        {
            var speler = Speler.Instance;
            Assert.AreEqual(0, speler.Score);
        }

        [TestMethod]
        public void VerhoogScore()
        {
            var speler = Speler.Instance;
            speler.VerhoogScore(100);
            Assert.AreEqual(100, speler.Score);
        }

        [TestMethod]
        public void VerlaagScorePositief()
        {
            var speler = Speler.Instance;
            speler.VerhoogScore(100);
            speler.VerlaagScore(50);
            Assert.AreEqual(150, speler.Score);
        }

        [TestMethod]
        public void VerlaagScoreKanNietNegatief()
        {
            var speler = Speler.Instance;
            speler.VerlaagScore(50);
            speler.VerlaagScore(100);
            Assert.AreEqual(0, speler.Score);
        }

        [TestMethod]
        public void ResetScore()
        {
            var speler = Speler.Instance;
            speler.VerhoogScore(50);
            speler.ResetScore();
            Assert.AreEqual(0, speler.Score);
        }
    }
}
