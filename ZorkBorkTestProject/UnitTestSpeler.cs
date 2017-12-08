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
            var speler = new Speler();
            Assert.IsNotNull(speler);
        }

        [TestMethod]
        public void PlayerScoreIsZero()
        {
            var speler = new Speler();
            Assert.AreEqual(0, speler.Score);
        }

        [TestMethod]
        public void VerhoogScore()
        {
            var speler = new Speler();
            speler.VerhoogScore(100);
            Assert.AreEqual(100, speler.Score);
        }

        [TestMethod]
        public void VerlaagScorePositief()
        {
            var speler = new Speler();
            speler.VerhoogScore(100);
            speler.VerlaagScore(50);
            Assert.AreEqual(50, speler.Score);
        }

        [TestMethod]
        public void VerlaagScoreKanNietNegatief()
        {
            var speler = new Speler();
            speler.VerlaagScore(50);
            Assert.AreEqual(0, speler.Score);
        }

        [TestMethod]
        public void ResetScore()
        {
            var speler = new Speler();
            speler.VerhoogScore(50);
            speler.ResetScore();
            Assert.AreEqual(0, speler.Score);
        }
    }
}
