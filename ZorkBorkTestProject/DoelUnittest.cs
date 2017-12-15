using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using ZorkBork;

namespace ZorkBorkTestProject
{
    [TestClass]
    public class DoelUnittest
    {
        [TestMethod]
        public void DoelTest()
        {

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                var doel = new Doel();
                var speler = new Speler();
                doel.Interact(speler);
                Assert.IsTrue(stringWriter.ToString().Contains("GESLAAGD"));
            }
        }
    }
}
