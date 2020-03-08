using System.Collections.Generic;
using System.Linq;

namespace GraphColoring
{
    /// <summary>
    /// Algorytm zachłanny - greedy
    /// </summary>
    public class GreedyAlgorithm: Algorithm
    {
        public GreedyAlgorithm(Graph graph)
        {
            algorithmName = "Greedy";
            this.graph = graph;
            // order vertices by its number - default sort
            vertices = graph.Vertices.OrderBy(v=>v.VertexNumber).ToList();
            colors = Enumerable.Range(0, graph.VertexCount).ToArray();
        }

        public override void Execute()
        {
            foreach (Vertex vertex in vertices)
            {
                List<int> adjacentColors = vertex.AdjacentVertices
                    .Where(v => v.Color.HasValue)
                    .Select(v => v.Color.Value)
                    .Distinct()
                    .ToList();
                vertex.Color = colors
                    .FirstOrDefault(c => !adjacentColors.Contains(c));
            }
            graph.Vertices = vertices;
        }
    }
}
