using ShapeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public static class ShapesFactory
    {
        public static ICircle CreateCircle(float x, float y, float radius, Colour colour)
        {
            return new Circle(x, y, radius, colour);
        }


        public static IRectangle CreateRectangle(float x, float y, float width, float height, Colour colour)
        {
            return new Rectangle(x, y, width, height, colour);
        }
    }
}
