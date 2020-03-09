using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph;
            Console.Write("Czy chcesz załadować jeden z przygotowanych przykładów? (T/N) ");
            ConsoleKey clickedKey = Console.ReadKey().Key;
            if (clickedKey == ConsoleKey.T)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
                var files = directoryInfo.GetFiles("*.txt", SearchOption.AllDirectories);
                Console.Write($"\nWybierz numer przykładu (0-{files.Length-1}): ");
                int exampleNumber = int.Parse(Console.ReadLine());
                var streamReader = new StreamReader(files[exampleNumber].FullName);

                int vertexCount = int.Parse(streamReader.ReadLine());

                graph = new Graph(vertexCount);

                int edgeCount = int.Parse(streamReader.ReadLine());

                for (int i = 0; i < edgeCount; i++)
                {
                    string edge = streamReader.ReadLine();
                    var temp = edge.Split(' ');

                    int vertexA = int.Parse(temp[0]);
                    int vertexB = int.Parse(temp[1]);

                    graph.AddEdge(vertexA, vertexB);
                }
            }
            else
            {
                Console.Write("\nPodaj liczbę wierzchołków grafu: ");
                int vertexCount = int.Parse(Console.ReadLine());

                graph = new Graph(vertexCount);

                Console.WriteLine("Podaj liczbę ścieżek, które chcesz dodać: ");
                int edgeCount = int.Parse(Console.ReadLine());

                Console.WriteLine($"Podaj {edgeCount} ścieżek (każda w osobnej linii, wierzchołki oddzielone spacją): ");
                for (int i = 0; i < edgeCount; i++)
                {
                    string edge = Console.ReadLine();
                    var temp = edge.Split(' ');

                    int vertexA = int.Parse(temp[0]);
                    int vertexB = int.Parse(temp[1]);

                    graph.AddEdge(vertexA, vertexB);
                }
            }

            Console.Write("\n\n");

            var availableAlgortihms = new Type[] { typeof(LargestFirstAlgorithm), typeof(SaturatedLargestFirstAlgorithm), typeof(IndependentSetAlgorithm) };
            foreach(Type algorithm in availableAlgortihms)
            {
                Algorithm testAlgorithm = (Algorithm)Activator.CreateInstance(algorithm, new object[] { graph });
                testAlgorithm.Execute();
                testAlgorithm.PrintSolution();

                graph.Vertices.ForEach(v => v.Color = null);

                Console.Write("\n\n");
            }

            Console.WriteLine("KONIEC");
            Console.ReadKey();
        }
    }
}
