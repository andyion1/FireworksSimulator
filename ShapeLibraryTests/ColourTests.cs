using ShapeLibrary;

namespace ShapeLibraryTests;

[TestClass]
public sealed class ColourTests
{
    [TestMethod]
    public void TestConstructor_ClampsValuesCorrectly_Positive()
    {
        int red = -10, green = 260, blue = 128;

        Colour colour = new Colour(red, green, blue);

        Assert.AreEqual(0, colour.Red);
        Assert.AreEqual(255, colour.Green);
        Assert.AreEqual(128, colour.Blue);
    }

    [TestMethod]
    public void TestConstructor_ClampsValuesCorrectly_Negative()
    {
        int red = 300, green = -20, blue = -100;

        Colour colour = new Colour(red, green, blue);

        Assert.AreEqual(255, colour.Red);
        Assert.AreEqual(0, colour.Green);
        Assert.AreEqual(0, colour.Blue);
    }

    [TestMethod]
    public void TestAdditionOperator_Positive()
    {
        var colour1 = new Colour(100, 150, 200);
        var colour2 = new Colour(50, 50, 50);

        var result = colour1 + colour2;

        Assert.AreEqual(150, result.Red);
        Assert.AreEqual(200, result.Green);
        Assert.AreEqual(250, result.Blue);
    }

    [TestMethod]
    public void TestAdditionOperator_ClampsTo255()
    {
        var colour1 = new Colour(200, 100, 50);
        var colour2 = new Colour(100, 200, 255);

        var result = colour1 + colour2;

        Assert.AreEqual(255, result.Red);
        Assert.AreEqual(255, result.Green);
        Assert.AreEqual(255, result.Blue);
    }

    [TestMethod]
    public void TestSubtractionOperator_Positive()
    {
        var colour1 = new Colour(200, 150, 100);
        var colour2 = new Colour(50, 50, 50);

        var result = colour1 - colour2;

        Assert.AreEqual(150, result.Red);
        Assert.AreEqual(100, result.Green);
        Assert.AreEqual(50, result.Blue);
    }

    [TestMethod]
    public void TestSubtractionOperator_ClampsToZero()
    {
        var colour1 = new Colour(100, 100, 100);
        var colour2 = new Colour(150, 50, 200);

        var result = colour1 - colour2;

        Assert.AreEqual(0, result.Red);
        Assert.AreEqual(50, result.Green);
        Assert.AreEqual(0, result.Blue);
    }

    [TestMethod]
    public void TestMultiplicationOperator_Positive()
    {
        var colour1 = new Colour(10, 10, 10);
        var colour2 = new Colour(10, 20, 15);

        var result = colour1 * colour2;

        Assert.AreEqual(100, result.Red);
        Assert.AreEqual(200, result.Green);
        Assert.AreEqual(150, result.Blue);
    }

    [TestMethod]
    public void TestMultiplicationOperator_ClampsTo255()
    {
        var colour1 = new Colour(20, 50, 30);
        var colour2 = new Colour(20, 20, 20);

        var result = colour1 * colour2;

        Assert.AreEqual(255, result.Red);
        Assert.AreEqual(255, result.Green);
        Assert.AreEqual(255, result.Blue);
    }

    [TestMethod]
    public void TestEqualityOperator_Positive()
    {
        var colour1 = new Colour(100, 150, 200);
        var colour2 = new Colour(100, 150, 200);

        Assert.IsTrue(colour1 == colour2);
    }

    [TestMethod]
    public void TestEqualityOperator_Negative()
    {
        var colour1 = new Colour(100, 150, 200);
        var colour2 = new Colour(101, 150, 200);

        Assert.IsFalse(colour1 == colour2);
    }

    [TestMethod]
    public void TestInequalityOperator_Positive()
    {
        var colour1 = new Colour(100, 150, 200);
        var colour2 = new Colour(200, 150, 100);

        Assert.IsTrue(colour1 != colour2);
    }

    [TestMethod]
    public void TestInequalityOperator_Negative()
    {
        var colour1 = new Colour(50, 60, 70);
        var colour2 = new Colour(50, 60, 70);

        Assert.IsFalse(colour1 != colour2);
    }

    [TestMethod]
    public void TestToString_Positive()
    {
        var colour = new Colour(12, 34, 56);

        var result = colour.ToString();

        Assert.AreEqual("(12, 34, 56)", result);
    }

    [TestMethod]
    public void TestToString_Negative()
    {
        var colour = new Colour(255, 0, 128);

        var result = colour.ToString();

        Assert.AreNotEqual("(0, 0, 0)", result);
        Assert.AreEqual("(255, 0, 128)", result);
    }
}
