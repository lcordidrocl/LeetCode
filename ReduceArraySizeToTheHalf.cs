using System;
// https://leetcode.com/problems/reduce-array-size-to-the-half/
namespace LeetCode.ReduceArraySizeToTheHalf
{
    /// <summary>
    /// Constraints:
    /// 1) 1 <= arr.length <= 10^5
    /// 2) arr.length is even
    /// 3) 1 <= arr[i] <= 10^5
    /// </summary>
    public static class Constants
    {
        public const int MaxArraySize = 100000;
        public const int MaxArrayValue = 100000;
    }

    public static class Examples
    {
        public static int[] First = new int[] { 3, 3, 3, 3, 5, 5, 5, 2, 2, 7 };
        public static int[] Error1 = new int[] { 83540, 79940, 50658, 44620, 35146, 5842, 53172, 11867, 43496, 14991, 45916, 70814, 26510, 75319, 14226, 16099, 96652, 6339, 84655, 26270, 21110, 29451, 2541, 8098, 49688, 17237, 36937, 40975, 88382, 30544, 10152, 15235, 18140, 17523, 5125, 41399, 11001, 76986, 57821, 55723, 71103, 81290, 21120, 72293, 4229, 74250, 91623, 73878};
    }

    // 1) and 3) allows us to use the integer in the Array as the index of the IntAmountInArray[] within IntAmmountLogicProcessor
    public class IntAmountLogicProcessor
    {
        private int?[] IntsInArray { get; }
        private int _Result { get; set; } // default value ? -> should not allow inconsitence
        private int ArraySize { get; set; }

        /// <summary>
        /// this class is not reusable, we need to find a way to pass an array as paramater, and let the processor estimate the result
        /// </summary>
        public IntAmountLogicProcessor()
        {
            IntsInArray = new int?[Constants.MaxArraySize];
            ArraySize = 0;
        }

        #region Processing
        /// <summary>
        /// This could receive the Array as parameter, in that way we remove the coupling between the array defined in the logic processor, and the method
        /// </summary>
        /// <param name="i"></param>
        public void ProcessInt(int i)
        {
            //validate i matches condition 1)
            if (IntsInArray[i - 1] is null)
            {
                InitInt(i);
            }
            else
            {
                Count(i);
            }

            ArraySize += 1;
        }

        public void LogStatus()
        {
            for (int i = 0; i < IntsInArray.Length; i++)
            {
                if (IntsInArray[i] != null)
                {
                    Console.WriteLine($"int { i + 1 } is { IntsInArray[i] } times in the Array");
                }
            }
        }

        private void InitInt(int i)
        {
            // should validate i won't break the Array indexing
            IntsInArray[i - 1] = 1;
        }

        private void Count(int i)
        {
            IntsInArray[i - 1] += 1;
        }

        private int[] SortArray(int?[] array)
        {
            int[] result = new int[array.Length];

            // clean nulls
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    result[j] = (int)array[i];
                    j++;
                }
            }

            int temp;
            for (int i = 0; i < j; i++)
            {
                for (int k = 1 + i; k < j; k++)
                {
                    if (result[i] < result[k]) // Order Descending
                    {
                        temp = result[i];
                        result[i] = result[k];
                        result[k] = temp;
                    }
                }
            }
            return result;
        }

        #endregion

        #region Result
        public int GetResult()
        {
            return _Result;
        }
        public void GenerateResult()
        {
            // minimun amount of int in the set that removing them make the array be less than the have
            // I don't care which is the number that needs to be removed, I just care about what is the minimun amount of numbers I can remove and achive the goal
            int[] sortedArray = SortArray(IntsInArray);
            _Result = 1;

            int currentAmount = sortedArray[0];
            int s = 1;
            while (currentAmount < ArraySize / 2)
            {
                currentAmount += sortedArray[_Result];
                _Result++;
            }
        }
        #endregion
    }

    public static class Problem
    {
        public static int Run() 
        {
            IntAmountLogicProcessor intAmountLogicProcessor = new IntAmountLogicProcessor();

            foreach (int i in Examples.Error1)
            {
                intAmountLogicProcessor.ProcessInt(i);
            }

            intAmountLogicProcessor.LogStatus();
            intAmountLogicProcessor.GenerateResult();
            return intAmountLogicProcessor.GetResult();
        }
    }
}
