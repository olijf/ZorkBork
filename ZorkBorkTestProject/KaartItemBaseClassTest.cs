using System;
using ZorkBork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class KaartItemBaseClassTest
    {
        [TestMethod]
        public void CreateKaartItemBaseClassTest()
        {
            var kaartItemBaseClass = new KaartItemBaseClass();
            Assert.IsNotNull(kaartItemBaseClass);
        }

        [TestMethod]
        public void AddDiscriptionKaartItemBaseClassTest()
        {
            var kaartItemBaseClass = new KaartItemBaseClass();
            kaartItemBaseClass.Beschrijving = "test beschrijving";
            Assert.AreEqual("test beschrijving", kaartItemBaseClass.Beschrijving);
        }

        [TestMethod]
        public void InteractWithKaartItemBaseClass()
        {
            var kaartItemBaseClass = new KaartItemBaseClass();
            kaartItemBaseClass.Interact();
            Assert.IsTrue(kaartItemBaseClass.InteractionHasHappened());
        }
    }
}
