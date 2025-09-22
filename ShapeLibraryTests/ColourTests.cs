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

    [TestMethod]
    public void TestSubstractionOperator()
    {
        var colour1 = new Colour(100, 100, 100);
        var colour2 = new Colour(150, 50, 200);

        var result = colour1 - colour2;

        Assert.AreEqual(0, result.Red);
        Assert.AreEqual(50, result.Green);
        Assert.AreEqual(0, result.Blue);
    }

    [TestMethod]
    public void TestMultiplicationOperator()
    {
        var colour1 = new Colour(10, 20, 30);
        var colour2 = new Colour(10, 20, 10);

        var result = colour1 * colour2;

        Assert.AreEqual(100, result.Red);
        Assert.AreEqual(255, result.Green);
        Assert.AreEqual(255, result.Blue);
    }

    [TestMethod]
    public void TestEqualityOperator()
    {
        var colour1 = new Colour(100, 150, 200);
        var colour2 = new Colour(100, 150, 200);

        Assert.IsTrue(colour1 == colour2);
    }

    [TestMethod]
    public void TestInequalityOperator()
    {
        var colour1 = new Colour(100, 150, 200);
        var colour2 = new Colour(200, 150, 100);

        Assert.IsTrue(colour1 != colour2);
    }

    [TestMethod]
    public void TestToString()
    {
        var colour = new Colour(12, 34, 56);

        var result = colour.ToString();

        Assert.AreEqual("(12, 34, 56)", result);
    }
}
