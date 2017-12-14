using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZorkBork;

namespace ZorkBorkTestProject.Comparers
{
    public class KaartItemComparer : IEqualityComparer<KaartItem>
    {
        public bool Equals(KaartItem x, KaartItem y)
        {
            if (x == null || y == null)
                return false;

            if (x.Beschrijving != y.Beschrijving)
                return false;

            if (x.InteractieRichting.Count != y.InteractieRichting.Count)
                return false;

            if (x.interacties.Count != y.interacties.Count)
                return false;

            if (x.interacties.Where((t, i) => t.Equals(y.interacties[i])).Any())
                return false;

            return !x.InteractieRichting.Where((t, i) => !t.Equals(y.InteractieRichting[i])).Any();

        }

        public int GetHashCode(KaartItem obj)
        {
            return obj.GetHashCode();
        }
    }

}
