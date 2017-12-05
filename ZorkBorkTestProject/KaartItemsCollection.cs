using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZorkBork;

namespace ZorkBorkTestProject
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class KaartItemsCollectionTest
    {
        [TestMethod]
        public void CreateKaartItemsCollectionObject()
        {
            var kaartItems = new KaartItemsCollection();
            Assert.IsNotNull(kaartItems);
        }
        [TestMethod]
        public void AddKaartItemsToCollection()
        {
            var kaartItems = new KaartItemsCollection();
            kaartItems.Add(new KaartItemBaseClass());
            Assert.AreEqual(1, kaartItems.Count);
        }
        [TestMethod]
        public void RemoveKaartItemsFromCollection()
        {
            var kaartItems = new KaartItemsCollection();
            var kaartItem = new KaartItemBaseClass();
            kaartItems.Add(kaartItem);
            kaartItems.Remove(kaartItem);
            Assert.AreEqual(0, kaartItems.Count);
        }
        [TestMethod]
        public void VulKaartMetitems()
        {
            var kaartItems = new KaartItemsCollection();
            kaartItems.MaakNieuweKaart();
            Assert.AreEqual(32, kaartItems.Count);
        }
        [TestMethod]
        public void LaatKaartZien()
        {
            var kaartItems = new KaartItemsCollection();
            kaartItems.MaakNieuweKaart();
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                Console.Write(kaartItems.ToString());
                Assert.AreEqual(kaartItems.ToString(), writer.ToString());
            }
        }
    }
}
