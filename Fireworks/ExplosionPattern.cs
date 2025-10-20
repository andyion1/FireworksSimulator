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
        private readonly Random _rng;
        private readonly Vector _launchVelocity;
        private readonly int _minParticles;
        private readonly int _maxParticles;
        private readonly float _minExplosionSpeed;
        private readonly float _maxExplosionSpeed;

        public ExplosionPattern(float launchSpeedY, int minParticles, int maxParticles, float minExplosionSpeed, float maxExplosionSpeed)
        {
            _rng = new Random();

            _launchVelocity = new Vector(0f, launchSpeedY);
            _minParticles = minParticles;
            _maxParticles = maxParticles;
            _minExplosionSpeed = minExplosionSpeed;
            _maxExplosionSpeed = maxExplosionSpeed;
        }

        public int NumberOfParticles => 60;
        public Vector ExplosionVelocity => new Vector(3f, 3f);
        public Vector LaunchVelocity => _launchVelocity;
    }

}
