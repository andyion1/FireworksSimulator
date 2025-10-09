using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeLibrary;
using Fireworks;

namespace Fireworks.Test
{
    [TestClass]
    public sealed class ParticleTests
    {
        private float Margin = 0.001f;
        private float DefaultX = 0f;
        private float DefaultY = 0f;
        private float VelocityX = 1f;
        private float VelocityY = 1f;
        private int LongLifespan = 100;
        private int ShortLifespan = 1;
        private int MediumLifespan = 3;

        private static Colour DefaultColour = new Colour(255, 255, 255);

        [TestMethod]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            Particle particle = new Particle(10f, 20f, DefaultColour, LongLifespan);

            Assert.AreEqual(10f, particle.Position.X, Margin);
            Assert.AreEqual(20f, particle.Position.Y, Margin);
            Assert.AreEqual(DefaultColour, particle.Colour);
            Assert.IsFalse(particle.Done);
            Assert.IsNotNull(particle.Circle);
        }

        [TestMethod]
        public void ApplyGravity_ShouldIncreaseAccelerationY()
        {
            Particle particle = new Particle(DefaultX, DefaultY, DefaultColour, LongLifespan);

            float initialAccel = particle.Acceleration.Y;
            particle.ApplyGravity();
            float newAccel = particle.Acceleration.Y;

            Assert.IsTrue(newAccel > initialAccel);
        }

        [TestMethod]
        public void ApplyVelocity_ShouldIncreaseVelocity()
        {
            Particle particle = new Particle(DefaultX, DefaultY, DefaultColour, LongLifespan);

            Vector velocity = new Vector(VelocityX, VelocityY);
            particle.ApplyVelocity(velocity);

            Assert.AreEqual(VelocityX, particle.Velocity.X, Margin);
            Assert.AreEqual(VelocityY, particle.Velocity.Y, Margin);
        }

        [TestMethod]
        public void Update_ShouldMoveParticleAndDecreaseLifespan()
        {
            Particle particle = new Particle(DefaultX, DefaultY, DefaultColour, MediumLifespan);

            Vector velocity = new Vector(VelocityX, VelocityY);
            particle.ApplyVelocity(velocity);
            particle.Update();

            Assert.AreEqual(VelocityX, particle.Position.X, Margin);
            Assert.AreEqual(VelocityY, particle.Position.Y, Margin);
            Assert.IsFalse(particle.Done);
        }

        [TestMethod]
        public void Update_ShouldSetDone_WhenLifespanExpires()
        {
            Particle particle = new Particle(DefaultX, DefaultY, DefaultColour, ShortLifespan);

            particle.Update();

            Assert.IsTrue(particle.Done);
        }

        [TestMethod]
        public void Update_ShouldNotMove_WhenDoneIsTrue()
        {
            Particle particle = new Particle(DefaultX, DefaultY, DefaultColour, ShortLifespan);

            particle.Update();

            Vector positionBefore = particle.Position;
            particle.Update();
            Vector positionAfter = particle.Position;

            Assert.AreEqual(positionBefore.X, positionAfter.X, Margin);
            Assert.AreEqual(positionBefore.Y, positionAfter.Y, Margin);
        }
    }
}
