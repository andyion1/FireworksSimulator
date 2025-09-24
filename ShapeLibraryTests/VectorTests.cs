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
        public void TestConstructor_Initialization()
        {
            Vector v = new Vector(3.5f, -2f);

            Assert.AreEqual(3.5f, v.X);
            Assert.AreEqual(-2f, v.Y);
        }

        [TestMethod]
        public void TestVector_ReferencingValues()
        {
            Vector original = new Vector(1, 2);

            Vector copy = new Vector(original);

            Assert.AreEqual(original.X, copy.X);
            Assert.AreEqual(original.Y, copy.Y);
        }

        [TestMethod]
        public void ToString_ShowsFormattedValues()
        {
            Vector vector = new Vector(5, 6);

            var result = vector.ToString();

            Assert.AreEqual("(5, 6)", result);
        }

        [TestMethod]
        public void Addition_Works()
        {
            Vector vector1 = new Vector(1, 2);
            Vector vector2 = new Vector(3, 4);

            Vector result = vector1 + vector2;

            Assert.AreEqual(4, result.X);
            Assert.AreEqual(6, result.Y);
        }

        [TestMethod]
        public void Subtraction_Works()
        {
            var vector1 = new Vector(5, 6);
            var vector2 = new Vector(2, 3);

            var result = vector1 - vector2;

            Assert.AreEqual(3, result.X);
            Assert.AreEqual(3, result.Y);
        }

    }
}
