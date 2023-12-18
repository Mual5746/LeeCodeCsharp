//345. Reverse Vowels of a String

using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace solveCODe23
{
    public class VowelsOfString


    {
        public static void Main()
        {
            VowelsOfString vow = new VowelsOfString();
            string s = "hello";

            Console.WriteLine($"hello ressult:  {vow.ReverseVowels(s)} ");

            Console.WriteLine($"hello ressult LINQ:  {vow.ReverseVowelsWithLINQ(s)} ");



        }//main 
   
        /*
         Given a string s, reverse only all the vowels in the string and return it.

        The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

 

        Example 1:

        Input: s = "hello"
        Output: "holle"
        Example 2:

        Input: s = "leetcode"
        Output: "leotcede"

         */

        public string ReverseVowels(string s)
        {
            List<char> vowels = new List<char>{ 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char [] stringToChar = s.ToCharArray();
            List <char> vowlsChars= new List<char>();

            for (int i = 0; i <s.Length; i++)
            {
                if (vowels.Contains(stringToChar[i]))
                {
                    vowlsChars.Add(stringToChar[i]);

                }
            }
            int index = vowlsChars.Count();
            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(stringToChar[i]))
                {
                    stringToChar[i] = vowlsChars[index - 1];
                    index--;

                }
            }
            var res = new string(stringToChar.ToArray());

            return res;

        }
        public string ReverseVowelsWithLINQ(string s)
        {
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            char[] stringToChar = s.ToCharArray();
            /*
            
            List<char> vowlsChars = new List<char>();


            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(stringToChar[i]))
                {
                    vowlsChars.Add(stringToChar[i]);

                }
            }
            */
            List<char> volchars = s.Where(c => vowels.Contains(c)).ToList();

            int index = volchars.Count();

            //iterate through each character in the original string and conditionally replace vowels with the corresponding ones from vowlsChars.

            /*
             s.Select(c => ...):
            This part uses LINQ's Select method to project each character c in the original string s to a new value.

            vowels.Contains(c) ? vowlsChars[--index] : c:
            Here, it checks if the current character c is a vowel (found in the vowels list).
            If it is a vowel, the expression returns the last vowel in the vowlsChars list (accessed using --index). The --index decrements the index variable before accessing the element.
            If it's not a vowel, the original character c is returned.

            .ToArray():

            The result of the entire expression is an IEnumerable of characters, and .ToArray() is used to convert it back to a character array.
             */

            stringToChar = s.Select(c => vowels.Contains(c) ? volchars[--index] : c).ToArray();

            /*

            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(stringToChar[i]))
                {
                    stringToChar[i] = vowlsChars[index - 1];
                    index--;

                }
            }
            var res = new string(stringToChar.ToArray());

            */

            return new string(stringToChar) ;

        }

    }

}

