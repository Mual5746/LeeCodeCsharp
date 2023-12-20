//238. Product of Array Except Self



using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace solveCODe23
{
    public class ReversOfWordInString


    {
        public static void Main()
        {
            ReversOfWordInString vow = new ReversOfWordInString();
            int[] nums = { 0, 0 };
            string s = "hello";

            int[] res = vow.ProductExceptSelf(nums);
            Console.Write("Result: ");
            foreach (int item in res)
            {
                Console.Write(" " + item);
            }



        }//main 
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];

            int prod = 1;
            int numsOfZeros = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    numsOfZeros++;

                    if (numsOfZeros > 1)
                    {
                        Array.Fill(result, 0);
                        return result;
                    }
                    continue;

                }

                
               prod *= nums[i];
            }


            Console.WriteLine($"cunret: {prod}");

            
            for (int i = 0; i < nums.Length; i++)
            {

                if (numsOfZeros == 1)
                {
                    //If there only one zero and only the curent num is zero return prod otherwise fill it with zeros
                    result[i] = nums[i] == 0 ? prod : 0;
                }
                else if (nums[i] != 0)
                {
                    //else if there is no zeros in array 
                    result[i] = prod / nums[i];


                }
                else result[i] = 0;
                   
                    
            }

            return result;

        }

        //LINQ solution 

        public int[] ProductExceptSelf(int[] nums)
        {
            int numOfZeros = nums.Count(num => num == 0);
        
            int prod = nums.Where(num => num != 0).Aggregate(1, (currentProd, num) => currentProd * num);
        
            int[] result = nums.Select(num =>
                numOfZeros > 1 ? 0 :
                numOfZeros == 1 ? (num == 0 ? prod : 0) :
                prod / (num == 0 ? 1 : num)
            ).ToArray();
        
            return result;
        }
    }

}

