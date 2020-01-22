using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum
{
    public static class NumbersWithGivenSum
    {
        /// <summary>
        /// Finds a pair of ints that sum to the given combine number and returns them. Returns a pair of -1 if no result is found.
        /// </summary>
        /// <param name="nums">Increasing, sorted array of int</param>
        /// <param name="combinedNum">The sum to reach by combining two int from nums</param>
        /// <returns></returns>
        public static Tuple<int, int> CombinedSum(int[] nums, int combinedNum)
        {
            if(nums == null)
            {
                return new Tuple<int, int>(-1, -1);
            }

            int left = 0;
            int right = nums.Length - 1;

            while(left < right)
            {
                if((nums[left] + nums[right]) == combinedNum)
                {
                    return new Tuple<int, int>(nums[left], nums[right]);
                }
                else if(nums[left] + nums[right] < combinedNum)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return new Tuple<int, int>(-1, -1);
        }

        /// <summary>
        /// Returns a tuple of three numbers that sum to give the tripletNum. Returns a tuple of -1 if no result.
        /// </summary>
        /// <param name="nums">Array of numbers. Sorted or otherwise.</param>
        /// <param name="tripletNum">The sum to reach by summing three ints from nums</param>
        /// <returns></returns>
        public static Tuple<int, int, int> TripletSum(int[] nums, int tripletNum)
        {
            Array.Sort(nums);

            for(int i = 0; i < nums.Length -2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                //int curSum = tripletNum - nums[i];

                while(left < right)
                {
                    if(nums[i] + nums[left] + nums[right] == tripletNum)
                    {
                        return new Tuple<int, int, int>(nums[i], nums[left], nums[right]);
                    }
                    else if((nums[i] + nums[left] + nums[right] < tripletNum))
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return new Tuple<int, int, int>(-1, -1, -1);
        }
    }
}
