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
    public class DrawStateTests
    {
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";

        // DrawState
        [TestMethod()]
        public void DrawStateTest()
        {
            Shapes shapes = new Shapes();

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            DrawState drawState = new DrawState(shapes);

            PrivateObject privateObject = new PrivateObject(drawState);
            Shapes stateShapes = privateObject.GetField("_shapes") as Shapes;

            Assert.AreEqual(shapes, stateShapes);
        }

        // MouseDownTest
        [TestMethod()]
        public void MouseDownTest()
        {
            Shapes shapes = new Shapes();
            DrawState drawState = new DrawState(shapes);
            PrivateObject privateObject = new PrivateObject(shapes);

            drawState.MouseDown(0, 0, LINE);
            Shape hint = privateObject.GetField("_hint") as Shape;

            Assert.AreEqual(0, hint.FirstPoint.X);
            Assert.AreEqual(0, hint.FirstPoint.Y);
            Assert.AreEqual(0, hint.EndPoint.X);
            Assert.AreEqual(0, hint.EndPoint.Y);
        }

        // MouseMoveTest
        [TestMethod()]
        public void MouseMoveTest()
        {
            Shapes shapes = new Shapes();
            DrawState drawState = new DrawState(shapes);
            PrivateObject privateObject = new PrivateObject(shapes);

            drawState.MouseDown(0, 0, LINE);
            drawState.MouseMove(10, 10);
            Shape hint = privateObject.GetField("_hint") as Shape;

            Assert.AreEqual(0, hint.FirstPoint.X);
            Assert.AreEqual(0, hint.FirstPoint.Y);
            Assert.AreEqual(10, hint.EndPoint.X);
            Assert.AreEqual(10, hint.EndPoint.Y);
        }

        // MouseUpTest
        [TestMethod()]
        public void MouseUpTest()
        {
            Shapes shapes = new Shapes();
            DrawState drawState = new DrawState(shapes);
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            drawState.MouseDown(0, 0, LINE);
            drawState.MouseMove(10, 10);
            drawState.MouseMove(20, 20);
            drawState.MouseUp();

            drawState.MouseDown(20, 20, CIRCLE);
            drawState.MouseMove(40, 40);
            drawState.MouseUp();

            drawState.MouseDown(30, 30, RECTANGLE);
            drawState.MouseMove(40, 40);
            drawState.MouseMove(60, 60);
            drawState.MouseUp();

            Assert.IsTrue(shapeList[0] is Line);
            Assert.AreEqual(0, shapeList[0].FirstPoint.X);
            Assert.AreEqual(0, shapeList[0].FirstPoint.Y);
            Assert.AreEqual(20, shapeList[0].EndPoint.X);
            Assert.AreEqual(20, shapeList[0].EndPoint.X);

            Assert.IsTrue(shapeList[1] is Circle);
            Assert.AreEqual(20, shapeList[1].FirstPoint.X);
            Assert.AreEqual(20, shapeList[1].FirstPoint.Y);
            Assert.AreEqual(40, shapeList[1].EndPoint.X);
            Assert.AreEqual(40, shapeList[1].EndPoint.Y);

            Assert.IsTrue(shapeList[2] is Rectangle);
            Assert.AreEqual(30, shapeList[2].FirstPoint.X);
            Assert.AreEqual(30, shapeList[2].FirstPoint.Y);
            Assert.AreEqual(60, shapeList[2].EndPoint.X);
            Assert.AreEqual(60, shapeList[2].EndPoint.Y);
        }
    }
}