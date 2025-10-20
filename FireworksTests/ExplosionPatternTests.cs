using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShapeLibrary;
using Fireworks;

namespace FireworksTests
{
    [TestClass]
    public sealed class ExplosionPatternTests
    {
        private float DefaultLaunchSpeedY = -8f;
        private float DefaultMinExplosionSpeed = 2.5f;
        private float DefaultMaxExplosionSpeed = 6.5f;

        [TestMethod]
        public void Constructor_ValidArguments_CreatesExplosionPattern()
        {
            ExplosionPattern pattern = new ExplosionPattern(
                DefaultLaunchSpeedY,
                DefaultMinExplosionSpeed,
                DefaultMaxExplosionSpeed
            );

            Assert.IsNotNull(pattern);
            Assert.IsNotNull(pattern.LaunchVelocity);
        }
    }
}
