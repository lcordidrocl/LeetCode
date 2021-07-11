using System;

namespace LeetCode.DegreeOfAnArray
{
    /// <summary>
    /// Degree of an Array: max frequency of any of it's elements ( the element that appear most)
    /// Find the minimun length of a contiguous array within the same array, that can have the same degree as the total array
    /// 
    /// 
    /// Constraints:
    /// nums.length will be between 1 and 50,000.
    /// nums[i] will be an integer between 0 and 49,999.
    /// </summary>
    public static class Examples
    {
        public static int[] One = { 1, 2, 2, 3, 1 }; // Degree 2 , Output = 2 {2,2}
    }

    // To Do:
    // Determine the Degree of the array
    // Find all the SubArrays that have the same Degree as Input
    // Get the shortest length of the selected ones

    // What To Do Involves:
    // iterate at least 1 time all the array.
    // While doing so, need to count repetead numbers
    // The most repetead is the degree.

    public static class DegreeOfAnArrayLogicHelper
    {
        public const int LogicArraySize = 50000;
        public static int GetDegree(int[] array)
        {
            int degree = 0;
            {
                int[] trackingArray = new int[LogicArraySize];
                
                // Process current number
                foreach (int i in array)
                {
                    if (trackingArray[i].Equals(0))
                    {
                        trackingArray[i] = 1;
                    }
                    else
                    {
                        trackingArray[i] += 1;
                    }
                    // If MaxDegree update degree
                    if (trackingArray[i] > degree)
                    {
                        degree = trackingArray[i];
                    }
                }

                // Log Status
                for (int i = 0; i < trackingArray.Length; i++)
                {
                    if (trackingArray[i] != 0)
                    {
                        Console.WriteLine($"int { i } is { trackingArray[i] } times in the Array");
                    }
                }
                
                Console.WriteLine($"Degree of the array = {degree}");

                return degree;
            }
        }
    }
    public static class Problem
    {
        public static int Run(int[] array) 
        {
            DegreeOfAnArrayLogicHelper.GetDegree(array);
            return 1;
        }
    }
}

