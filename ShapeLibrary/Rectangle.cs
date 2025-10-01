using ShapeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Rectangle : IRectangle
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
                }
                return _vertices;
            }
        }
    }
}
