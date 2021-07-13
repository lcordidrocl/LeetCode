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
        public static int[] Second = { 1,2,2,3,1,4,2 }; // Degree 3 , Output = 6
        public static int[] Third = { 1, 2, 3, 4, 5, 6, 7, 8, 9}; // Degree 1 , Output = 1
    }

    /// <summary>
    /// This class holds all the data related to the frecuency of a number in the array, which is
    /// - number
    /// - frecuency
    /// - lowest index
    /// - highest index
    /// </summary>
    public class NumData
    {
        public NumData(int index)
        {
            Frecuency = 1;
            LowestIndex =  index;
            HighestIndex = index; 
        }

        public int Frecuency { get; private set; }
        public int LowestIndex { get; private set; }
        public int HighestIndex { get; private set; }

        public int Length 
        {
            get
            {
                return HighestIndex - LowestIndex + 1;
            }
        }

        public void Count(int index)
        {
            Frecuency++;
            HighestIndex = index;
        }
    }

    // To Do:
    // Think the best way to iterate the array, with all possible combinations [ _ ------- ~ ] , [ ~ ------- _ ] [---- ~ --_--]
    // Do not need to iterate! need to store index on which the number starts or ends in the array, and take the minimun difference between higher i and lower i, between all the arrays that had same length

    // What To Do Involves:
    // iterate at least 1 time all the array.
    // While doing so, need to count repetead numbers
    // The most repetead is the degree.

    public static class DegreeOfAnArrayLogicHelper
    {
        public const int LogicArraySize = 50000;
        public static int GetMnimunArrayLengthForArrayDegree(int[] array)
        {
            int degree = 1;
            int index = 0;
            int lowestInnerArrayLength = 1;

            {
                NumData[] trackingArray = new NumData[LogicArraySize];


                // Process current number
                foreach (int i in array)
                {
                    if (trackingArray[i] is null)
                    {
                        trackingArray[i] = new NumData(index);
                    }
                    else
                    {
                        trackingArray[i].Count(index);

                        if (trackingArray[i].Frecuency > degree)
                        {
                            degree = trackingArray[i].Frecuency;
                            lowestInnerArrayLength = trackingArray[i].Length;
                        }
                        else
                        {
                            if (trackingArray[i].Length < lowestInnerArrayLength && trackingArray[i].Frecuency.Equals(degree))
                            {
                                lowestInnerArrayLength = trackingArray[i].Length;
                            }
                        }
                    }

                    index++;
                }

                // Log Status
                for (int i = 0; i < trackingArray.Length; i++)
                {
                    if (trackingArray[i] != null)
                    {
                        Console.WriteLine($"Degree for { i }: { trackingArray[i].Frecuency }");
                        Console.WriteLine($"Lowest index: {trackingArray[i].LowestIndex}");
                        Console.WriteLine($"Highest index: {trackingArray[i].HighestIndex}");
                        Console.WriteLine($"Array Length {trackingArray[i].Length}");
                    }
                }
                
                Console.WriteLine($"Degree of the array = {degree}");
                Console.WriteLine($"Minimun Length of the inner array = {lowestInnerArrayLength}");

                return lowestInnerArrayLength;
            }
        }
    }
    public static class Problem
    {
        public static int Run(int[] array) 
        {
            return DegreeOfAnArrayLogicHelper.GetMnimunArrayLengthForArrayDegree(array);
        }
    }
}

