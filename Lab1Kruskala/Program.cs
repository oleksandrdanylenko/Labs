// C# Code for above approach 

using System;

namespace Lab1Kruskala
{
    class Graph
    {
        private class Edge : IComparable<Edge>
        {
            public int Src;
            public int Dest;
            public int Weight;

            public int CompareTo(Edge compareEdge)
            {
                return Weight - compareEdge.Weight;
            }
        }

        public class Subset
        {
            public int parent, rank;
        };

        private readonly int V;
        private readonly int E;
        readonly Edge[] edge;

        internal Graph(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[E];
            for (var i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        private static int Find(Subset[] subsets, int i)
        {
	
            if (subsets[i].parent != i)
                subsets[i].parent = Find(subsets,
                    subsets[i].parent);

            return subsets[i].parent;
        }

        private static void Union(Subset[] subsets, int x, int y)
        {
            var xroot = Find(subsets, x);
            var yroot = Find(subsets, y);

            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;

            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }

        void KruskalMST()
        {
            var result = new Edge[V];
            var e = 0;
            int i;

            for (i = 0; i < V; ++i)
                result[i] = new Edge();

            Array.Sort(edge);

            var subsets = new Subset[V];
            for (i = 0; i < V; ++i)
                subsets[i] = new Subset();

            for (int v = 0; v < V; ++v)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            i = 0;

            while (e < V - 1)
            {
                var nextEdge = edge[i++];

                var x = Find(subsets, nextEdge.Src);
                var y = Find(subsets, nextEdge.Dest);

                if (x == y)
                {
                    continue;
                }

                result[e++] = nextEdge;
                Union(subsets, x, y);
            }

            Console.WriteLine("Following are the edges in " +
                              "the constructed MST");
            for (i = 0; i < e; ++i)
                Console.WriteLine($"{result[i].Src} -- {result[i].Dest} == {result[i].Weight}");

            Console.ReadLine();
        }

        public static void Main(string[] args)
        {

            int V = 4; 
            int E = 5;
            Graph graph = new Graph(V, E);

            graph.edge[0].Src = 0;
            graph.edge[0].Dest = 1;
            graph.edge[0].Weight = 10;

            graph.edge[1].Src = 0;
            graph.edge[1].Dest = 2;
            graph.edge[1].Weight = 6;

            graph.edge[2].Src = 0;
            graph.edge[2].Dest = 3;
            graph.edge[2].Weight = 5;

            graph.edge[3].Src = 1;
            graph.edge[3].Dest = 3;
            graph.edge[3].Weight = 15;


            graph.edge[4].Src = 2;
            graph.edge[4].Dest = 3;
            graph.edge[4].Weight = 4;

            graph.KruskalMST();
        }
    }
}

