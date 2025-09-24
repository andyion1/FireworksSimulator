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
        public void ToString_ShowsFormattedValues()
        {
            Vector vector = new Vector(5, 6);

            var result = vector.ToString();

            Assert.AreEqual("(5, 6)", result);
        }
    }
}
