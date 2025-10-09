using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;
using Fireworks;

namespace Fireworks;
    internal class Particle : IParticle
    {
        private int _lifespan;
    
        public Vector Acceleration { get; private set; }
        public Vector Velocity { get; private set;  }
        public Vector Position { get; private set;  }
        public ICircle Circle { get; }
        public Colour Colour { get; }
        public bool Done { get; }

        public Particle(float x, float y, Colour colour, int lifespan)
        {
            Position = new Vector(x, y);
            Colour = colour;
            _lifespan = lifespan;


            Circle = new Circle(x, y, 2f, colour);

            Acceleration = new Vector(0, 0);
            Velocity = new Vector(0, 0);
        }

        public void ApplyGravity()
        {
            Acceleration += new Vector(0, 0.1f);
        }
}
