using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    internal class Rectangle : IRectangle
    {
        public float X { get; }
        public float Y { get; }
        public float Width { get; }
        public float Height { get; }
        public Colour Colour { get; }

        private List<Vector>? _vertices;

        public List<Vector> Vertices
        {
            get
            {
                if (_vertices == null)
                {
                    _vertices = new List<Vector>(4)
                    {
                        new Vector(X, Y),
                        new Vector(X + Width, Y),
                        new Vector(X + Width, Y + Height),
                        new Vector(X, Y + Height)
                    };

                    if (_vertices.Count != 4)
                    {
                        throw new InvalidOperationException("Rectangle must always have exactly 4 vertices.");
                    }
                }

                return _vertices;
            }
        }

        public Rectangle(float x, float y, float width, float height, Colour colour)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Width cannot be less or equal to 0");
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height cannot be less or equal to 0");
            }

            if (colour == null)
            {
                throw new ArgumentNullException(nameof(colour), "The Colour cannot be null.");
            }

            X = x;
            Y = y;
            Width= width;
            Height = height;    
            Colour = colour;
        }
    }
}
