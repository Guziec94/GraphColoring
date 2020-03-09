using System.Collections.Generic;
using System.Linq;

namespace GraphColoring
{
    public class IndependentSetAlgorithm: Algorithm
    {
        public IndependentSetAlgorithm(Graph graph)
        {
            algorithmName = "Independent Set";
            this.graph = graph;
            // order vertices by its number - default sort
            vertices = graph.Vertices.OrderBy(v=>v.VertexNumber).ToList();
        }

        public override void Execute()
        {
            int color = 0;
            while (vertices.Any(v => !v.Color.HasValue))
            {
                List<int> verticeNumbers = 
                    FindMaxIndependentSet(vertices.Where(v => !v.Color.HasValue)
                    .ToList());
                vertices
                    .Where(v => verticeNumbers.Contains(v.VertexNumber))
                    .ToList()
                    .ForEach(v => v.Color = color);
                color++;
            }
        }

        private List<int> FindMaxIndependentSet(List<Vertex> setOfVertices)
        {
            Dictionary<Vertex, List<int>> independentSets = new Dictionary<Vertex, List<int>>();

            foreach (Vertex vertex in setOfVertices)
            {
                List<Vertex> tempVertices = new List<Vertex>(setOfVertices);

                tempVertices.Remove(vertex);
                independentSets.Add(vertex, new List<int> { vertex.VertexNumber });
                tempVertices.RemoveAll(v =>
                    vertex.AdjacentVertices
                        .Select(adjacent => adjacent.VertexNumber)
                    .Contains(v.VertexNumber));

                while (tempVertices.Any())
                {
                    var vertexToAdd = tempVertices.OrderBy(v => v.Degree).FirstOrDefault();
                    tempVertices.Remove(vertexToAdd);
                    independentSets[vertex].Add(vertexToAdd.VertexNumber);
                    tempVertices.RemoveAll(v =>
                        vertexToAdd.AdjacentVertices
                            .Select(adjacent => adjacent.VertexNumber)
                        .Contains(v.VertexNumber));
                }
            }

            return independentSets
                .OrderByDescending(pair => pair.Value.Count)
                .FirstOrDefault()
                .Value;
        }
    }
}