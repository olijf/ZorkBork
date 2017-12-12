using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkBork.Extensions
{
    static class ListExtensions
    {
        public static T Pop<T>(this List<T> list)
        {
            T r;
            if (list.Count > 0)
            {
                r = list.First();
                list.Remove(list.First());
                return r;
            }
            return default(T);
        }
    }
}
