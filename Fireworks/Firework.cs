using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fireworks
{
    internal class Firework : IFirework
    {
        private int _width;
        private int _height;
        private IExplosionPattern _pattern;


        public Firework(int width, int height, Colour colour, IExplosionPattern pattern)
        {

        }
    }
}
