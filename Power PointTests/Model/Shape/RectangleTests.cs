using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Power_Point.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        // Test 註解
        [TestMethod()]
        public void RectangleTest()
        {
            Rectangle rectangle = new Rectangle();
            Assert.IsNotNull(rectangle);
        }

        // Test 註解
        [TestMethod()]
        public void DrawTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            var rectangle = new Rectangle();

            rectangle.Draw(mockGraphics.Object);

            // Assert
            mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawSelectTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            var rectangle = new Rectangle();

            rectangle.DrawSelect(mockGraphics.Object);

            // Assert
            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawButtonTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            var rectangle = new Rectangle();

            rectangle.DrawButton(mockGraphics.Object);

            // Assert
            mockGraphics.Verify(g => g.DrawButtonRectangle(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // 點在範圍內
        [TestMethod()]
        public void SelectShapeTestInRange()
        {
            Rectangle rectangle = new Rectangle
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(100, 100)
            };
            Assert.IsTrue(rectangle.SelectShape(new Point(50, 50)));
        }

        // 點在範圍外
        [TestMethod()]
        public void SelectShapeTestOutOfRangeOne()
        {
            Rectangle rectangle = new Rectangle
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(10, 10)
            };
            Assert.IsFalse(rectangle.SelectShape(new Point(-10, 5)));
        }

        // 點在範圍外
        [TestMethod()]
        public void SelectShapeTestOutOfRangeTwo()
        {
            Rectangle rectangle = new Rectangle
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(10, 10)
            };
            Assert.IsFalse(rectangle.SelectShape(new Point(20, 5)));
        }

        // 點在範圍外
        [TestMethod()]
        public void SelectShapeTestOutOfRangeThree()
        {
            Rectangle rectangle = new Rectangle
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(10, 10)
            };
            Assert.IsFalse(rectangle.SelectShape(new Point(5, -10)));
        }

        // 點在範圍外
        [TestMethod()]
        public void SelectShapeTestOutOfRangeFour()
        {
            Rectangle rectangle = new Rectangle
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(10, 10)
            };
            Assert.IsFalse(rectangle.SelectShape(new Point(5, 20)));
        }

        // 矩形大小為零
        [TestMethod()]
        public void SelectShapeTestZeroRadius()
        {
            Rectangle rectangle = new Rectangle
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(0, 0)
            };
            Assert.IsFalse(rectangle.SelectShape(new Point(50, 50)));
        }
    }
}