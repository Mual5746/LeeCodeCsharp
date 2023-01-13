//https://open.kattis.com/problems/bijele?editsubmit=10225392 

using System;
                    
class Bijele
{
    public static void Main (string[] args) {
        
        int [] arrToComp = {1, 1, 2, 2, 2, 8};
        int i= 0;
        foreach (string item in Console.ReadLine().Split(' '))
        {
            Console.Write (arrToComp[i++] - int.Parse(item) + " ");
         }
        
    }
    
    
}
