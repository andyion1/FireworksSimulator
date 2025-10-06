using ShapeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    internal class Circle : ICircle
    {
        public Vector Center { get; }
        public float Radius { get; }
        public Colour Colour { get; }

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
