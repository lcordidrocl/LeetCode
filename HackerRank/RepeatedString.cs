using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackeRank
{
    public static class RepeatedString
    {
        public static long repeatedString(string s, long n)
        {
            long amountOfAsInString = s.Count(c => c.Equals('a'));
            long amountOfAsInSubString = 0;

            int subStringIndex = (int)(n % s.Length);

            if (subStringIndex > 0)
            {
                string subString = s.Substring(0, subStringIndex);
                amountOfAsInSubString = subString.Count(c => c.Equals('a'));
            }

            long multiplyFactor = n / (s.Length);
            long total = amountOfAsInString * multiplyFactor + amountOfAsInSubString;

            return total;
        }
    }
}
