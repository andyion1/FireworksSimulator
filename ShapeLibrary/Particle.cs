using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;
    internal class Particle
    {
        public Vector Acceleration { get; }
        public Vector Velocity { get; }
        public Vector Position { get; }
        public ICircle Circle { get; }
        public Colour Colour { get; }
        public bool Done { get; }
    }
