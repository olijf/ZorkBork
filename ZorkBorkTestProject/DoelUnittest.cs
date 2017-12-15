using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class DoelUnittest
    {
        [TestMethod]
        public void MyTestMethod()
        {

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                //var gameLoop = new GameLoop(false);
                //gameLoop.InteractMetHuidigeInteractable();
                Assert.IsTrue(stringWriter.ToString().Contains("E is hier geen geldige keuze"));
            }
        }
    }
}
