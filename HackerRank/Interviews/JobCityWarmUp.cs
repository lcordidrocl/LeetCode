using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackeRank
{
    public static class JobCityWarmUp
    {
        public static void fizzBuzz(int n)
        {
            int mod5;
            int mod3;
            for (int i = 1; i <= n; i++)
            {
                mod5 = i % 5;
                mod3 = i % 3;

                if (mod5.Equals(0) && mod3.Equals(0))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (mod5.Equals(0))
                {
                    Console.WriteLine("Buzz");
                }
                else if (mod3.Equals(0))
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine($"{i}");
                }
            }
        }
    }
}
