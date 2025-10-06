using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    internal class Circle
    {
        public Vector Center { get; }
        public float Radius { get; }
        public Colour Colour { get; }

        public Circle(float x, float y, float radius, Colour colour)
        {
            Radius = radius;
            Colour = colour;
            Center = new Vector(x, y);
        }
    }
}
