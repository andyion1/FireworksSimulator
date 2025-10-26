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

        [TestMethod]
        public void Constructor_MinExplosionSpeedZero_ThrowsArgumentOutOfRangeException()
        {
            float invalidMinSpeed = 0f;

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new ExplosionPattern(DefaultLaunchSpeedY, invalidMinSpeed, DefaultMaxExplosionSpeed)
            );
        }

        [TestMethod]
        public void Constructor_MinExplosionSpeedNegative_ThrowsArgumentOutOfRangeException()
        {
            float invalidMinSpeed = -5f;

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new ExplosionPattern(DefaultLaunchSpeedY, invalidMinSpeed, DefaultMaxExplosionSpeed)
            );
        }

        [TestMethod]
        public void Constructor_MaxExplosionSpeedLessThanMin_ThrowsArgumentOutOfRangeException()
        {
            float minSpeed = 5f;
            float invalidMaxSpeed = 3f;

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new ExplosionPattern(DefaultLaunchSpeedY, minSpeed, invalidMaxSpeed)
            );
        }

        [TestMethod]
        public void LaunchVelocity_ReturnsCorrectVelocity()
        {
            float launchSpeedY = -10f;
            ExplosionPattern pattern = new ExplosionPattern(launchSpeedY, DefaultMinExplosionSpeed, DefaultMaxExplosionSpeed);

            Vector launchVelocity = pattern.LaunchVelocity;

            Assert.AreEqual(0f, launchVelocity.X);
            Assert.AreEqual(launchSpeedY, launchVelocity.Y);
        }

        [TestMethod]
        public void LaunchVelocity_ConsistentAcrossMultipleCalls()
        {
            ExplosionPattern pattern = new ExplosionPattern(DefaultLaunchSpeedY, DefaultMinExplosionSpeed, DefaultMaxExplosionSpeed);

            Vector velocity1 = pattern.LaunchVelocity;
            Vector velocity2 = pattern.LaunchVelocity;

            Assert.AreEqual(velocity1.X, velocity2.X);
            Assert.AreEqual(velocity1.Y, velocity2.Y);
        }

        [TestMethod]
        public void NumberOfParticles_ReturnsValueInValidRange()
        {
            ExplosionPattern pattern = new ExplosionPattern(DefaultLaunchSpeedY, DefaultMinExplosionSpeed, DefaultMaxExplosionSpeed);

            int particleCount = pattern.NumberOfParticles;

            Assert.IsTrue(particleCount >= 60);
            Assert.IsTrue(particleCount <= 100);
        }

        [TestMethod]
        public void ExplosionVelocity_ReturnsValueInValidRange()
        {
            float minSpeed = 2.5f;
            float maxSpeed = 6.5f;
            ExplosionPattern pattern = new ExplosionPattern(DefaultLaunchSpeedY, minSpeed, maxSpeed);

            Vector explosionVelocity = pattern.ExplosionVelocity;
            float speed = explosionVelocity.X;

            Assert.IsTrue(speed >= minSpeed);
            Assert.IsTrue(speed <= maxSpeed);
            Assert.AreEqual(explosionVelocity.X, explosionVelocity.Y);
        }

        [TestMethod]
        public void ExplosionVelocity_NegativeValues_ReturnsPositiveSpeed()
        {
            ExplosionPattern pattern = new ExplosionPattern(DefaultLaunchSpeedY, DefaultMinExplosionSpeed, DefaultMaxExplosionSpeed);

            Vector explosionVelocity = pattern.ExplosionVelocity;

            Assert.IsTrue(explosionVelocity.X > 0);
            Assert.IsTrue(explosionVelocity.Y > 0);
        }
    }
}
