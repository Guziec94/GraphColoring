using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoring
{
    public class Graph
    {
        public Graph(int vertexCount)
        {
            VertexCount = vertexCount;
            AdjacencyMatrix = new bool[vertexCount, vertexCount];
            Vertices = new List<Vertex>(vertexCount);
            Vertices = Enumerable.Range(0, vertexCount)
                .Select(v => new Vertex(v))
                .ToList();
        }

        public int VertexCount { get; set; }
        public List<Vertex> Vertices { get; set; }
        public bool[,] AdjacencyMatrix { get; set; }

        public void AddEdge(int vertexA, int vertexB)
        {
            AdjacencyMatrix[vertexA, vertexB] = true;
            AdjacencyMatrix[vertexB, vertexA] = true;
        }
    }
}
