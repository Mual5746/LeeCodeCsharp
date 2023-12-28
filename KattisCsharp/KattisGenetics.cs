using System;
using System.Text;
using System.Collections.Generic;

namespace PIQcodibility
{
    public class KattisGenetics

    {
        /*
         * Genetics https://open.kattis.com/problems/genetics2?editresubmit=12558323 

            For villains that intend to take over the world, a common way to avoid getting caught is to clone themselves.
        You have managed to catch an evil villain and her N -1 clones, and you are now trying to figure out which one of
        them is the real villain.

            To your aid you have each person’s DNA sequence, consisting of M characters, each being either A, C, G or T.
        You also know that the clones are not perfectly made; rather, their sequences differ in exactly K  places compared
        to the real villain’s.

            Can you identify the real villain?

            Input
            The first line contains the three integers N, M , and  K, where 1 < K < M. The following N lines represent the DNA
        sequences.
        Each of these lines consists of  M characters, each of which is either A, C, G or T.

            In the input, there is exactly one sequence that differs from all the other sequences in exactly 
             K places.

            Warning: this problem has rather large amounts of input, and will require fast IO in Java.

            Output
            Output an integer – the index of the DNA sequence that belongs to the villain. The sequences are numbered starting
            from 


            Sample Input 1	   Sample Output 1
            4 3 1                 3
            ACC
            CCA
            ACA
            AAA
            4 3 1                 
            ACC
            CCA
            ACA
            AAA

            Sample Input 2	   Sample Output 2
            4 4 3                4
            CATT
            CAAA
            ATGA
            TCTA
                    */
        public static void Main()
        {

            // Läs in texten rad för rad tills en tom rad anges
            List<string> rows = new List<string>();
            string line;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                rows.Add(line);
            }

            string[] firstLine = rows[0].Split(" ");
            int N = int.Parse(firstLine[0]);
            int M = int.Parse(firstLine[1]);
            int K = int.Parse(firstLine[2]);

            //Extract sequence from remaining lines
            char[][] sequences = new char[N][];
            string [] sequences1 = new string[N];
            for (int i = 1; i <= N; i++)
            {
                sequences[i -1]= rows[i].ToCharArray();
                sequences1[i - 1] = rows[i].ToString();
            }

            //-----Efective solution--------


            int villainIndex = FindVillainIndex(N, M, K, sequences);
            Console.WriteLine(villainIndex);

            int villainIndex2 = FindVillainIndex(sequences1, N, M, K);
            Console.WriteLine($" Result from effective solution: {villainIndex2}");

        }//main

        static int FindVillainIndex(int N, int M, int K, char[][] sequences)
        {
            int[] differenceCount = new int[N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j)
                    {
                        int diffCount = 0;
                        for (int k = 0; k < M; k++)
                        {
                            if (sequences[i][k] != sequences[j][k])
                            {
                                diffCount++;
                            }
                        }
                        if (diffCount == K)
                        {
                            differenceCount[i]++;
                        }
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (differenceCount[i] == N - 1)
                {
                    // This sequence has exactly K differences with all other sequences
                    return i + 1; // Sequences are numbered starting from 1
                }
            }

            // This line should not be reached given the constraints in the problem
            return -1;
        }

        //------------Effective solution------------------
        static int FindVillainIndex(string[] sequences, int N, int M, int K)
        {
            
            int[,] frequencyMap = BuildFrequencyMap(sequences, M);

            var candidates = FindTwoCandidateSequences(sequences, frequencyMap, M, N, K);
            int villainIndex = CompareCandidatesToFrequencies(candidates, sequences, frequencyMap, K, M, N);

            return villainIndex;
        }
        //Create a frequency map that counts how many times each character occurs at each position across all sequences.
        static int[,] BuildFrequencyMap(string[] sequences, int M)
        {
            int[,] frequencyMap = new int[M, 4];
            foreach (var sequence in sequences)
            {
                for (int i = 0; i < M; i++)
                {
                    int charIndex = "ACGT".IndexOf(sequence[i]);
                    frequencyMap[i, charIndex]++;
                }
            }
            return frequencyMap;
        }
        //Identify two candidate sequences that might be the villain's by finding the two sequences that are different at the most positions.
        //One of these must be the villain's since all clones have exactly K differences from the real sequence.
        static int[] FindTwoCandidateSequences(string[] sequences, int[,] frequencyMap, int M, int N, int K)
        {
            int maxDifference = 0;
            int[] candidateIndices = new int[2];

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    int diffCount = 0;
                    for (int k = 0; k < M; k++)
                    {
                        if (sequences[i][k] != sequences[j][k])
                            diffCount++;
                    }

                    if (diffCount > maxDifference)
                    {
                        maxDifference = diffCount;
                        candidateIndices[0] = i;
                        candidateIndices[1] = j;
                    }
                }
            }
            return candidateIndices;
        }
        //Compare these two candidate sequences against the frequency map.The sequence that matches the most frequent character at each
        //position(except for K positions) is the real villain's.
        static int CompareCandidatesToFrequencies(int[] candidates, string[] sequences, int[,] frequencyMap, int K, int M, int N)
        {
            foreach (var candidateIndex in candidates)
            {
                int matchCount = 0;
                for (int i = 0; i < M; i++)
                {
                    int charIndex = "ACGT".IndexOf(sequences[candidateIndex][i]);
                    if (frequencyMap[i, charIndex] == N - 1)//N - 1)
                        return i + 1;//matchCount++;
                }

                if (matchCount == M - K)
                    return candidateIndex + 1; // +1 for the 1-based index requirement
            }

            return -1; // Should not happen
        }

    }

}

