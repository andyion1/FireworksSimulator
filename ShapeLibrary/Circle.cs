using ShapeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShapeLibrary;

namespace ShapeLibrary
{
    internal class Circle : ICircle
    {
        public Vector Center { get; }
        public float Radius { get; }
        public Colour Colour { get; }

        private List<Vector> _vertices;

        public List<Vector> Vertices
        {
            get
            {
                if (_vertices == null)
                {
                    _vertices = new List<Vector>();
                }
                return _vertices;
            }
        }

        public Circle(float x, float y, float radius, Colour colour)
        {
            if (radius <= 0f)
            {
                throw new ArgumentException("The Radius cannot be less or equal than 0")
            }
            
            Radius = radius;
            Colour = colour;
            Center = new Vector(x, y);
        }
    }
}
