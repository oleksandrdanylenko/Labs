using System;

namespace Lab4Komi
{
    public class Gfg
    {
        private static int TravelSalesmanProblem(int[,] graph, bool[] v, int currPos, int n, int count, int cost, int ans)
        {

            if (count == n && graph[currPos, 0] > 0)
            {
                ans = Math.Min(ans, cost + graph[currPos, 0]);
                return ans;
            }

            for (int i = 0; i < n; i++)
            {
                if (v[i] || graph[currPos, i] <= 0)
                {
                    continue;
                }

                v[i] = true;
                ans = TravelSalesmanProblem(graph, v, i, n, count + 1,
                    cost + graph[currPos, i], ans);

                v[i] = false;
            }
            return ans;
        }

        static void Main()
        {
            var n = 4;

            int[,] graph = {
                { 0, 10, 15, 20 },
                { 10, 0, 35, 25 },
                { 15, 35, 0, 30 },
            };

            bool[] v = new bool[n];

            v[0] = true;
            int ans = int.MaxValue;

            ans = TravelSalesmanProblem(graph, v, 0, n, 1, 0, ans);

            Console.Write(ans);
            Console.ReadKey();
        }
    }
}

