using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Power_Point.Tests
{
    [TestClass()]
    public class CircleTests
    {
        // CircleTest
        [TestMethod()]
        public void CircleTest()
        {
            Circle circle = new Circle();
            Assert.IsNotNull(circle);
        }

        // DrawTest
        [TestMethod()]
        public void DrawTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            var circle = new Circle();

            circle.Draw(mockGraphics.Object, 1);

            // Assert
            mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
        }

        // DrawButtonTest
        [TestMethod()]
        public void DrawButtonTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            var circle = new Circle();

            circle.DrawButton(mockGraphics.Object, 1);

            // Assert
            mockGraphics.Verify(g => g.DrawButtonCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
        }

        // DrawSelectTest
        [TestMethod()]
        public void DrawSelectTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            var circle = new Circle();

            circle.DrawSelect(mockGraphics.Object, 1);

            // Assert
            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
        }

        // 點在圓內
        [TestMethod()]
        public void SelectShapeTestInRange()
        {
            Circle circle = new Circle
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(100, 100)
            };
            Assert.IsTrue(circle.SelectShape(new Point(50, 50)));
        }

        // 點在圓外
        [TestMethod()]
        public void SelectShapeTestOutOfRange()
        {
            Circle circle = new Circle
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(10, 10)
            };
            Assert.IsFalse(circle.SelectShape(new Point(50, 50)));
        }

        // 圓半徑為零
        [TestMethod()]
        public void SelectShapeTestZeroRadius()
        {
            Circle circle = new Circle
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(0, 0)
            };
            Assert.IsFalse(circle.SelectShape(new Point(50, 50)));
        }
    }
}