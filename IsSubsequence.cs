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
         * 392. Is Subsequence https://leetcode.com/problems/is-subsequence/
         * good explanaition: https://www.youtube.com/watch?v=99RVfqklbCE 
        Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

        A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).

 

        Example 1:

        Input: s = "abc", t = "ahbgdc"
        Output: true
        Example 2:

        Input: s = "axc", t = "ahbgdc"
        Output: false
                    */

        public bool IsSubsequence(string s, string t)
        {
            if (s == null) return false;
                

            
            int indecOfS = 0;

            for (int i = 0; i <t.Length; i++)
            {
                if (t[i] == s[indecOfS])
                {
                    indecOfS++;
                    if (indecOfS == t.Length) return true;
                }
            }
            return false;

        }

    }

}

