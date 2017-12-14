using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork.Wrappers
{
    public class RandomWrapper
    {
        private static Random _random;

        public RandomWrapper()
        {
            _random = new Random();
        }

        public static int GetRandomNumber()
        {
            return _random.Next(0, 10);
        }
    }
}
