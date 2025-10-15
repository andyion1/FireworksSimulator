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
        private static Random _rng = new Random();

        public IParticle Launcher { get; private set; }

        public Firework(int width, int height, Colour colour, IExplosionPattern pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            float x = _rng.Next(0, width);
            float y = height;
            int lifespan = _rng.Next(40, 80);

            Launcher = ParticleFactory.Create(x, y, colour, lifespan);
        }
    }
}
