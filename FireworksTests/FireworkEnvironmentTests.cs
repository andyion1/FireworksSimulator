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
    public sealed class FireworkEnvironmentTests
    {
        private int DefaultWidth = 800;
        private int DefaultHeight = 600;
        private Colour DefaultColour = new Colour(255, 128, 0);

        private IExplosionPattern CreateDefaultPattern()
        {
            return new ExplosionPattern(-8f, 2.5f, 6.5f);
        }

        [TestMethod]
        public void Constructor_CreatesEmptyFireworksList()
        {
            FireworkEnvironment env = new FireworkEnvironment();

            Assert.IsNotNull(env.Fireworks);
            Assert.AreEqual(0, env.Fireworks.Count);
        }

        [TestMethod]
        public void AddFirework_ValidFirework_AddsToList()
        {
            FireworkEnvironment env = new FireworkEnvironment();
            IExplosionPattern pattern = CreateDefaultPattern();
            IFirework firework = new Firework(DefaultWidth, DefaultHeight, DefaultColour, pattern);

            env.AddFirework(firework);

            Assert.AreEqual(1, env.Fireworks.Count);
            Assert.IsTrue(env.Fireworks.Contains(firework));
        }

        [TestMethod]
        public void AddFirework_NullFirework_ThrowsArgumentNullException()
        {
            FireworkEnvironment env = new FireworkEnvironment();
            IFirework nullFirework = null;

            Assert.ThrowsException<ArgumentNullException>(
                () => env.AddFirework(nullFirework)
            );
        }

        [TestMethod]
        public void AddFirework_LaunchesFirework()
        {
            FireworkEnvironment env = new FireworkEnvironment();
            IExplosionPattern pattern = CreateDefaultPattern();
            Firework firework = new Firework(DefaultWidth, DefaultHeight, DefaultColour, pattern);

            env.AddFirework(firework);

            Assert.IsFalse(firework.Exploded);
            Assert.IsNotNull(firework.Particles);
        }

    }
}
