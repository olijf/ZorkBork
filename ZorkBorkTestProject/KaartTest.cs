using Microsoft.QualityTools.Testing.Fakes;
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

            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return @"C:\Users\Kruk\source\repos\ZorkBork\ZorkBork\bin\Debug\map.xml";

                };
                Assert.IsNotNull(Kaart.Instance);
            }
        }
        [TestMethod]
        public void AddKaartItemsToCollection()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
            {
                return @"C:\Users\Kruk\source\repos\ZorkBork\ZorkBork\bin\Debug\map.xml";

            };
                Kaart.Instance.Add(new KaartItem());
                Assert.AreEqual(101, Kaart.Instance.Count);
            }
        }
        [TestMethod]
        public void RemoveKaartItemsFromCollection()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return @"C:\Users\Kruk\source\repos\ZorkBork\ZorkBork\bin\Debug\map.xml";

                };
                var kaartItem = new KaartItem();
                Kaart.Instance.Clear();
                Assert.AreEqual(0, Kaart.Instance.Count);
            }
        }
        [TestMethod]
        public void VulKaartMetitems()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return @"C:\Users\Kruk\source\repos\ZorkBork\ZorkBork\bin\Debug\map.xml";

                };
                Kaart.Instance.MaakNieuweKaart();
                Assert.AreEqual(1, Kaart.Instance.Count);
            }
        }
        [TestMethod]
        public void LaatKaartZien()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return @"C:\Users\Kruk\source\repos\ZorkBork\ZorkBork\bin\Debug\map.xml";

                };
                Kaart.Instance.Add(new KaartItem());
                Kaart.Instance.Add(new KaartItem());
                Kaart.Instance.Add(new KaartItem());
                Console.Write(Kaart.Instance.ToString());
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    Console.Write(Kaart.Instance);
                    Assert.AreEqual(Kaart.Instance.Count, Regex.Matches(writer.ToString(), Environment.NewLine).Count);

                }
            }
        }
    }
}
