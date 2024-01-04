using System;
using System.Text;
using System.Collections.Generic;

namespace PIQcodibility
{
    public class KSumPairs


    {
        public static void Main()
        {
            KSumPairs cont = new KSumPairs();

            int[] nums = {1,2,3,4};
            int k = 5;

            Console.WriteLine($" Foundet sum pairs: {cont.MaxOperations(nums, k )}, MAP: {cont.MaxOperationsMap(nums, k)} ");

        }//main


        /*
         *1679. Max Number of K-Sum Pairs  https://leetcode.com/problems/max-number-of-k-sum-pairs/description/?envType=study-plan-v2&envId=leetcode-75
        Youtube : 
        1679. Max Number of K-Sum Pairs
        Medium
        2.9K
        69
        Companies
        You are given an integer array nums and an integer k.

        In one operation, you can pick two numbers from the array whose sum equals k and remove them from the array.

        Return the maximum number of operations you can perform on the array.

 

        Example 1:

        Input: nums = [1,2,3,4], k = 5
        Output: 2
        Explanation: Starting with nums = [1,2,3,4]:
        - Remove numbers 1 and 4, then nums = [2,3]
        - Remove numbers 2 and 3, then nums = []
        There are no more pairs that sum up to 5, hence a total of 2 operations.
        Example 2:

        Input: nums = [3,1,3,4,3], k = 6
        Output: 1
        Explanation: Starting with nums = [3,1,3,4,3]:
        - Remove the first two 3's, then nums = [1,4,3]
        There are no more pairs that sum up to 6, hence a total of 1 operation.
                    */

        public int MaxOperations(int[] nums, int k)
        {
            Array.Sort(nums);

            int left = 0,  right = nums.Length - 1;
            int count = 0;

            while (left < right )
            {
                int sum = nums[left] + nums[right];

                if (sum == k)
                {
                    count++;
                    Console.WriteLine($" Sum nummer {count} is {nums[left]} + {nums[right]} = {sum}");
                    left++;
                    right--;
                    
                    
                }
                else if (sum < k) left++;
                else right--;

            }
            return count;
        }

        public int MaxOperationsMap(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            int count = 0;

            foreach (int num in nums)
            {
                if (map.ContainsKey(k - num) && map[k - num] > 0)
                {
                    map[k - num]--;
                    count++;

                }
                else if (!map.TryAdd(num, 1)) map[num]++;
  
            }
            return count;
        }


        }

}

