using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireWorks;
using ShapeLibrary;

namespace ShapeLibraryTests;

[TestClass]
public sealed class ParticleTests
{
    [TestMethod]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        var colour = new Colour(255, 0, 0);
        var particle = new Particle(10f, 20f, colour, 100);

        Assert.AreEqual(10f, particle.Position.X, 0.001);
        Assert.AreEqual(20f, particle.Position.Y, 0.001);
        Assert.AreEqual(colour, particle.Colour);
        Assert.AreEqual(false, particle.Done);
        Assert.IsNotNull(particle.Circle);
    }
}
