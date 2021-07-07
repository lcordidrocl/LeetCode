using System;

namespace LeetCode
{
    /// <summary>
    /// Constraints:
    /// 1) 1 <= arr.length <= 10^5
    /// 2) arr.length is even
    /// 3) 1 <= arr[i] <= 10^5
    /// </summary>
    public static class Constants
    {
        public const int MaxArraySize = 9999;
        public const int MaxArrayValue = 100000;
    }

    public static class Examples
    {
        public static int[] First = new int[] { 3, 3, 3, 3, 5, 5, 5, 2, 2, 7 };
    }

    // 1) and 3) allows us to use the integer in the Array as the index of the IntAmountInArray[] within IntAmmountLogicProcessor
    public class IntAmountLogicProcessor
    {
        private int?[] IntsInArray { get; }

        public IntAmountLogicProcessor()
        {
            IntsInArray = new int?[Constants.MaxArraySize];
        }

        public void ProcessInt(int i)
        {
            Console.WriteLine($"Processing int {i}");

            //validate i matches condition 1)
            if (IntsInArray[i - 1] is null)
            {
                InitInt(i);
            }
            else 
            {
                Count(i);
            }
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
    }
       
    class Program
    {
        
        static void Main(string[] args)
        {
            IntAmountLogicProcessor intAmountLogicProcessor = new IntAmountLogicProcessor();

            foreach (int i in Examples.First)
            {
                intAmountLogicProcessor.ProcessInt(i);
            }

            intAmountLogicProcessor.LogStatus();
        }
    }
}
