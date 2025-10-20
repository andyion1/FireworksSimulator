using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShapeLibrary;

namespace Fireworks
{
    internal class ExplosionPattern : IExplosionPattern
    {
        private readonly Vector _launchVelocity = new Vector(0f, -8f);
        public int NumberOfParticles => 60;
        public Vector ExplosionVelocity => new Vector(3f, 3f);
        public Vector LaunchVelocity => _launchVelocity;
    }
}
