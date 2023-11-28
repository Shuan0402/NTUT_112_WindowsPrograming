using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Power_Point.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";
        const string FIRST = "first";
        const string END = "end";

        // Test 註解
        [TestMethod()]
        public void ShapesTest()
        {
            Shapes shapes = new Shapes();
            Assert.IsNotNull(shapes);
        }

        // Test 註解
        [TestMethod()]
        public void CreateShapeLineTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes); 
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(0, shapeList.Count);
            shapes.CreateShape(LINE);
            Shape temp = privateObject.GetField("_temp") as Shape;
            Assert.IsTrue(temp is Line);
            Assert.AreEqual(1, shapeList.Count);
            Assert.IsTrue(shapeList.Contains(temp));
        }

        // Test 註解
        [TestMethod()]
        public void CreateShapeCircleTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(0, shapeList.Count);
            shapes.CreateShape(CIRCLE);
            Shape temp = privateObject.GetField("_temp") as Shape;
            Assert.IsTrue(temp is Circle);
            Assert.AreEqual(1, shapeList.Count);
            Assert.IsTrue(shapeList.Contains(temp));
        }

        // Test 註解
        [TestMethod()]
        public void CreateShapeRectangleTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(0, shapeList.Count);
            shapes.CreateShape(RECTANGLE);
            Shape temp = privateObject.GetField("_temp") as Shape;
            Assert.IsTrue(temp is Rectangle);
            Assert.AreEqual(1, shapeList.Count);
            Assert.IsTrue(shapeList.Contains(temp));
        }

        // Test 註解
        [TestMethod()]
        public void CreateShapeTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(0, shapeList.Count);

            shapes.CreateShape(RECTANGLE);
            Shape temp1 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(LINE);
            Shape temp2 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(CIRCLE);
            Shape temp3 = privateObject.GetField("_temp") as Shape;

            Assert.AreEqual(3, shapeList.Count);
            Assert.IsTrue(shapeList.Contains(temp1));
            Assert.IsTrue(shapeList.Contains(temp2));
            Assert.IsTrue(shapeList.Contains(temp3));
        }

        // Test 註解
        [TestMethod()]
        public void DeleteShapeNotSelectedTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(0, shapeList.Count);

            shapes.CreateShape(RECTANGLE);
            Shape temp1 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(LINE);
            Shape temp2 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(CIRCLE);
            Shape temp3 = privateObject.GetField("_temp") as Shape;

            shapes.DeleteShape(1);

            Assert.AreEqual(2, shapeList.Count);
            Assert.IsTrue(shapeList.Contains(temp1));
            Assert.IsFalse(shapeList.Contains(temp2));
            Assert.IsTrue(shapeList.Contains(temp3));
        }

        // Test 註解
        [TestMethod()]
        public void DeleteShapeSelectedTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(0, shapeList.Count);

            shapes.CreateShape(RECTANGLE);
            Shape temp1 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(LINE);
            Shape temp2 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(CIRCLE);
            Shape temp3 = privateObject.GetField("_temp") as Shape;
            shapes.SelectedIndex = 1;
            shapes.IsSelected = true;

            shapes.DeleteShape(1);

            Assert.AreEqual(2, shapeList.Count);
            Assert.IsTrue(shapeList.Contains(temp1));
            Assert.IsFalse(shapeList.Contains(temp2));
            Assert.IsTrue(shapeList.Contains(temp3));
            Assert.AreEqual(-1, shapes.SelectedIndex);
            Assert.IsFalse(shapes.IsSelected);
        }

        // Test 註解
        [TestMethod()]
        public void DeleteSelectedShapeTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(0, shapeList.Count);

            shapes.CreateShape(RECTANGLE);
            Shape temp1 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(LINE);
            Shape temp2 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(CIRCLE);
            Shape temp3 = privateObject.GetField("_temp") as Shape;

            shapes.SelectedIndex = 1;
            shapes.IsSelected = true;

            Assert.IsTrue(shapes.IsSelected);
            shapes.DeleteSelectedShape();
            Assert.IsFalse(shapes.IsSelected);

            Assert.AreEqual(2, shapeList.Count);
            Assert.IsTrue(shapeList.Contains(temp1));
            Assert.IsFalse(shapeList.Contains(temp2));
            Assert.IsTrue(shapeList.Contains(temp3));
        }

        // Test 註解
        [TestMethod()]
        public void DeleteNotSelectedShapeTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(0, shapeList.Count);

            shapes.CreateShape(RECTANGLE);
            Shape temp1 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(LINE);
            Shape temp2 = privateObject.GetField("_temp") as Shape;
            shapes.CreateShape(CIRCLE);
            Shape temp3 = privateObject.GetField("_temp") as Shape;

            shapes.SelectedIndex = 1;
            shapes.IsSelected = false;

            shapes.DeleteSelectedShape();

            Assert.AreEqual(3, shapeList.Count);
            Assert.IsTrue(shapeList.Contains(temp1));
            Assert.IsTrue(shapeList.Contains(temp2));
            Assert.IsTrue(shapeList.Contains(temp3));
        }

        // Test 註解
        [TestMethod()]
        public void SelectShapeInRangeTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            shapeList[0].FirstPoint = new Point(0, 0);
            shapeList[0].EndPoint = new Point(0, 0);
            shapeList[1].FirstPoint = new Point(0, 0);
            shapeList[1].EndPoint = new Point(100, 100);
            shapeList[2].FirstPoint = new Point(0, 0);
            shapeList[2].EndPoint = new Point(0, 0);

            Assert.AreEqual(1, shapes.SelectShape(new Point(50, 50)));
            Assert.IsTrue(shapes.IsSelected);
        }

        // Test 註解
        [TestMethod()]
        public void SelectShapeOutOfRangeTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            shapeList[0].FirstPoint = new Point(0, 0);
            shapeList[0].EndPoint = new Point(0, 0);
            shapeList[1].FirstPoint = new Point(0, 0);
            shapeList[1].EndPoint = new Point(0, 0);
            shapeList[2].FirstPoint = new Point(0, 0);
            shapeList[2].EndPoint = new Point(0, 0);

            Assert.AreEqual(-1, shapes.SelectShape(new Point(50, 50)));
            Assert.IsFalse(shapes.IsSelected);
        }

        // Test 註解
        [TestMethod()]
        public void GetShapeDataTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            List<ShapeData> shapeDatas = shapes.GetShapeData();
            for (int i = 0; i < shapeList.Count; i++)
            {
                Assert.AreEqual(shapeList[i].Name, shapeDatas[i].Name);
                Assert.AreEqual(shapeList[i].Info, shapeDatas[i].Info);
            }

            Assert.AreEqual(shapeList.Count, shapeDatas.Count);
        }

        // Test 註解
        [TestMethod()]
        public void SetHintTypeTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            Shape hint = privateObject.GetField("_hint") as Shape;
            Assert.IsTrue(hint is Shape);

            shapes.SetHintType(LINE);
            hint = privateObject.GetField("_hint") as Shape;
            Assert.IsTrue(hint is Line);
            
            shapes.SetHintType(CIRCLE);
            hint = privateObject.GetField("_hint") as Shape;
            Assert.IsTrue(hint is Circle);
            
            shapes.SetHintType(RECTANGLE);
            hint = privateObject.GetField("_hint") as Shape;
            Assert.IsTrue(hint is Rectangle);
        }

        // Test 註解
        [TestMethod()]
        public void SetHintFirstPointTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);

            shapes.SetHintType(LINE);
            Shape hint = privateObject.GetField("_hint") as Shape;
            hint.FirstPoint.X = 0;
            hint.FirstPoint.Y = 0;

            shapes.SetHint(10, 10, FIRST);

            hint = privateObject.GetField("_hint") as Shape;

            Assert.AreEqual(10, hint.FirstPoint.X);
            Assert.AreEqual(10, hint.FirstPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void SetHintEndPointTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);

            shapes.SetHintType(LINE);
            Shape hint = privateObject.GetField("_hint") as Shape;
            hint.EndPoint.X = 0;
            hint.EndPoint.Y = 0;

            shapes.SetHint(10, 10, END);

            hint = privateObject.GetField("_hint") as Shape;

            Assert.AreEqual(10, hint.EndPoint.X);
            Assert.AreEqual(10, hint.EndPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void SetHintOtherPointTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);

            shapes.SetHintType(LINE);
            Shape hint = privateObject.GetField("_hint") as Shape;
            hint.FirstPoint.X = 0;
            hint.FirstPoint.Y = 0;
            hint.EndPoint.X = 0;
            hint.EndPoint.Y = 0;

            shapes.SetHint(10, 10, "Other");

            hint = privateObject.GetField("_hint") as Shape;

            Assert.AreEqual(0, hint.FirstPoint.X);
            Assert.AreEqual(0, hint.FirstPoint.Y);
            Assert.AreEqual(0, hint.EndPoint.X);
            Assert.AreEqual(0, hint.EndPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void InitializeHintTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);

            shapes.SetHintType(LINE);
            Shape hint = privateObject.GetField("_hint") as Shape;
            Assert.IsTrue(hint is Line);

            shapes.InitializeHint();
            hint = privateObject.GetField("_hint") as Shape;

            Assert.IsTrue(hint is Shape);
        }

        // Test 註解
        [TestMethod()]
        public void DrawShapeNoHintTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            Shapes shapes = new Shapes();

            PrivateObject privateObject = new PrivateObject(shapes);
            Shape hint = privateObject.GetField("_hint") as Shape;

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            shapes.DrawShape(mockGraphics.Object);

            mockGraphics.Verify(g => g.DrawLine(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
            mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
            mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawShapeWithHintTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            Shapes shapes = new Shapes();

            PrivateObject privateObject = new PrivateObject(shapes);
            Shape hint = privateObject.GetField("_hint") as Shape;

            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            shapes.SetHintType(LINE);

            shapes.DrawShape(mockGraphics.Object);

            mockGraphics.Verify(g => g.DrawLine(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
            mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
            mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawHasSelectTest()
        {
            Shapes shapes = new Shapes();
            var mockGraphics = new Mock<IGraphics>();

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            shapes.IsSelected = true;
            shapes.SelectedIndex = 1;

            shapes.DrawSelect(mockGraphics.Object);

            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawNotSelectTest()
        {
            Shapes shapes = new Shapes();
            var mockGraphics = new Mock<IGraphics>();

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            shapes.IsSelected = false;
            shapes.SelectedIndex = -1;

            shapes.DrawSelect(mockGraphics.Object);

            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>()), Times.Never);
        }

        // Test 註解
        [TestMethod()]
        public void DrawButtonShapeTest()
        {
            var mockGraphics = new Mock<IGraphics>();
            Shapes shapes = new Shapes();

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            shapes.DrawButtonShape(mockGraphics.Object);

            mockGraphics.Verify(g => g.DrawButtonLine(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
            mockGraphics.Verify(g => g.DrawButtonRectangle(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
            mockGraphics.Verify(g => g.DrawButtonCircle(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void SetGraphTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);
            Shape hint = privateObject.GetField("_hint") as Shape;

            hint.FirstPoint = new Point(0, 0);
            hint.EndPoint = new Point(100, 100);
            hint.Name = LINE;
            shapes.SetGraph();
            hint.Name = CIRCLE;
            shapes.SetGraph();
            hint.Name = RECTANGLE;
            shapes.SetGraph();

            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.IsTrue(shapeList[0] is Line);
            Assert.IsTrue(shapeList[1] is Circle);
            Assert.IsTrue(shapeList[2] is Rectangle);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(hint.FirstPoint, shapeList[i].FirstPoint);
                Assert.AreEqual(hint.EndPoint, shapeList[i].EndPoint);
            }
        }

        // Test 註解
        [TestMethod()]
        public void ClearTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);
            shapes.Clear();

            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;
            Assert.AreEqual(0, shapeList.Count);

        }

        // Test 註解
        [TestMethod()]
        public void SetMovedSelectedShapePositionTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapes.IsSelected = true;
            shapes.SelectedIndex = 1;
            shapeList[shapes.SelectedIndex].FirstPoint = new Point(0, 0);
            shapeList[shapes.SelectedIndex].EndPoint = new Point(100, 100);

            shapes.SetSelectedShapePosition(10, 50);

            Assert.AreEqual(10, shapeList[shapes.SelectedIndex].FirstPoint.X);
            Assert.AreEqual(50, shapeList[shapes.SelectedIndex].FirstPoint.Y);
            Assert.AreEqual(110, shapeList[shapes.SelectedIndex].EndPoint.X);
            Assert.AreEqual(150, shapeList[shapes.SelectedIndex].EndPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void SetMovedMinusSelectedShapePositionTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapes.IsSelected = true;
            shapes.SelectedIndex = 1;
            shapeList[shapes.SelectedIndex].FirstPoint = new Point(0, 0);
            shapeList[shapes.SelectedIndex].EndPoint = new Point(100, 100);

            shapes.SetSelectedShapePosition(-10, -50);

            Assert.AreEqual(-10, shapeList[shapes.SelectedIndex].FirstPoint.X);
            Assert.AreEqual(-50, shapeList[shapes.SelectedIndex].FirstPoint.Y);
            Assert.AreEqual(90, shapeList[shapes.SelectedIndex].EndPoint.X);
            Assert.AreEqual(50, shapeList[shapes.SelectedIndex].EndPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void SetMovedZeroSelectedShapePositionTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapes.IsSelected = true;
            shapes.SelectedIndex = 1;
            shapeList[shapes.SelectedIndex].FirstPoint = new Point(0, 0);
            shapeList[shapes.SelectedIndex].EndPoint = new Point(100, 100);

            shapes.SetSelectedShapePosition(0, 0);

            Assert.AreEqual(0, shapeList[shapes.SelectedIndex].FirstPoint.X);
            Assert.AreEqual(0, shapeList[shapes.SelectedIndex].FirstPoint.Y);
            Assert.AreEqual(100, shapeList[shapes.SelectedIndex].EndPoint.X);
            Assert.AreEqual(100, shapeList[shapes.SelectedIndex].EndPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void SetNotSelectedShapePositionTest()
        {
            Shapes shapes = new Shapes();
            PrivateObject privateObject = new PrivateObject(shapes);

            shapes.CreateShape(LINE);
            shapes.CreateShape(RECTANGLE);
            shapes.CreateShape(CIRCLE);

            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapes.IsSelected = false;
            shapes.SelectedIndex = 1;
            shapeList[shapes.SelectedIndex].FirstPoint = new Point(0, 0);
            shapeList[shapes.SelectedIndex].EndPoint = new Point(100, 100);

            shapes.SetSelectedShapePosition(10, 50);

            Assert.AreEqual(0, shapeList[shapes.SelectedIndex].FirstPoint.X);
            Assert.AreEqual(0, shapeList[shapes.SelectedIndex].FirstPoint.Y);
            Assert.AreEqual(100, shapeList[shapes.SelectedIndex].EndPoint.X);
            Assert.AreEqual(100, shapeList[shapes.SelectedIndex].EndPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void SetSelectedShapeSizeTestOne() 
        {
            PowerPointModel model = new PowerPointModel();
            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);

            model._shapes.SelectedIndex = 1;
            model._shapes.IsSelected = true;
            model.IsPressed = true;

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapes = privateObject.GetField("_shapes") as List<Shape>;

            shapes[1].FirstPoint.X = 5;
            shapes[1].EndPoint.X = 0;
            shapes[1].FirstPoint.Y = 5;
            shapes[1].EndPoint.Y = 0;

            model._shapes.SetSelectedShapeSize(10, 10);

            Assert.AreEqual(10, shapes[1].FirstPoint.X);
            Assert.AreEqual(10, shapes[1].FirstPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void SetSelectedShapeSizeTestTwo()
        {
            PowerPointModel model = new PowerPointModel();
            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);

            model._shapes.SelectedIndex = 1;
            model._shapes.IsSelected = true;
            model.IsPressed = true;

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapes = privateObject.GetField("_shapes") as List<Shape>;

            shapes[1].FirstPoint.X = 0;
            shapes[1].EndPoint.X = 5;
            shapes[1].FirstPoint.Y = 0;
            shapes[1].EndPoint.Y = 5;

            model._shapes.SetSelectedShapeSize(10, 10);

            Assert.AreEqual(10, shapes[1].EndPoint.X);
            Assert.AreEqual(10, shapes[1].EndPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void IsInRightFloorPointTest()
        {
            Shapes shapes = new Shapes();
            shapes.CreateShape(LINE);

            shapes.SelectedIndex = 0;
            shapes.IsSelected = true;

            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapeList[0].FirstPoint.X = 10;
            shapeList[0].EndPoint.X = 0;
            shapeList[0].FirstPoint.Y = 10;
            shapeList[0].EndPoint.Y = 0;

            Assert.IsTrue(shapes.IsInRightFloorPoint(8, 8));
        }

        // Test 註解
        [TestMethod()]
        public void IsNotInRightFloorPointTestOne()
        {
            Shapes shapes = new Shapes();
            shapes.CreateShape(LINE);

            shapes.SelectedIndex = 0;
            shapes.IsSelected = true;

            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapeList[0].FirstPoint.X = 10;
            shapeList[0].EndPoint.X = 0;
            shapeList[0].FirstPoint.Y = 10;
            shapeList[0].EndPoint.Y = 0;

            Assert.IsFalse(shapes.IsInRightFloorPoint(20, 20));
        }

        // Test 註解
        [TestMethod()]
        public void IsNotInRightFloorPointTestTwo()
        {
            Shapes shapes = new Shapes();
            shapes.CreateShape(LINE);

            shapes.SelectedIndex = 0;
            shapes.IsSelected = true;

            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapeList[0].FirstPoint.X = 10;
            shapeList[0].EndPoint.X = 0;
            shapeList[0].FirstPoint.Y = 10;
            shapeList[0].EndPoint.Y = 0;

            Assert.IsFalse(shapes.IsInRightFloorPoint(8, 20));
        }

        // Test 註解
        [TestMethod()]
        public void IsNotInRightFloorPointTestThree()
        {
            Shapes shapes = new Shapes();
            shapes.CreateShape(LINE);

            shapes.SelectedIndex = 0;
            shapes.IsSelected = true;

            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapeList[0].FirstPoint.X = 10;
            shapeList[0].EndPoint.X = 0;
            shapeList[0].FirstPoint.Y = 10;
            shapeList[0].EndPoint.Y = 0;

            Assert.IsFalse(shapes.IsInRightFloorPoint(20, 8));
        }

        // Test 註解
        [TestMethod()]
        public void IsNotInRightFloorPointTestFor()
        {
            Shapes shapes = new Shapes();
            shapes.CreateShape(LINE);

            shapes.SelectedIndex = 0;
            shapes.IsSelected = true;

            PrivateObject privateObject = new PrivateObject(shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            shapeList[0].FirstPoint.X = 10;
            shapeList[0].EndPoint.X = 0;
            shapeList[0].FirstPoint.Y = 10;
            shapeList[0].EndPoint.Y = 0;

            Assert.IsFalse(shapes.IsInRightFloorPoint(2, 2));
        }
    }
}