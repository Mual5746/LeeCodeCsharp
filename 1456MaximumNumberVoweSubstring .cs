using System;
using System.Text;
using System.Collections.Generic;

namespace PIQcodibility
{
    public class MaximumNumberVoweSubstring 


    {
        public static void Main()
        {
            KSumPairs cont = new KSumPairs();

            string s = "tryhard";
            int k = 4;

            Console.WriteLine($" Foundet sum pairs:  MAP:  {cont.MaxVowels(s, k)}");

        }//main


        /*
         *1456. Maximum Number of Vowels in a Substring of Given Length 
        
        Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.

        Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.

 

        Example 1:

        Input: s = "abciiidef", k = 3
        Output: 3
        Explanation: The substring "iii" contains 3 vowel letters.
        Example 2:

        Input: s = "aeiou", k = 2
        Output: 2
        Explanation: Any substring of length 2 contains 2 vowels.
        Example 3:

        Input: s = "leetcode", k = 3
        Output: 2
        Explanation: "lee", "eet" and "ode" contain 2 vowels.
                    */

        public int MaxVowels(string s, int k)
        {
            //create hashSet of Vowels 'a', 'e', 'i', 'o', and 'u'.

            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };


            //now chet check first substring of lenght k how vowels it contains. 
            /*
            for (int i = 0; i < k; i++)
            {
                if (vowels.Contains(s[i])) count++;
            }
            */
            //same with LINQ
            int count = s.Take(k).Count(c => vowels.Contains(c));
            int result = count; //the moximun vowls are count

            Console.WriteLine($"fisrt count {count}");

            //check for the ramaning chsr in string and move one steg to right, decrease count if the poainter poit to a vowel

            
            int right = k;
            for (int i = right; i < s.Length; i++)
            {
                if (isVol(s[i - right])) count--;

                if (isVol(s[i])) count++;

                result = Math.Max(count, result);
                Console.WriteLine($"second count {count}");

            }
            return result; 

        }
        public bool isVol (char c)
        {
            //var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
        }


    }

}

