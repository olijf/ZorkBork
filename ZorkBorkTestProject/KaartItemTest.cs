using ZorkBork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class KaartItemTest
    {
        [TestMethod]
        public void CreateKaartItemBaseClassTest()
        {
            var kaartItemBaseClass = new KaartItem();
            Assert.IsNotNull(kaartItemBaseClass);
        }

        [TestMethod]
        public void AddDiscriptionKaartItemBaseClassTest()
        {
            var kaartItemBaseClass = new KaartItem();
            kaartItemBaseClass.Beschrijving = "test beschrijving";
            Assert.AreEqual("test beschrijving", kaartItemBaseClass.Beschrijving);
        }

        [TestMethod]
        public void InteractWithKaartItemBaseClass()
        {
            var kaartItemBaseClass = new KaartItem();
            kaartItemBaseClass.Interact();
            Assert.IsTrue(kaartItemBaseClass.InteractionHasHappened());
        }
    }
}
