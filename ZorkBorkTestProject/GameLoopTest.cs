using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using ZorkBork;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class GameLoopTest
    {
        [TestMethod]
        public void CallBackTest()
        {
            var callBack = false;
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimKaart.LeesXMLString = (_) =>
                {
                    return KaartTest.CreateKaart2x2();
                };
                var gameLoop = new GameLoop(false);
                gameLoop.VerwerkInput(ConsoleKey.UpArrow, () => callBack = true);
                Assert.IsTrue(callBack);
            }
        }
        [TestMethod]
        public void TestDeleteKey()
        {
            var callBack = false;
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimKaart.LeesXMLString = (_) =>
                {
                    return KaartTest.CreateKaart2x2();
                };
                ZorkBork.Fakes.ShimGameLoop.AllInstances.SaveGame = (_) => { };
                var gameLoop = new GameLoop(false);
                gameLoop.VerwerkInput(ConsoleKey.Delete, () => callBack = true);
                Assert.IsFalse(callBack);
            }
        }

        [TestMethod]
        public void TestButtonE()
        {
            var callBack = false;
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimKaart.LeesXMLString = (_) =>
                {
                    return KaartTest.CreateKaart2x2();
                };
                ZorkBork.Fakes.ShimGameLoop.AllInstances.InteractMetHuidigeInteractable = (_) => { };
                var gameLoop = new GameLoop(false);
                gameLoop.VerwerkInput(ConsoleKey.E, () => callBack = true);
                Assert.IsTrue(callBack);
            }
        }
        [TestMethod]
        public void TestSaveGame()
        {
            var tempFile = @"map.xml";
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimKaart.LeesXMLString = (_) =>
                {
                    return KaartTest.CreateKaart2x2();
                };
                ZorkBork.Fakes.ShimSettings.GetValueString = (_) =>
                {
                    return tempFile;
                };
                var gameLoop = new GameLoop(false);
                gameLoop.SaveGame();
                Assert.IsTrue(File.Exists(tempFile));
                File.Delete(tempFile);
            }
        }
        [TestMethod]
        public void TestInteractableNietAanwezig()
        {
            using (ShimsContext.Create())
            {
                ZorkBork.Fakes.ShimKaart.LeesXMLString = (_) =>
                {
                    return new Kaart
                    {
                        SpeelVeldGrootte = 1,
                        KaartItemList = new List<KaartItem> {
                         new KaartItem { Beschrijving = "1"}
                        }
                    };
                };
                using (var stringWriter = new StringWriter())
                {
                    Console.SetOut(stringWriter);
                    var gameLoop = new GameLoop(false);
                    gameLoop.InteractMetHuidigeInteractable();
                    Assert.IsTrue(stringWriter.ToString().Contains("E is hier geen geldige keuze"));
                }
            }
        }
    }
}
