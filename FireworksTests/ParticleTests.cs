using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;
using Fireworks;

namespace Fireworks.Test;

[TestClass]
public sealed class ParticleTests
{
    [TestMethod]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        Colour colour = new Colour(255, 0, 0);
        Particle particle = new Particle(10f, 20f, colour, 100);

        Assert.AreEqual(10f, particle.Position.X, 0.001);
        Assert.AreEqual(20f, particle.Position.Y, 0.001);
        Assert.AreEqual(colour, particle.Colour);
        Assert.AreEqual(false, particle.Done);
        Assert.IsNotNull(particle.Circle);
    }


    [TestMethod]
    public void ApplyGravity_ShouldIncreaseAccelerationY()
    {
        Colour colour = new Colour(0, 255, 0);
        Particle particle = new Particle(0f, 0f, colour, 50);

        var initialAccel = particle.Acceleration.Y;
        particle.ApplyGravity();

        Assert.IsTrue(particle.Acceleration.Y > initialAccel);
    }

    [TestMethod]
    public void ApplyVelocity_ShouldIncreaseVelocity()
    {
        Colour colour = new Colour(0, 0, 255);
        Particle particle = new Particle(0f, 0f, colour, 50);

        Vector velocityToAdd = new Vector(1f, 2f);
        particle.ApplyVelocity(velocityToAdd);

        Assert.AreEqual(1f, particle.Velocity.X, 0.001);
        Assert.AreEqual(2f, particle.Velocity.Y, 0.001);
    }

    [TestMethod]
    public void Update_ShouldMoveParticleAndDecreaseLifespan()
    {
        Colour colour = new Colour(255, 255, 0);
        Particle particle = new Particle(0f, 0f, colour, 3);

        particle.ApplyVelocity(new Vector(1f, 1f));
        particle.Update();

        Assert.AreEqual(1f, particle.Position.X, 0.001);
        Assert.AreEqual(1f, particle.Position.Y, 0.001);
        Assert.AreEqual(false, particle.Done);
    }

    [TestMethod]
    public void Update_ShouldSetDone_WhenLifespanExpires()
    {
        Colour colour = new Colour(255, 255, 255);
        Particle particle = new Particle(0f, 0f, colour, 1);

        particle.Update();

        Assert.IsTrue(particle.Done);
    }


    [TestMethod]
    public void Update_ShouldNotMove_WhenDoneIsTrue()
    {
        Colour colour = new Colour(100, 100, 100);
        Particle particle = new Particle(0f, 0f, colour, 1);

        particle.Update();

        Vector positionBefore = particle.Position;
        particle.Update();
        Vector positionAfter = particle.Position;

        Assert.AreEqual(positionBefore.X, positionAfter.X, 0.001);
        Assert.AreEqual(positionBefore.Y, positionAfter.Y, 0.001);
    }
}
