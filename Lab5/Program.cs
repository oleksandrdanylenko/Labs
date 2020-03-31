using System;
using System.Collections.Generic;

namespace Lab5
{
    internal class Gfg
    {
        private const int V = 9;

        private static int MinDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (var v = 0; v < V; v++)
            {
                if (sptSet[v] || dist[v] > min) continue;
                min = dist[v];
                minIndex = v;
            }

            return minIndex;
        }

        static void PrintSolution(IReadOnlyList<int> dist, int n)
        {
            Console.Write("Vertex	 Distance "
                          + "from Source\n");
            for (var i = 0; i < V; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

        void Dijkstra(int[,] graph, int src)
        {
            var dist = new int[V];

            var sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                var u = MinDistance(dist, sptSet);

                sptSet[u] = true;

                for (var v = 0; v < V; v++)

                    if (!sptSet[v] && graph[u, v] != 0 &&
                        dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            PrintSolution(dist, V);
        }

        public static void Main()
        {
            int[,] graph = { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            var t = new Gfg();

            t.Dijkstra(graph, 0);
            Console.ReadKey();
        }
    }
}

