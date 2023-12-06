using System;
using System.Text;

public class AutorKattis

{
    public static void Main()
    {

        string str = Console.ReadLine().ToString();

        string [] arryStr = str.Split("-");
        var res = new StringBuilder();

        foreach(string item in arryStr)
        {
            res.Append(item[0]);

        }

        Console.WriteLine($"resultat: {res} ");

    }

}


/*
Sample Input 1	Sample Output 1
Knuth-Morris-Pratt
KMP
Sample Input 2	Sample Output 2
Mirko-Slavko
MS
Sample Input 3	Sample Output 3
Pasko-Patak
PP

*/
