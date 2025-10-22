using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


[assembly: InternalsVisibleTo("ShapeLibraryTests")]
[assembly: InternalsVisibleTo("Fireworks")]

namespace ShapeLibrary
{
    internal class Circle : ICircle
    {
        public Vector Center { get; }
        public float Radius { get; }
        public Colour Colour { get; }

        private int defaultSegments = 36; // number of points to approximate the circle
        private List<Vector> _vertices;

        public List<Vector> Vertices
        {
            get
            {
                if (_vertices == null)
                {
                    _vertices = new List<Vector>();

                    // angle between each segment
                    float angleConsPoints = (float)(2 * Math.PI / defaultSegments);

                    // generate vertex positions around the circle
                    for (int i = 0; i < defaultSegments; i++)
                    {
                        float angle = i * angleConsPoints;

                        float x = Center.X + (float)(Radius * Math.Cos(angle));
                        float y = Center.Y + (float)(Radius * Math.Sin(angle));

                        _vertices.Add(new Vector(x, y));
                    }
                }

                return _vertices;
            }
        }

        public Circle(float x, float y, float radius, Colour colour)
        {
            if (radius <= 0f)
                throw new ArgumentException("The Radius cannot be less or equal than 0");

            if (colour == null)
                throw new ArgumentNullException(nameof(colour), "The Colour cannot be null.");

            Radius = radius;
            Colour = colour;
            Center = new Vector(x, y);
        }
    }
}