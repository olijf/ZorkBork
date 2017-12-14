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
            var healthPickup = new HealthPickup();
            speler.VerhoogOfVerlaagHealth(-50);
            var healthVoorVerhoog = speler.Health;
            healthPickup.Interact(speler);

            Assert.AreNotEqual(healthVoorVerhoog, speler.Health);
        }
    }
}
