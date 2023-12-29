using System;
using System.Text;
using System.Collections.Generic;

namespace PIQcodibility
{
    public class MoveZeroesP


    {
        public static void Main()
        {

        }//main


        /*
         * 283. Move Zeroes https://leetcode.com/problems/move-zeroes/?envType=study-plan-v2&envId=leetcode-75 
         * good explanaition: https://www.youtube.com/watch?v=aayNRwUN3Do&t=1s 
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

 

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
                    */

        public void MoveZeroes(int[] nums)
        {

            //svap non zeros to the left
            int left = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[left],nums[i]) = (nums[i],nums[left]);
                    left++;
                }
            }

            //LINQ solution


        }

    }

}

