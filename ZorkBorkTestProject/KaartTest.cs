using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.RegularExpressions;
using ZorkBork;

namespace ZorkBorkTestProject
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class KaartTest
    {
        [TestMethod]
        public void CreateKaartItemsCollectionObject()
        {
            var kaartItems = new Kaart();
            Assert.IsNotNull(kaartItems);
        }
        [TestMethod]
        public void AddKaartItemsToCollection()
        {
            var kaartItems = new Kaart();
            kaartItems.Add(new KaartItem());
            Assert.AreEqual(1, kaartItems.Count);
        }
        [TestMethod]
        public void RemoveKaartItemsFromCollection()
        {
            var kaartItems = new Kaart();
            var kaartItem = new KaartItem();
            kaartItems.Add(kaartItem);
            kaartItems.Remove(kaartItem);
            Assert.AreEqual(0, kaartItems.Count);
        }
        [TestMethod]
        public void VulKaartMetitems()
        {
            var kaartItems = new Kaart();
            kaartItems.MaakNieuweKaart();
            Assert.AreEqual(32, kaartItems.Count);
        }
        [TestMethod]
        public void LaatKaartZien()
        {
            var kaartItems = new Kaart();
            kaartItems.Add(new KaartItem());
            kaartItems.Add(new KaartItem());
            kaartItems.Add(new KaartItem());
            Console.Write(kaartItems.ToString());
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                Console.Write(kaartItems);
                Assert.AreEqual(kaartItems.Count, Regex.Matches(writer.ToString(), Environment.NewLine).Count);

            }
        }
    }
}
