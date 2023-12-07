/*
Kattis Problem: 
ICPC Awards 

https://open.kattis.com/problems/icpcawards?editresubmit=12483613 

*/


using System.Collections.Generic;
using System;
using System.Text;

  public class ICPCAwardsKattis

  {
      public static void Main()
      {

          // Läs in texten rad för rad tills en tom rad anges
          List<string> rows = new List<string>();
          string line;
          while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
          {
              rows.Add(line);
          }

          int numberOfLines = int.Parse(rows[0]);

          var dictatinay = new Dictionary<string, string>();

          for (int i = 1; i<= numberOfLines; i++)
          {
              String[] rad = rows[i].Split(" ");

              string university = rad[0];
              string team = rad[1];

              if(!dictatinay.ContainsKey(university))
              {
                  dictatinay.Add(university, team);
              }

          }

         int n = 1;

          foreach(var item in dictatinay)
          {
              if (n <= 12)
              {

                  Console.WriteLine($"{item.Key} {item.Value}");
                  n++;

              }
              else break;

          }

      }//main 
  }


