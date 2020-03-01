using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj liczbę wierzchołków grafu: ");
            int vertexCount = int.Parse(Console.ReadLine());

            Graph graph = new Graph(vertexCount);

            Console.WriteLine("Podaj liczbę ścieżek, które chcesz dodać: ");
            int edgeCount = int.Parse(Console.ReadLine());

            Console.WriteLine($"Podaj {edgeCount} ścieżek (każda w osobnej linii, wierzchołki oddzielone spacją): ");
            for(int i = 0; i<edgeCount; i++)
            {
                string edge = Console.ReadLine();
                var temp = edge.Split(' ');

                int vertexA = int.Parse(temp[0]);
                int vertexB = int.Parse(temp[1]);

                graph.AddEdge(vertexA, vertexB);
            }
        }
    }
}
