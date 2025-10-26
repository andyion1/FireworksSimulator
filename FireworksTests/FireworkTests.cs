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

        [TestMethod]
        public void Constructor_FullVersion_NullPattern_ThrowsArgumentNullException()
        {
            float x = 400f;
            float y = 500f;
            IExplosionPattern nullPattern = null;

            Assert.ThrowsException<ArgumentNullException>(
                () => new Firework(DefaultWidth, DefaultHeight, x, y, DefaultColour, DefaultLifespan, nullPattern)
            );
        }

        [TestMethod]
        public void Launch_SetsExplodedToFalse()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            Firework firework = new Firework(DefaultWidth, DefaultHeight, DefaultColour, pattern);

            firework.Launch();

            Assert.IsFalse(firework.Exploded);
        }

        [TestMethod]
        public void Launch_InitializesEmptyParticlesList()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            Firework firework = new Firework(DefaultWidth, DefaultHeight, DefaultColour, pattern);

            firework.Launch();

            Assert.IsNotNull(firework.Particles);
            Assert.AreEqual(0, firework.Particles.Count);
        }

        [TestMethod]
        public void Launch_AppliesVelocityToLauncher()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            Firework firework = new Firework(DefaultWidth, DefaultHeight, DefaultColour, pattern);
            Vector initialVelocity = new Vector(firework.Launcher.Velocity.X, firework.Launcher.Velocity.Y);

            firework.Launch();

            Assert.AreNotEqual(initialVelocity.Y, firework.Launcher.Velocity.Y);
        }

        [TestMethod]
        public void Update_BeforeExplosion_UpdatesLauncher()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            Firework firework = new Firework(DefaultWidth, DefaultHeight, DefaultColour, pattern);
            firework.Launch();
            Vector initialPosition = new Vector(firework.Launcher.Position.X, firework.Launcher.Position.Y);

            firework.Update();

            Assert.IsFalse(firework.Exploded);
            Assert.AreNotEqual(initialPosition.Y, firework.Launcher.Position.Y);
        }

        [TestMethod]
        public void Update_BeforeExplosion_ParticlesListRemainsEmpty()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            Firework firework = new Firework(DefaultWidth, DefaultHeight, DefaultColour, pattern);
            firework.Launch();

            firework.Update();

            Assert.AreEqual(0, firework.Particles.Count);
        }

        [TestMethod]
        public void Update_BeforeExplosion_ExplodedRemainsFalse()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            Firework firework = new Firework(DefaultWidth, DefaultHeight, DefaultColour, pattern);
            firework.Launch();

            firework.Update();

            Assert.IsFalse(firework.Exploded);
        }

        [TestMethod]
        public void Update_WhenLauncherExpires_FireworkExplodes()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            float x = 400f;
            float y = 500f;
            int shortLifespan = 1;
            Firework firework = new Firework(DefaultWidth, DefaultHeight, x, y, DefaultColour, shortLifespan, pattern);
            firework.Launch();

            firework.Update();
            firework.Update();

            Assert.IsTrue(firework.Exploded);
        }

        [TestMethod]
        public void Update_AfterExplosion_CreatesParticles()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            float x = 400f;
            float y = 500f;
            int shortLifespan = 1;
            Firework firework = new Firework(DefaultWidth, DefaultHeight, x, y, DefaultColour, shortLifespan, pattern);
            firework.Launch();

            firework.Update();
            firework.Update();

            // Assert
            Assert.IsTrue(firework.Particles.Count >= 60);
            Assert.IsTrue(firework.Particles.Count <= 100);
        }

        [TestMethod]
        public void Update_AfterExplosion_ParticlesHaveVelocity()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            float x = 400f;
            float y = 500f;
            int shortLifespan = 1;
            Firework firework = new Firework(DefaultWidth, DefaultHeight, x, y, DefaultColour, shortLifespan, pattern);
            firework.Launch();

            firework.Update();
            firework.Update();


            bool allParticlesHaveVelocity = true;
            foreach (Particle particle in firework.Particles)
            {
                if (particle.Velocity.X == 0 && particle.Velocity.Y == 0)
                {
                    allParticlesHaveVelocity = false;
                    break;
                }
            }
            Assert.IsTrue(allParticlesHaveVelocity);
        }

        [TestMethod]
        public void Update_AfterExplosion_RemovesExpiredParticles()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            float x = 400f;
            float y = 500f;
            int shortLifespan = 1;
            Firework firework = new Firework(
                DefaultWidth, DefaultHeight, x, y,
                DefaultColour, shortLifespan, pattern
            );
            firework.Launch();
            firework.Update();
            firework.Update();
            int initialParticleCount = firework.Particles.Count;

            //Update many times to let particles expire
            for (int i = 0; i < 100; i++)
            {
                firework.Update();
            }

            Assert.IsTrue(firework.Particles.Count < initialParticleCount);
        }

        [TestMethod]
        public void Update_AfterAllParticlesExpire_ParticlesListIsEmpty()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            float x = 400f;
            float y = 500f;
            int shortLifespan = 1;
            Firework firework = new Firework(
                DefaultWidth, DefaultHeight, x, y,
                DefaultColour, shortLifespan, pattern
            );
            firework.Launch();
            firework.Update();
            firework.Update();

            // Update enough times for all particles to expire
            for (int i = 0; i < 200; i++)
            {
                firework.Update();
            }

            Assert.AreEqual(0, firework.Particles.Count);
        }

        [TestMethod]
        public void Update_AfterExplosion_ParticlesMove()
        {
            IExplosionPattern pattern = CreateDefaultPattern();
            float x = 400f;
            float y = 500f;
            int shortLifespan = 1;
            Firework firework = new Firework(DefaultWidth, DefaultHeight, x, y, DefaultColour, shortLifespan, pattern);
            firework.Launch();
            firework.Update();
            firework.Update();

            Vector firstParticleInitialPosition = new Vector(
                firework.Particles[0].Position.X,
                firework.Particles[0].Position.Y
            );

            firework.Update();

            Assert.AreNotEqual(firstParticleInitialPosition.X, firework.Particles[0].Position.X);
        }
    }
}
