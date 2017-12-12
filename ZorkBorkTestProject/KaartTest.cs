﻿using Microsoft.QualityTools.Testing.Fakes;
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
                ZorkBork.Fakes.ShimSettings.GetValueAsIntString = (_) =>
                {
                    return 10;

                };
                Assert.IsNotNull(Kaart.Instance);
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
                ZorkBork.Fakes.ShimSettings.GetValueAsIntString = (_) =>
                {
                    return 10;

                };
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    Console.Write(Kaart.Instance);
                    Assert.AreEqual(Kaart.Instance.KaartItemList.Count, Regex.Matches(writer.ToString(), Environment.NewLine).Count);

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
                ZorkBork.Fakes.ShimSettings.GetValueAsIntString = (_) =>
                {
                    return 10;

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

        [TestMethod]
        public void CheckUpdatePositieFailed()
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
                var voorLinks = Kaart.Instance.Positie;
                Kaart.Instance.UpdatePositie(Richting.Links);

                Assert.AreEqual(voorLinks, Kaart.Instance.Positie);
            }
        }
        [Ignore]
        public void RemoveKaartItemsFromCollection()
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
                Kaart.Instance.KaartItemList.Clear();
                Assert.AreEqual(0, Kaart.Instance.KaartItemList.Count);
            }
        }
    }
}
