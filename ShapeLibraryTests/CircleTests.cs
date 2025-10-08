using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibraryTests;

[TestClass]
public sealed class CircleTests
{
    private float marginalError = 0.001f;
    private float x = 100f;
    private float y = 200f;
    private float radius = 50f;
    private Colour defaultColour = new Colour(255, 0, 0);

    private int DefaultSegmentCount = 36;


    [TestMethod]
    public void Constructor_ValidArguments_CreatesCircle()
    {
        float expectedX = 100f;
        float expectedY = 200f;
        float expectedRadius = 50f;
        Colour expectedColour = new Colour(255, 0, 0);

        Circle circle = new Circle(expectedX, expectedY, expectedRadius, expectedColour);

        Assert.AreEqual(expectedX, circle.Center.X);
        Assert.AreEqual(expectedY, circle.Center.Y);
        Assert.AreEqual(expectedRadius, circle.Radius);
        Assert.AreEqual(expectedColour, circle.Colour);
    }

    [TestMethod]
    public void Constructor_ZeroRadius_ThrowsArgumentException()
    {
        float x = 100f;
        float y = 200f;
        float radius = 0f;
        Colour colour = new Colour(255, 0, 0);

        Assert.ThrowsException<ArgumentException>(() => new Circle(x, y, radius, colour));
    }

    [TestMethod]
    public void Constructor_NegativeRadius_ThrowsArgumentException()
    {
        float x = 100f;
        float y = 200f;
        float radius = -10f;
        Colour colour = new Colour(255, 0, 0);

        Assert.ThrowsException<ArgumentException>(() => new Circle(x, y, radius, colour));
    }

    [TestMethod]
    public void Vertices_ValidCircle_GeneratesCorrectNumberOfVertices()
    {
        float x = 100f;
        float y = 200f;
        float radius = 50f;
        Colour colour = new Colour(255, 0, 0);
        int expectedVertexCount = DefaultSegmentCount;

        Circle circle = new Circle(x, y, radius, colour);
        List<Vector> vertices = circle.Vertices;

        Assert.AreEqual(expectedVertexCount, vertices.Count);
    }

    [TestMethod]
    public void Vertices_FirstVertexCalculatedCorrectly()
    {
        float x = 100f;
        float y = 200f;
        float radius = 50f;
        Colour colour = new Colour(255, 0, 0);

        Circle circle = new Circle(x, y, radius, colour);
        Vector firstVertex = circle.Vertices[0];

        Assert.AreEqual(x + radius, firstVertex.X, marginalError);
        Assert.AreEqual(y, firstVertex.Y, marginalError);
    }
}