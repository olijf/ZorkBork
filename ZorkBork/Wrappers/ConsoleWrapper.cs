using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork.Wrappers
{
    public static class ConsoleWrapper
    {
        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey(true);
        }

        public static void Write(object data)
        {
            Console.Write(data);
        }
        public static void WriteLine(object data)
        {
            Console.WriteLine(data);
        }
    }
}
