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
    public static class LargestFirstAlgorithm
    {
        public static void Execute(Graph graph)
        {
            var colors = Enumerable.Range(0, graph.VertexCount).ToArray();
            List<Vertex> orderedVertices = graph.Vertices.OrderByDescending(v => v.Degree).ToList();
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
    }
}
