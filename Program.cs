using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace slonie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( Slonie.func());
            Console.ReadKey();
            

        }
       
    }
    class Slonie
    {
        // n, wagi sloni, obecne ustawienie, ustawienie szefa
        static int maxN = 1000000;
        static int inf = 1000000000;

        static int[] weight = new int[maxN];
        static int[] currentOrd = new int[maxN];
        static int[] finalOrd = new int[maxN];
        static bool[] visited = new bool[maxN];

        static int minWeight = inf;
       public static long func() {
            int N = 0;
            try
            {
                 N = int.Parse(Console.ReadLine());
                weight = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                currentOrd = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)-1).ToArray();
                // finalOrd = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                int[] tab = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)-1).ToArray();
                finalOrd = new int[N];
                for (int i = 0; i < tab.Length; i++)
                    finalOrd[tab[i]] = currentOrd[i];
                for (int i = 0; i < weight.Length; i++)
                {
                    minWeight = Math.Min(minWeight, weight[i]);
                }

                if (weight.Length != N || currentOrd.Length != N || finalOrd.Length != N) throw new Exception();

            }
            catch (Exception e) { }


            long result = 0;
      
            for (int i = 0; i<N;++i)
            {
                if(!visited[i])
                {
                    int minWeightC = inf;
                    long sum = 0;
                    int current = i;
                    int lenghtC = 0;
                    for(; ; )
                    {
                        minWeightC = Math.Min(minWeightC, weight[current]);
                        sum += weight[current];
                        current = finalOrd[current];
                        visited[current] = true;
                        ++lenghtC;
                        if (current == i) break;
                    }
                    result += Math.Min(sum + (lenghtC - 2) * (long)minWeightC, sum + minWeightC + (lenghtC + 1) * (long)minWeight);
                }
            }
            return result;
           
        }


    }
}
