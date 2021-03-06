﻿using System.Collections.Generic;
using System.Linq;

namespace GraphColoring
{
    /// <summary>
    /// Algorytm LF - largest first
    /// </summary>
    public class LargestFirstAlgorithm: Algorithm
    {
        public LargestFirstAlgorithm(Graph graph)
        {
            algorithmName = "Largest First";
            this.graph = graph;
            // descending order vertices by its Degree 
            vertices = graph.Vertices.OrderByDescending(v => v.Degree).ToList();
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
