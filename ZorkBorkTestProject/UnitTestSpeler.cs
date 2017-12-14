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
            speler.VerhoogOfVerlaagScore(100);
            Assert.AreEqual(100, speler.Score);
        }

        [TestMethod]
        public void VerlaagScorePositief()
        {
            var speler = new Speler();
            speler.VerhoogOfVerlaagScore(100);
            speler.VerhoogOfVerlaagScore(-50);
            Assert.AreEqual(50, speler.Score);
        }

        [TestMethod]
        public void VerlaagScoreKanNietNegatief()
        {
            var speler = new Speler();
            speler.VerhoogOfVerlaagScore(-50);
            speler.VerhoogOfVerlaagScore(-100);
            Assert.AreEqual(0, speler.Score);
        }

        [TestMethod]
        public void VeranderHealth()
        {
            var speler = new Speler();
            speler.VerhoogOfVerlaagHealth(-50);
            speler.VerhoogOfVerlaagHealth(25);
            Assert.AreEqual(75, speler.Health);
        }

        [TestMethod]
        public void HealthBoundCheckKleinerDanNul()
        {
            var speler = new Speler();
            speler.VerhoogOfVerlaagHealth(-500);
            Assert.AreEqual(0, speler.Health);
        }

        [TestMethod]
        public void HealthBoundCheckGroterDanHonderd()
        {
            var speler = new Speler();
            speler.VerhoogOfVerlaagHealth(500);
            Assert.AreEqual(100, speler.Health);
        }

        [TestMethod]
        public void VoegSleutelToe()
        {
            var speler = new Speler();
            speler.VoegSleutelToe("Sleutel");
            Assert.AreEqual("Sleutel", speler.Sleutels[0]);
        }

        [TestMethod]
        public void ResetSpelerScoreCheck()
        {
            var speler = new Speler();
            speler.VerhoogOfVerlaagScore(50);
            speler.ResetSpeler();
            Assert.AreEqual(0, speler.Score);
        }

        [TestMethod]
        public void ResetSpelerHealthCheck()
        {
            var speler = new Speler();
            speler.VerhoogOfVerlaagHealth(-50);
            speler.ResetSpeler();
            Assert.AreEqual(0, speler.Health);
        }

        [TestMethod]
        public void ResetSpelerSleutelCheck()
        {
            var speler = new Speler();
            speler.VoegSleutelToe("Sleutel");
            speler.ResetSpeler();
            Assert.AreEqual(0, speler.Sleutels.Count);
        }
    }
}
