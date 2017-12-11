using ZorkBork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class KaartItemTest
    {
        [TestMethod]
        public void CreateKaartItemTest()
        {
            var kaartItem = new KaartItem();
            Assert.IsNotNull(kaartItem);
        }

        [TestMethod]
        public void AddDiscriptionKaartItemTest()
        {
            var kaartItem = new KaartItem
            {
                Beschrijving = "test beschrijving"
            };
            Assert.AreEqual("test beschrijving", kaartItem.Beschrijving);
        }

        [TestMethod]
        public void InteractWithKaartClass()
        {
            var kaartItem = new KaartItem();
            kaartItem.Interact();
            Assert.IsTrue(kaartItem.InteractionHasHappened());
        }
    }
}
