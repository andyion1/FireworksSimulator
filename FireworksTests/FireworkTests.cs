using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fireworks;
using ShapeLibrary;

namespace FireworksTests
{
    [TestClass]
    public sealed class FireworkTests
    {
        private int DefaultWidth = 800;
        private int DefaultHeight = 600;
        private Colour DefaultColour = new Colour(255, 128, 0);
        private int DefaultLifespan = 60;
        private float DefaultLaunchSpeedY = -8f;
        private float DefaultMinExplosionSpeed = 2.5f;
        private float DefaultMaxExplosionSpeed = 6.5f;

        private IExplosionPattern CreateDefaultPattern()
        {
            return new ExplosionPattern(
                DefaultLaunchSpeedY,
                DefaultMinExplosionSpeed,
                DefaultMaxExplosionSpeed
            );
        }

        [TestMethod]
        public void Constructor_SimpleVersion_CreatesFirework()
        {
            IExplosionPattern pattern = CreateDefaultPattern();

            Firework firework = new Firework(DefaultWidth, DefaultHeight, DefaultColour, pattern);

            Assert.IsNotNull(firework);
            Assert.IsNotNull(firework.Launcher);
            Assert.IsFalse(firework.Exploded);
        }

        [TestMethod]
        public void Constructor_NullPattern_ThrowsArgumentNullException()
        {
            IExplosionPattern nullPattern = null;

            Assert.ThrowsException<ArgumentNullException>(
                () => new Firework(DefaultWidth, DefaultHeight, DefaultColour, nullPattern)
            );
        }

        [TestMethod]
        public void Constructor_FullVersion_CreatesFireworkAtSpecifiedPosition()
        {
            float x = 400f;
            float y = 500f;
            IExplosionPattern pattern = CreateDefaultPattern();

            Firework firework = new Firework(DefaultWidth, DefaultHeight, x, y, DefaultColour, DefaultLifespan, pattern);

            Assert.IsNotNull(firework);
            Assert.IsNotNull(firework.Launcher);
            Assert.AreEqual(x, firework.Launcher.Position.X);
            Assert.AreEqual(y, firework.Launcher.Position.Y);
        }
    }
}
