using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShapeLibrary;

namespace ShapeLibraryTests
{
    [TestClass]
    public sealed class VectorTests
    {
        [TestMethod]
        public void TestConstructorInitialization()
        {
            Vector v = new Vector(3.5f, -2f);

            Assert.AreEqual(3.5f, v.X);
            Assert.AreEqual(-2f, v.Y);
        }

        [TestMethod]
        public void TestVectorReferencingValues()
        {
            Vector original = new Vector(1, 2);

            Vector copy = new Vector(original);

            Assert.AreEqual(original.X, copy.X);
            Assert.AreEqual(original.Y, copy.Y);
        }

        [TestMethod]
        public void TestToStringShowsCorrectValue()
        {
            Vector vector = new Vector(5, 6);

            var result = vector.ToString();

            Assert.AreEqual("(5, 6)", result);
        }

        [TestMethod]
        public void TestAdditionWorks()
        {
            Vector vector1 = new Vector(1, 2);
            Vector vector2 = new Vector(3, 4);

            Vector result = vector1 + vector2;

            Assert.AreEqual(4f, result.X);
            Assert.AreEqual(6f, result.Y);
        }

        [TestMethod]
        public void TestSubstractionWorks()
        {
            Vector vector1 = new Vector(5, 6);
            Vector vector2 = new Vector(2, 3);

            Vector result = vector1 - vector2;

            Assert.AreEqual(3f, result.X);
            Assert.AreEqual(3f, result.Y);
        }

        [TestMethod]
        public void TestMultiplicationWorks()
        {
            Vector vector = new Vector(2, 3);

            Vector result = vector * 2f;

            Assert.AreEqual(4f, result.X);
            Assert.AreEqual(6f, result.Y);
        }

        [TestMethod]
        public void TestDivisionWorks()
        {
            Vector vector = new Vector(4, 8);

            Vector result = vector / 2f;

            Assert.AreEqual(2f, result.X);
            Assert.AreEqual(4f, result.Y);
        }

        [TestMethod]
        public void TestDivisionBy0Exception()
        {
            Vector vector = new Vector(4, 8);

            Assert.ThrowsException<DivideByZeroException>(() => vector / 0f);
        }


        [TestMethod]
        public void TestMagnitudeWorks()
        {
            Vector vector = new Vector(3, 4);

            float result = Vector.Magnitude(vector);

            Assert.AreEqual(5f, result);
        }

        [TestMethod]
        public void TestNormalizationWorks()
        {
            Vector vector = new Vector(10, 0);

            Vector result = Vector.Normalize(vector);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(0f, result.Y);
            Assert.AreEqual(1f, Vector.Magnitude(result));
        }

    }
}
