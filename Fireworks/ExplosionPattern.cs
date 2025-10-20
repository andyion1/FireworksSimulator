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

        public ExplosionPattern(float launchSpeedY, float minExplosionSpeed, float maxExplosionSpeed)
        {
            if (minExplosionSpeed <= 0)
                throw new ArgumentOutOfRangeException(nameof(minExplosionSpeed));
            if (maxExplosionSpeed < minExplosionSpeed)
                throw new ArgumentOutOfRangeException(nameof(maxExplosionSpeed));

            _rng = new Random();

            _minParticles = 60;
            _maxParticles = 100;

            if (_minParticles < 1)
                throw new ArgumentOutOfRangeException(nameof(_minParticles));
            if (_maxParticles < _minParticles)
                throw new ArgumentOutOfRangeException(nameof(_maxParticles));

            _launchVelocity = new Vector(0f, launchSpeedY);
            _minExplosionSpeed = minExplosionSpeed;
            _maxExplosionSpeed = maxExplosionSpeed;
        }

        public int NumberOfParticles => _rng.Next(_minParticles, _maxParticles + 1);
        public Vector ExplosionVelocity
        {
            get
            {
                float s = (float)(_rng.NextDouble() * (_maxExplosionSpeed - _minExplosionSpeed) + _minExplosionSpeed);
                return new Vector(s, s);
            }
        }

        public Vector LaunchVelocity => _launchVelocity;
    }

}
