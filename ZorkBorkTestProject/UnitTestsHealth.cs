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
    public class UnitTestsHealth
    {

        [TestMethod]
        public void CheckHealthVerhogingNaPickup()
        {
            var speler = new Speler();
            var spelerOud = speler;
            var healthPickup = new HealthPickup();

            healthPickup.Interact(speler);

            Assert.AreEqual(spelerOud.Health, speler.Health);
        }
    }
}
