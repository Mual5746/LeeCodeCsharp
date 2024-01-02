using System;
using System.Text;
using System.Collections.Generic;

namespace PIQcodibility
{
    public class Container


    {
        public static void Main()
        {
            Container cont = new Container();

            int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            Console.WriteLine($" Max Area: {cont.MaxArea(height)}  Linq: {cont.MaxAreaLINQ(height)}");

        }//main


        /*
         * 311. Container With Most Water https://leetcode.com/problems/container-with-most-water/?envType=study-plan-v2&envId=leetcode-75
        Youtube : https://www.youtube.com/watch?v=UuiTKBwPgAo 
        You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

        Find two lines that together with the x-axis form a container, such that the container contains the most water.

        Return the maximum amount of water a container can store.

        Notice that you may not slant the container.
        Example 1:


        Input: height = [1,8,6,2,5,4,8,3,7]
        Output: 49
        Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.


        Example 2:

        Input: height = [1,1]
        Output: 1
                    */

        public int MaxArea(int[] height)
        {
            
            int maxArea = 0; 
            int left = 0, right = height.Length -1 ;
            while(left < right)
            {
                int minheight = Math.Min(height[left], height[right]);
                maxArea = Math.Max(maxArea, minheight * (right - left));

                if (height[left] < height[right]) left++;

                else if (height[right] > height[left]) right++;

                else right--;
                
            }
            return maxArea;


        }
        public int MaxAreaLINQ(int[] height)
        {
            return Enumerable.Range(0, height.Length - 1).SelectMany(i => Enumerable.Range(i + 1, height.Length - 1 - i),
                (i, j) => Math.Min(height[i], height[j]) * (j - i)).Max();
        }

    }

}

