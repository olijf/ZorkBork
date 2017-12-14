using ZorkBork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class UnitTestsVijand
    {

        [TestMethod]
        public void CheckScore()
        {
            var speler = new Speler();
            var vijand = new Vijand();
            vijand.Interact(speler);
            Assert.IsTrue(speler.Score == 200 || speler.Score == 0);
        }

        [TestMethod]
        public void CheckHealth()
        {
            var speler = new Speler();
            var vijand = new ZorkBork.Vijand();
            vijand.Interact(speler);
            Assert.IsTrue(speler.Health == 100 || speler.Score == 75);
        }
    }
}
