using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackeRank.Arrays
{
    public static class _2DArray
    {
        public static List<List<int>> FaillingExample()
        {
            var list1 = new List<int>() { 1, 1, 1, 0, 0, 0 };
            var list2 = new List<int>() { 0,1,0,0,0,0};
            var list3 = new List<int>() { 1,1,1,0,0,0,};
            var list4 = new List<int>() { 0,0,2,4,4,0};
            var list5 = new List<int>() { 0, 0, 0, 2, 0, 0 };
            var list6 = new List<int>() { 0, 0, 1,2, 4, 0 };

            return new List<List<int>>() { list1, list2, list3, list4, list5, list6 };
        } 
        public static int hourglassSum(List<List<int>> arr )
        {

            int maxHourGlassSum = int.MinValue;
            
            int currentHourGlassSum = int.MinValue;
            for(int row = 1; row < arr[0].Count -1 ; row++)
            {
                for (int column = 1; column < arr[0].Count -1; column++)
                {
                    currentHourGlassSum = arr[row][column] // center
                    + arr[row-1][column - 1] // top left
                    + arr[row-1][column] // top middle
                    + arr[row-1][column + 1] // top right
                    + arr[row+1][column - 1] //low left
                    + arr[row+1][column] // low middle
                    + arr[row+1][column + 1]; // low right

                    if (currentHourGlassSum > maxHourGlassSum)
                    {
                        maxHourGlassSum = currentHourGlassSum;
                    }

                    currentHourGlassSum = int.MinValue;
                };
            };
        
            return maxHourGlassSum;
        }
    }
}
