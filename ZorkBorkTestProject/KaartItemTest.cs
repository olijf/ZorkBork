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
        public void GetNullInteractableFromKaartItem()
        {
            var interactable = new KaartItem().GetInteractable();
            Assert.IsNull(interactable);
        }

        [TestMethod]
        public void GetInteractableFromKaartItem()
        {
            var kaartItem = new KaartItem();
            kaartItem.Beschrijving = "TestBoodschap";
            var interactable = new HealthPickup();
            kaartItem.interacties.Add(interactable);
            Assert.AreEqual(interactable,kaartItem.GetInteractable());
        }
    }
}
