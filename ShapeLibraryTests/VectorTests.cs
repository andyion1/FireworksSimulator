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
            var v = new Vector(3.5f, -2f);
            Assert.AreEqual(3.5f, v.X);
            Assert.AreEqual(-2f, v.Y);
        }
    }
}
