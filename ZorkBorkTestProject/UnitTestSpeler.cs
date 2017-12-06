using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            speler.verhoogScore(100);
            Assert.AreEqual(100, speler.Score);
        }

        [TestMethod]
        public void VerlaagScorePositief()
        {
            var speler = new Speler();
            speler.verhoogScore(100);
            speler.verlaagScore(50);
            Assert.AreEqual(50, speler.Score);
        }

        [TestMethod]
        public void VerlaagScoreNegatief()
        {
            var speler = new Speler();
            speler.verlaagScore(50);
            Assert.AreEqual(0, speler.Score);
        }

        [TestMethod]
        public void ResetScore()
        {
            var speler = new Speler();
            speler.verhoogScore(50);
            speler.resetScore();
            Assert.AreEqual(0, speler.Score);
        }
    }
}
