using ShapeLib;
using ShapeLibrary;

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
        Rectangle rectangle = new Rectangle(x, y, width, height, DefaultColour);

        Assert.AreEqual(x, rectangle.X);
        Assert.AreEqual(y, rectangle.Y);
        Assert.AreEqual(width, rectangle.Width);
        Assert.AreEqual(height, rectangle.Height);
        Assert.AreEqual(DefaultColour, rectangle.Colour);
    }

    [TestMethod]
    public void Colour_AssignedCorrectly()
    {
        Colour customColour = new Colour(10, 20, 30);

        Rectangle rectangle = new Rectangle(x, y, width, height, customColour);

        Assert.AreEqual(customColour, rectangle.Colour);
    }

    [TestMethod]
    public void Constructor_ThrowsException_WhenWidthIsZero()
    {
        float invalidWidth = 0f;

        Assert.ThrowsException<ArgumentException>(
            () => { Rectangle rectangle = new Rectangle(x, y, invalidWidth, height, DefaultColour); }
        );
    }

    [TestMethod]
    public void Constructor_ThrowsException_WhenHeightIsNegative()
    {
        float invalidHeight = -10f;

        Assert.ThrowsException<ArgumentException>(
            () => { Rectangle rectangle = new Rectangle(x, y, width, invalidHeight, DefaultColour); }
        );
    }

    [TestMethod]
    public void Vertices_CalculatedCorrectly()
    {
        Rectangle rectangle = new Rectangle(x, y, width, height, new Colour(255, 0, 0));

        List<Vector> vertices = rectangle.Vertices;

        Assert.AreEqual($"({x}, {y})", vertices[0].ToString());
        Assert.AreEqual($"({x + width}, {y})", vertices[1].ToString());
        Assert.AreEqual($"({x + width}, {y + height})", vertices[2].ToString());
        Assert.AreEqual($"({x}, {y + height})", vertices[3].ToString());
    }
}
