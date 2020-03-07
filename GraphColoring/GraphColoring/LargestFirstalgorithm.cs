using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoring
{
    /// <summary>
    /// Algorytm LF - largest first
    /// </summary>
    public class LargestFirstAlgorithm
    {
        private const string algorithmName = "Largest First";
        private Graph graph;
        private List<Vertex> orderedVertices;

        public LargestFirstAlgorithm(Graph graph)
        {
            this.graph = graph;
            orderedVertices = graph.Vertices.OrderByDescending(v => v.Degree).ToList();
        }

        public void Execute()
        {
            var colors = Enumerable.Range(0, graph.VertexCount).ToArray();
            foreach (Vertex vertex in orderedVertices)
            {
                List<int> adjacentColors = vertex.AdjacentVertices
                    .Where(v => v.Color.HasValue)
                    .Select(v => v.Color.Value)
                    .Distinct()
                    .ToList();
                vertex.Color = colors
                    .FirstOrDefault(c => !adjacentColors.Contains(c));
            }
        }

        public void PrintSolution()
        {
            Console.WriteLine($"Rozwiązanie przy użyciu algorytmu {algorithmName}");

            foreach(Vertex vertex in orderedVertices)
            {
                Console.WriteLine(vertex);
            }
        }
    }
}
