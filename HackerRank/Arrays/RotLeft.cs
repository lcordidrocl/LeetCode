using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackeRank.Arrays
{
    public static class RotLeft
    {
        public static List<int> rotLeft(List<int> a, int d)
        {
            var unchangedList = a.Skip(d);
            var leftSortedList = unchangedList.Concat(a.Take(d)).ToList();
            return leftSortedList;
        }
    }
}
