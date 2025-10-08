using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;

namespace ShapeLibrary;
    internal class Particle : IParticle
    {
        private float _lifespan;
    
        public Vector Acceleration { get; }
        public Vector Velocity { get; }
        public Vector Position { get; }
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
}
