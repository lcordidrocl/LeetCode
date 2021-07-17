using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackeRank
{
    public static class JumpingOnClouds
    {

        public static List<int> Example1 = new List<int>() { 0, 0, 1, 0, 0, 1, 0 }; // Expect 4
        public static List<int> Example2 = new List<int>() {0,0,0,1,0,0}; //  Expect 3
        public static int jumpingOnClouds(List<int> c)
        {
            int minAmmountOfJumps = 0;
            int index = 0;

            int cumulus = 0;

            while (index < c.Count - 2)
            {
                index = c[index + 2].Equals(cumulus) ? index + 2 : index + 1;
                minAmmountOfJumps += 1;
            }

            if (index != c.Count - 1)
            {
                minAmmountOfJumps += 1;
            }

            return minAmmountOfJumps;
        }
    }
}
