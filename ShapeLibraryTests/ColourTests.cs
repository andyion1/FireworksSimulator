using ShapeLibrary;

namespace ShapeLibraryTests;

[TestClass]
public sealed class ColourTests
{
    [TestMethod]
    public void Constructor_ClampsValuesCorrectly()
    {
        int red = -10, green = 260, blue = 128;

        Colour colour = new Colour(red, green, blue);

        Assert.AreEqual(0, colour.Red);
        Assert.AreEqual(255, colour.Green);
        Assert.AreEqual(128, colour.Blue);
    }
}
