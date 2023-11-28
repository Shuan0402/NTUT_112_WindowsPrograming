using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        // Test 註解
        [TestMethod()]
        public void ShapeTest()
        {
            Shape shape = new Shape();
            Assert.IsTrue(shape is Shape);
            Assert.IsNotNull(shape);
        }

        // Test 註解
        [TestMethod()]
        public void SetInfoTest()
        {
            Shape shape = new Shape();
            string testString = "Test Information";

            shape.Info = testString;

            Assert.AreEqual(testString, shape.Info);
        }

        // Test 註解
        [TestMethod()]
        public void DrawButtonTest()
        {
            Shape shape = new Shape();
            var mockGraphics = new Mock<IGraphics>();

            shape.DrawButton(mockGraphics.Object);

            Assert.IsTrue(shape.IsCalled);
        }

        // Test 註解
        [TestMethod()]
        public void DrawSelectTest()
        {
            Shape shape = new Shape();
            var mockGraphics = new Mock<IGraphics>();

            shape.DrawSelect(mockGraphics.Object);

            Assert.IsTrue(shape.IsCalled);
        }

        // Test 註解
        [TestMethod()]
        public void DrawTest()
        {
            Shape shape = new Shape();
            var mockGraphics = new Mock<IGraphics>();

            shape.Draw(mockGraphics.Object);

            Assert.IsTrue(shape.IsCalled);
        }

        // Test 註解
        [TestMethod()]
        public void SelectShape()
        {
            Shape shape = new Shape();
            Assert.IsFalse(shape.SelectShape(new Point(10, 10)));
        }
    }
}