using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphColoring
{
    public class Algorithm
    {
        public string algorithmName;
        internal Graph graph;
        internal List<Vertex> vertices;
        internal int[] colors;

        public virtual void Execute() { }
        public void PrintSolution()
        {
            Console.WriteLine($"Rozwiązanie przy użyciu algorytmu {algorithmName}");

            foreach (Vertex vertex in graph.Vertices.OrderBy(v => v.VertexNumber))
            {
                Console.WriteLine(vertex);
            }
        }
    };
}
