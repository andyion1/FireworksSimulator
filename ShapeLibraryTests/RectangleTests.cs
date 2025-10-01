using ShapeLibrary;

namespace ShapeLibraryTests;

[TestClass]
public sealed class RectangleTests
{
    [TestMethod]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        Colour colour = new Colour(100, 150, 200);
        Rectangle rectangle = new Rectangle(50, 50, 100, 100, colour);

        Assert.AreEqual(50f, rectangle.X);
        Assert.AreEqual(50f, rectangle.Y);
        Assert.AreEqual(100f, rectangle.Width);
        Assert.AreEqual(100f, rectangle.Height);
        Assert.AreEqual(colour, rectangle.Colour);
    }
}
