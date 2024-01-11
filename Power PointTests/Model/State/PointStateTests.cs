using Microsoft.VisualStudio.TestTools.UnitTesting;
/*
namespace Power_Point.Tests
{
    [TestClass()]
    public class PointStateTests
    {
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";

        // PointStateTest
        [TestMethod()]
        public void PointStateTest()
        {
            Shapes shapes = new Shapes();

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            PointState pointState = new PointState(shapes);

            PrivateObject privateObject = new PrivateObject(pointState);
            Shapes stateShapes = privateObject.GetField("_shapes") as Shapes;

            Assert.AreEqual(shapes, stateShapes);
        }

        // MouseDownTest
        [TestMethod()]
        public void MouseDownTest()
        {
            Shapes shapes = new Shapes();
            PointState pointState = new PointState(shapes);
            pointState.MouseDown(50, 50, LINE);

            PrivateObject privateObject = new PrivateObject(pointState);
            Point point = privateObject.GetField("_point") as Point;
            Assert.AreEqual(50, point.X);
            Assert.AreEqual(50, point.Y);
        }

        // MouseUpTest
        [TestMethod()]
        public void MouseUpTest()
        {
            Shapes shapes = new Shapes();
            PointState pointState = new PointState(shapes);

            pointState.MouseDown(50, 50, LINE);
            pointState.MouseMove(60, 60);
            pointState.MouseUp();

            PrivateObject privateObject = new PrivateObject(pointState);
            Point point = privateObject.GetField("_point") as Point;
            Assert.AreEqual(60, point.X);
            Assert.AreEqual(60, point.Y);
        }

        // MouseMoveTest
        [TestMethod()]
        public void MouseMoveTest()
        {
            Shapes shapes = new Shapes();
            PointState pointState = new PointState(shapes);
            pointState.MouseDown(50, 50, LINE);
            pointState.MouseMove(60, 60);

            PrivateObject privateObject = new PrivateObject(pointState);
            Point point = privateObject.GetField("_point") as Point;
            Assert.AreEqual(60, point.X);
            Assert.AreEqual(60, point.Y);
        }
    }
}*/