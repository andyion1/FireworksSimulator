using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibraryTests;
    
    [TestClass]
    public sealed class CircleTests
    {
        [TestMethod]
        public void Constructor_ValidArguments_CreatesCircle()
        {
            float expectedX = 100f;
            float expectedY = 200f;
            float expectedRadius = 50f;
            Colour expectedColour = new Colour(255, 0, 0);

            Circle circle = new Circle(expectedX, expectedY, expectedRadius, expectedColour);

            Assert.AreEqual(expectedX, circle.Center.X);
            Assert.AreEqual(expectedY, circle.Center.Y);
            Assert.AreEqual(expectedRadius, circle.Radius);
            Assert.AreEqual(expectedColour, circle.Colour);
        }
    }
