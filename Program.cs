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

    public class IntAmmountInArray
    {
        /// <summary>
        /// Holds each int and the amount of times it appears on a given Array
        /// Array does not accept values < 1, so by default instantiate the values with 0;
        /// </summary>
        public IntAmmountInArray()
        {
            Integer = 0;
            AmountInArray = 0;
        }

        public IntAmmountInArray(int integer, int amountInArray)
        {
            Integer = integer;
            AmountInArray = amountInArray;
        }

        public int Integer { get; set; }
        public int AmountInArray  { get; set; }
    }


    // 1) and 3) allows us to use the integer in the Array as the index of the IntAmountInArray[] within IntAmmountLogicProcessor
    public class IntAmountLogicProcessor
    {
        private IntAmmountInArray[] IntsInArray { get; }

        public IntAmountLogicProcessor()
        {
            IntsInArray = new IntAmmountInArray[Constants.MaxArraySize];
        }

        public void ProcessInt(int i)
        {
            Console.WriteLine($"Processing int {i}");

            //validate i matches condition 1)
            if (IntsInArray[i+1] is null)
            {
                InitInt(i);
            }
        }

        private void InitInt(int i)
        {
            IntsInArray[i + 1] = new IntAmmountInArray(i, 1);
        }
    }
       
    class Program
    {
        
        static void Main(string[] args)
        {
            IntAmountLogicProcessor intAmountLogicProcessor = new IntAmountLogicProcessor();

            var a = new IntAmmountInArray();

            foreach (int i in Examples.First)
            {
                intAmountLogicProcessor.ProcessInt(i);
            }
        }
    }
}
