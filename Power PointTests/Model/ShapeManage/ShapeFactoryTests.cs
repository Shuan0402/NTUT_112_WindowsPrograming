using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {

        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";

        // CreateShapeTest
        [TestMethod()]
        public void CreateShapeLineTest()
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            Shape shape = shapeFactory.CreateShape(LINE);

            Assert.IsTrue(shape is Line);
        }

        // CreateShapeTest
        [TestMethod()]
        public void CreateShapeRectangleTest()
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            Shape shape = shapeFactory.CreateShape(RECTANGLE);

            Assert.IsTrue(shape is Rectangle);
        }

        // CreateShapeTest
        [TestMethod()]
        public void CreateShapeCircleTest()
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            Shape shape = shapeFactory.CreateShape(CIRCLE);

            Assert.IsTrue(shape is Circle);
        }

        // CreateShapeTest
        [TestMethod()]
        public void CreateShapeNullTest()
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            Shape shape = shapeFactory.CreateShape("null");

            Assert.IsTrue(shape is Shape);
        }

        // GenerateRandomInfoTest
        [TestMethod()]
        public void GenerateRandomInfoTest()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            
            Line line = new Line();
            shapeFactory.GenerateRandomInfo(line);
            Assert.AreNotEqual("(0, 0), (0, 0)", line.Info);

            Circle circle = new Circle();
            shapeFactory.GenerateRandomInfo(circle);
            Assert.AreNotEqual("(0, 0), (0, 0)", circle.Info);

            Rectangle rectangle = new Rectangle();
            shapeFactory.GenerateRandomInfo(rectangle);
            Assert.AreNotEqual("(0, 0), (0, 0)", rectangle.Info);
        }
    }
}