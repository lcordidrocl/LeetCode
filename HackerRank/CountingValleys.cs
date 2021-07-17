using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackeRank
{
    class CountingValleys
    {
        public static int countingValleys(int steps, string path)
        {
            int totalValleys = 0;
            char valleyStep = 'D';

            char currentHike = path[0];
            int totalUphillSteps = 0;
            int totalDownhillSteps = 0;

            for (int currentStep = 0; currentStep < steps; currentStep++)
            {
                // count
                if (path[currentStep].Equals(valleyStep))
                {
                    totalDownhillSteps += 1;
                }
                else
                {
                    totalUphillSteps += 1;
                }

                // reset? -> reset when totalUphillSteps.Equals(totalDownHillSteps)
                if (totalUphillSteps.Equals(totalDownhillSteps))
                {
                    totalUphillSteps = 0;
                    totalDownhillSteps = 0;

                    if (currentHike.Equals(valleyStep))
                    {
                        totalValleys += 1;
                    }

                    if (currentStep + 1 != steps)
                    {
                        currentHike = path[currentStep + 1];
                    }                    
                }
            }

            return totalValleys;
        }
    }
}
