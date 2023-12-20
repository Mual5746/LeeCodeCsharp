using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace solveCODe23
{
    public class IncreasingTripletSubsequence



    {
        public static void Main()
        {
            IncreasingTripletSubsequence vow = new IncreasingTripletSubsequence();
            int[] nums = { 2, 1, 5, 0, 4, 6 };
            string s = "hello";

            bool res = vow.IncreasingTriplet(nums);
            Console.Write("Result: " + res);
            



        }//main 
        public bool IncreasingTriplet(int[] nums)
        {
            
            
            int first = nums[0];
            int sedcond = int.MaxValue;

            foreach (int third in nums)
            {
                
                if (first < sedcond && sedcond < third )
                {
                    return true;
                }else
                {
                    if(first <third && third < sedcond)
                    {
                        sedcond = third;
                    }
                    else if (third < first)
                    {
                        first = third;

                    }

                }
            }

            return false; 
        }

        //LIQ solution

        public bool IncreasingTriplet(int[] nums)
        {
            int first = nums[0];
            int second = int.MaxValue;

            return nums.Any(third =>
                first < second && second < third ? true :
                first < third && third < second ? (second = third) == third :
                third < first && (first = third) == third
            );
        }

    }

}

