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

    [TestMethod]
    public void TestAdditionOperator()
    {
        var colour1 = new Colour(200, 100, 50);
        var colour2 = new Colour(100, 200, 255);

        var result = colour1 + colour2;

        Assert.AreEqual(255, result.Red);
        Assert.AreEqual(255, result.Green);
        Assert.AreEqual(255, result.Blue);
    }
}
