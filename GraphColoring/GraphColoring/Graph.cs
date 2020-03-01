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

        public string PrintAdjacencyMatrix()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = 0; j < VertexCount; j++)
                {
                    sb.Append(AdjacencyMatrix[i, j] ? "1 " : "0 ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
