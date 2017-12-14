using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZorkBork;

namespace ZorkBorkTestProject.Comparers
{
    public class KaartComparer : IEqualityComparer<Kaart>
    {
        private KaartItemComparer comparer;
        public KaartItemComparer Comparer
        {
            get
            {
                if (comparer == null)
                    comparer = new KaartItemComparer();
                return comparer;
            }
        }
        public bool Equals(Kaart x, Kaart y)
        {
            if (x == null || y == null)
                return false;

            if (!x.Positie.Equals(y.Positie))
                return false;

            if (x.SpeelVeldGrootte != y.SpeelVeldGrootte)
                return false;

            if (x.KaartItemList.Count != y.KaartItemList.Count)
                return false;

            return !x.KaartItemList.Where((t, i) => !Comparer.Equals(t, y.KaartItemList[i])).Any();
        }

        public int GetHashCode(Kaart obj)
        {
            return obj.GetHashCode();
        }
    }

}
