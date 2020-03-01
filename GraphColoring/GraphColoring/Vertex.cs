using System;
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
        }

        public int VertexNumber { get; set; }
        public int Color { get; set; }
        public int EdgeCount { get; set; }

    }
}
