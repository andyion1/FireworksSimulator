using ShapeLib;
using ShapeLibrary;
using System.Drawing;

namespace ShapeLibraryTests;

[TestClass]
public sealed class RectangleTests
{
    private float x = 50f;
    private float y = 50f;
    private float width = 100f;
    private float height = 100f;

    private Colour DefaultColour = new Colour(100, 150, 200);

    [TestMethod]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        var rectangle = new Rectangle(x, y, width, height, DefaultColour);

        Assert.AreEqual(x, rectangle.X);
        Assert.AreEqual(y, rectangle.Y);
        Assert.AreEqual(width, rectangle.Width);
        Assert.AreEqual(height, rectangle.Height);
        Assert.AreEqual(DefaultColour, rectangle.Colour);
    }

    [TestMethod]
    public void Constructor_ThrowsException_WhenWidthIsZero()
    {
        float invalidWidth = 0f;

        Assert.ThrowsException<ArgumentException>(
            () => { var rectangle = new Rectangle(x, y, invalidWidth, height, DefaultColour); }
        );
    }

    [TestMethod]
    public void Vertices_CalculatedCorrectly()
    {
        var rectangle = new Rectangle(x, y, width, height, new Colour(255, 0, 0));

        var vertices = rectangle.Vertices;

        Assert.AreEqual($"({x}, {y})", vertices[0].ToString());
        Assert.AreEqual($"({x + width}, {y})", vertices[1].ToString());
        Assert.AreEqual($"({x + width}, {y + height})", vertices[2].ToString());
        Assert.AreEqual($"({x}, {y + height})", vertices[3].ToString());
    }
}
