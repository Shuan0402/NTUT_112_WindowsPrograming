using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Power_Point.Tests
{
    [TestClass()]
    public class LineTests
    {
        // Test 註解
        [TestMethod()]
        public void LineTest()
        {
            Line line = new Line();
            Assert.IsNotNull(line);
        }

        // Test 註解
        [TestMethod()]
        public void DrawTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            var line = new Line();

            line.Draw(mockGraphics.Object);

            // Assert
            mockGraphics.Verify(g => g.DrawLine(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawSelectTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            var line = new Line();

            line.DrawSelect(mockGraphics.Object);

            // Assert
            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawButtonTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            var line = new Line();

            line.DrawButton(mockGraphics.Object);

            // Assert
            mockGraphics.Verify(g => g.DrawButtonLine(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // 點在範圍內
        [TestMethod()]
        public void SelectShapeTestInRange()
        {
            Line line = new Line
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(100, 100)
            };
            Assert.IsTrue(line.SelectShape(new Point(50, 50)));
        }

        // 點在範圍外
        [TestMethod()]
        public void SelectShapeTestOutOfRangeOne()
        {
            Line line = new Line
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(10, 10)
            };
            Assert.IsFalse(line.SelectShape(new Point(-10, 5)));
        }

        // 點在範圍外
        [TestMethod()]
        public void SelectShapeTestOutOfRangeTwo()
        {
            Line line = new Line
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(10, 10)
            };
            Assert.IsFalse(line.SelectShape(new Point(50, 5)));
        }

        // 點在範圍外
        [TestMethod()]
        public void SelectShapeTestOutOfRangeThree()
        {
            Line line = new Line
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(10, 10)
            };
            Assert.IsFalse(line.SelectShape(new Point(5, -10)));
        }

        // 點在範圍外
        [TestMethod()]
        public void SelectShapeTestOutOfRangeFour()
        {
            Line line = new Line
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(10, 10)
            };
            Assert.IsFalse(line.SelectShape(new Point(5, 50)));
        }


        // 線長度為零
        [TestMethod()]
        public void SelectShapeTestZeroRadius()
        {
            Line line = new Line
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(0, 0)
            };
            Assert.IsFalse(line.SelectShape(new Point(50, 50)));
        }
    }
}