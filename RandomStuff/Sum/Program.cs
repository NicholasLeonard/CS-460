using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] increasingNums = { -5, -2, 0, 1, 2, 4, 5, 6, 9};
            int[] randomNums = { 2, 4, 6, 10, -2, -1, 5};
            //Console.WriteLine(NumbersWithGivenSum.CombinedSum(increasingNums, 15));
            Console.WriteLine(NumbersWithGivenSum.TripletSum(randomNums, 2));
        }
    }
}
