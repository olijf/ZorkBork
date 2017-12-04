using System;
using ZorkBork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class KaartItemsTest
    {
        [TestMethod]
        public void ItemTest()
        {
            KaartItemBaseClass blah = new KaartItemBaseClass();
            blah.Beschrijving = "Hoi Testboodschap";
            Assert.AreEqual("Hoi Testboodschap",blah.Beschrijving);
        }

    }
}
