using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBorkTestProject
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class RandomWrapperTest
    {
        [TestMethod]
        public void RandomTest()
        {
            var blah = ZorkBork.Wrappers.RandomWrapper.GetRandomNumber();
            Assert.IsNotNull(blah);
        }
    }
}
