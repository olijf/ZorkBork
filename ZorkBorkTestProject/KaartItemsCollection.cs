using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
    }
}
