﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoring
{
    public class Vertex
    {
        public Vertex(int vertexNumber)
        {
            VertexNumber = vertexNumber;
            AdjacentVertices = new List<Vertex>();
        }

        public int VertexNumber { get; set; }
        public int? Color { get; set; }
        public int EdgeCount { get; set; }
        public List<Vertex> AdjacentVertices { get; set; }
        public int Degree => AdjacentVertices.Count;
        public int Saturation => AdjacentVertices.Select(v => v.Color).Distinct().Count();

        public override string ToString()
        {
            return $"Wierzchołek {VertexNumber} stopnia {Degree}. jest koloru {Color}";
        }
    }
}
