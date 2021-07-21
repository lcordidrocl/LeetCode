using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackeRank
{
    /// <summary>
    /// JobCity.segment(3, new List<int>() { 2, 5, 4, 6, 8 }); -> should return 3
    /// </summary>
    public static class JobCity
    {
        /// <summary>
        /// MissUnderstood the algorithm.
        /// This code returns the max of the sum
        /// I had to return only the max of the minimuns of each segment.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="space"></param>
        /// <returns></returns>
        public static int segment(int x, List<int> space)
        {
            if (x.Equals(1))
            {
                return space.Max();
            }

            int currentTotalMinSpace = int.MaxValue;
            int currentMaxWithinSlot = int.MinValue;
            int maxSpaceWithinMinimunMemorySlot = 0;
            int currentComputingFreeSpace = 0;

            for (int computerSegment = 0; computerSegment <= space.Count - x; computerSegment++)
            {
                for (int slotInSgement = 0; slotInSgement < x; slotInSgement++)
                {
                    if (space[slotInSgement + computerSegment] > currentMaxWithinSlot)
                    {
                        currentMaxWithinSlot = space[slotInSgement];
                    }
                }

                if (currentComputingFreeSpace < currentTotalMinSpace)
                {
                    currentTotalMinSpace = currentComputingFreeSpace;
                    maxSpaceWithinMinimunMemorySlot = currentMaxWithinSlot;
                }
                
                else if (currentComputingFreeSpace.Equals(currentTotalMinSpace) && currentMaxWithinSlot > maxSpaceWithinMinimunMemorySlot)
                {
                    maxSpaceWithinMinimunMemorySlot = currentMaxWithinSlot;
                }

                currentComputingFreeSpace = 0;
                currentMaxWithinSlot= 0;
            }

            return maxSpaceWithinMinimunMemorySlot;
        }

        public static int segmentOutOfInterview(int x, List<int> space)
        {
            if (x.Equals(1))
            {
                return space.Max();
            }
            
            for (int currentSpace = 0; currentSpace < space.Count - x; currentSpace++)
            {
                space[currentSpace] = space.TakeLast(space.Count - currentSpace).Take(x).Min();
            }

            return space.Take(space.Count - x).Max();
        }
    }
}
