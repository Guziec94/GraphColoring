using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphColoring.Tests
{
    [TestClass]
    public class CreatingGraphs
    {
        [TestMethod]
        public void CreateGrapgh1()
        {
            const int vertexCount = 9;
            Graph testGraph = new Graph(vertexCount);

            testGraph.AddEdge(0, 1);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(0, 4);
            testGraph.AddEdge(1, 2);
            testGraph.AddEdge(1, 3);
            testGraph.AddEdge(1, 5);
            testGraph.AddEdge(1, 6);
            testGraph.AddEdge(2, 3);
            testGraph.AddEdge(2, 4);
            testGraph.AddEdge(2, 5);
            testGraph.AddEdge(2, 7);
            testGraph.AddEdge(3, 4);
            testGraph.AddEdge(3, 6);
            testGraph.AddEdge(3, 7);
            testGraph.AddEdge(4, 5);
            testGraph.AddEdge(4, 6);
            testGraph.AddEdge(4, 8);
            testGraph.AddEdge(5, 6);
            testGraph.AddEdge(5, 7);
            testGraph.AddEdge(5, 8);
            testGraph.AddEdge(6, 7);
            testGraph.AddEdge(7, 8);

            bool[,] expectedAdjacencyMatrix = new bool[vertexCount, vertexCount]
            {
                {false, true, false, true, true, false, false, false, false},
                {true, false, true, true, false, true, true, false, false},
                {false, true, false, true, true, true, false, true, false},
                {true, true, true, false, true, false, true, true, false},
                {true, false, true, true, false, true, true, false, true},
                {false, true, true, false, true, false, true, true, true},
                {false, true, false, true, true, true, false, true, false},
                {false, false, true, true, false, true, true, false, true},
                {false, false, false, false, true, true, false, true, false},
            };

            CollectionAssert.AreEqual(testGraph.AdjacencyMatrix, expectedAdjacencyMatrix);
        }
    }
}