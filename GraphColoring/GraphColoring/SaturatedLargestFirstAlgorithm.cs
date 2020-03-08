using System.Collections.Generic;
using System.Linq;

namespace GraphColoring
{
    /// <summary>
    /// Algorytm SLF - Saturated Largest First
    /// </summary>
    public class SaturatedLargestFirstAlgorithm: Algorithm
    {
        public SaturatedLargestFirstAlgorithm(Graph graph)
        {
            algorithmName = "Saturated Largest First";
            this.graph = graph;
            // order vertices by its number - default sort
            vertices = graph.Vertices.OrderBy(v => v.VertexNumber).ToList();
            colors = Enumerable.Range(0, graph.VertexCount).ToArray();
        }

        public override void Execute()
        {
            while (vertices.Any(v => !v.Color.HasValue))
            {
                var vertex = vertices.OrderByDescending(v => v.Saturation)
                    .ThenBy(v => v.Degree)
                    .FirstOrDefault(v => !v.Color.HasValue);

                List<int> adjacentColors = vertex
                    .AdjacentVertices
                    .Where(v => v.Color.HasValue)
                    .Select(v => v.Color.Value)
                    .Distinct()
                    .ToList();

                var firstAvailableColor = colors
                    .FirstOrDefault(c => !adjacentColors.Contains(c));

                vertices.FirstOrDefault(v => v.VertexNumber == vertex.VertexNumber).Color = firstAvailableColor;
            }
            graph.Vertices = vertices;
        }
    }
}
