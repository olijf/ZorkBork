using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZorkBork;

namespace ZorkBorkTestProject
{

    [TestClass]
    public class UnitTestsScore
    {
        [TestMethod]
        public void CheckScoreverhoging()
        {
            var speler = new Speler();
            var scorePickup = new ScorePickup();

            scorePickup.Interact(speler);

            Assert.AreEqual(scorePickup.GetScore(), speler.Score);
        }
    }
}
