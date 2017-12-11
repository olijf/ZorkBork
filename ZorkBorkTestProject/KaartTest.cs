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
                    return @"..\..\..\MapFinal.xml";

                };
                Assert.IsNotNull(Kaart.Instance);
            }
        }
        [TestMethod]
        public void RemoveKaartItemsFromCollection()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return @"..\..\..\MapFinal.xml";

                };
                Kaart.Instance.Clear();
                Assert.AreEqual(0, Kaart.Instance.Count);
            }
        }
        [TestMethod]
        public void LaatKaartZien()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return @"..\..\..\MapFinal.xml";

                };
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    Console.Write(Kaart.Instance);
                    Assert.AreEqual(Kaart.Instance.Count, Regex.Matches(writer.ToString(), Environment.NewLine).Count);

                }
            }
        }

        [TestMethod]
        public void IsPositieVeranderd()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return @"..\..\..\MapFinal.xml";

                };
                var voorNieuwePositie = Kaart.Instance.Positie;
                Kaart.Instance.UpdatePositie(Richting.Omhoog);
                Assert.AreNotSame(voorNieuwePositie, Kaart.Instance.Positie);
            }
        }

        [TestMethod]
        public void CheckOmhoog()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return @"..\..\..\MapFinal.xml";

                };

                ZorkBork.Fakes.ShimSettings.GetValueAsIntString = (_) =>
                {
                    return 10;

                };
                var voorOmhoog = Kaart.Instance.Positie;
                voorOmhoog.y += 1;
                Kaart.Instance.UpdatePositie(Richting.Omhoog);
                
                Assert.IsTrue(voorOmhoog.Equals(Kaart.Instance.Positie));
            }
        }
    }
}
