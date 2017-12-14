﻿using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ZorkBork;
using ZorkBorkTestProject.Comparers;

namespace ZorkBorkTestProject
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class KaartTest
    {

        private static Kaart CreateKaart2x2()
        {
            return new Kaart
            {
                SpeelVeldGrootte = 2,
                KaartItemList = new List<KaartItem> {
                    new KaartItem { Beschrijving = "1", InteractieRichting = new List<Richting> { Richting.Omhoog, Richting.Rechts }, interacties = new List<Interactable> { new HealthPickup() } },
                    new KaartItem { Beschrijving = "2", InteractieRichting = new List<Richting> { Richting.Omhoog, Richting.Links }, interacties = new List<Interactable> { new HealthPickup() } },
                    new KaartItem { Beschrijving = "3", InteractieRichting = new List<Richting> { Richting.Omlaag, Richting.Rechts }, interacties = new List<Interactable> { new HealthPickup() } },
                    new KaartItem { Beschrijving = "4", InteractieRichting = new List<Richting> { Richting.Omlaag, Richting.Links }, interacties = new List<Interactable> { new HealthPickup() } }
                }
            };
        }
        [TestMethod]
        public void CreateKaartItemsCollectionObject()
        {
            var kaart = CreateKaart2x2();
            Assert.IsNotNull(kaart);
        }
        [TestMethod]
        public void SerializeKaart()
        {
            var expected = CreateKaart2x2();
            var serializer = new XmlSerializer(typeof(Kaart));
            using (var streamWriter = new StreamWriter(@"map.xml"))
            {
                serializer.Serialize(streamWriter, expected);
            }
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return @"map.xml";

                };

                var actual = Kaart.LeesXML();
                var compare = new KaartComparer().Equals(actual, expected);
                Assert.IsTrue(compare);
            }
        }
        [TestMethod]
        public void LaatKaartZien()
        {
            var kaart = new Kaart
            {
                SpeelVeldGrootte = 1,
                KaartItemList = new List<KaartItem> {
                    new KaartItem { Beschrijving = "1", InteractieRichting = new List<Richting> { Richting.Omhoog, Richting.Rechts }} }
            };
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                Console.Write(kaart);
                Assert.AreEqual(kaart.KaartItemList.Count, Regex.Matches(writer.ToString(), Environment.NewLine).Count);

            }
        }

        [TestMethod]
        public void IsPositieVeranderd()
        {
            var kaart = CreateKaart2x2();
            var voorNieuwePositie = kaart.Positie;
            kaart.UpdatePositie(Richting.Rechts);
            Assert.AreNotSame(voorNieuwePositie, kaart.Positie);
        }

        [TestMethod]
        public void CheckOmhoog()
        {
            var kaart = CreateKaart2x2();
            var voorOmhoog = kaart.Positie;
            voorOmhoog.y += 1;
            kaart.UpdatePositie(Richting.Omhoog);

            Assert.IsTrue(voorOmhoog.Equals(kaart.Positie));
        }
        [TestMethod]
        public void CheckUpdatePositieFailed()
        {
            var kaart = CreateKaart2x2();
            var voorLinks = kaart.Positie;
            kaart.UpdatePositie(Richting.Links);

        }
        [TestMethod]
        public void RemoveKaartItemsFromCollection()
        {
            var kaart = CreateKaart2x2();
            kaart.KaartItemList.Clear();
            Assert.AreEqual(0, kaart.KaartItemList.Count);
        }
    }
}