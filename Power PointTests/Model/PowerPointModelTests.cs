using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Power_Point.Tests
{
    [TestClass()]
    public class PowerPointModelTests
    {
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";
        const string DRAW = "draw";
        const string POINT = "point";

        // Test 註解
        [TestMethod()]
        public void CreateShapeTest()
        {
            PowerPointModel model = new PowerPointModel();

            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(3, shapeList.Count);
            Assert.IsTrue(shapeList[0] is Line);
            Assert.IsTrue(shapeList[1] is Circle);
            Assert.IsTrue(shapeList[2] is Rectangle);
        }

        // Test 註解
        [TestMethod()]
        public void DeleteShapeTest()
        {
            PowerPointModel model = new PowerPointModel();

            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);
            model.DeleteShape(1);

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(2, shapeList.Count);
            Assert.IsTrue(shapeList[0] is Line);
            Assert.IsTrue(shapeList[1] is Rectangle);
        }

        // Test 註解
        [TestMethod()]
        public void DeleteSelecetedShapeTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._shapes.SelectedIndex = 1;
            model._shapes.IsSelected = true;

            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);
            model.DeleteSelecetedShape();

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(2, shapeList.Count);
            Assert.IsTrue(shapeList[0] is Line);
            Assert.IsTrue(shapeList[1] is Rectangle);
        }

        // Test 註解
        [TestMethod()]
        public void GetShapeDataTest()
        {
            PowerPointModel model = new PowerPointModel();

            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);
            List<ShapeData> shapeDatas = model.GetShapeData();

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;
            for (int i = 0; i < shapeList.Count; i++)
            {
                Assert.AreEqual(shapeList[i].Name, shapeDatas[i].Name);
                Assert.AreEqual(shapeList[i].Info, shapeDatas[i].Info);
            }
        }

        // Test 註解
        [TestMethod()]
        public void ClearShapesTest()
        {
            PowerPointModel model = new PowerPointModel();

            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);
            model.ClearShapes();

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;
            Assert.AreEqual(0, shapeList.Count);
        }

        // Test 註解
        [TestMethod()]
        public void PressPointerWithDrawStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new DrawState(model._shapes);

            Assert.IsFalse(model.IsPressed);
            model.PressPointer(10, 10, LINE);
            Assert.IsTrue(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void PressPointerWithPointStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new PointState(model._shapes);

            Assert.IsFalse(model.IsPressed);
            model.PressPointer(10, 10, LINE);
            Assert.IsTrue(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void PressPointerWithModifyStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new ModifyState(model._shapes);

            Assert.IsFalse(model.IsPressed);
            model.PressPointer(10, 10, LINE);
            Assert.IsTrue(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void PressPointerWithNoStateTest()
        {
            PowerPointModel model = new PowerPointModel();

            model.PressPointer(10, 10, LINE);
            Assert.IsFalse(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void PressPointerWithIsShapeSizableTest()
        {
            PowerPointModel model = new PowerPointModel
            {
                IsShapeSizable = true
            };
            model._mouse = new PointState(model._shapes);

            model.PressPointer(10, 10, LINE);
            Assert.IsTrue(model._mouse is ModifyState);
        }

        // Test 註解
        [TestMethod()]
        public void PressPointerWithIsNotShapeSizableTest()
        {
            PowerPointModel model = new PowerPointModel
            {
                IsShapeSizable = false
            };

            model.PressPointer(10, 10, LINE);
            Assert.IsFalse(model._mouse is ModifyState);
        }

        // Test 註解
        [TestMethod()]
        public void PressPointerWithShape()
        {
            PowerPointModel model = new PowerPointModel
            {
                IsShapeSizable = true
            };
            model._mouse = new PointState(model._shapes);

            model.PressPointer(10, 10, "Shape");
            Assert.IsFalse(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void PressPointerWithNotShape()
        {
            PowerPointModel model = new PowerPointModel
            {
                IsShapeSizable = true
            };
            model._mouse = new PointState(model._shapes);

            model.PressPointer(10, 10, LINE);
            Assert.IsTrue(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void PressMinusPointerTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new PointState(model._shapes);

            model.PressPointer(-10, -10, LINE);
            Assert.IsFalse(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void MovePointerWithNoPressTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.MovePointer(10, 10);

            Assert.IsFalse(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void MovePointerWithDrawStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new DrawState(model._shapes);
            model.PressPointer(1, 1, LINE);
            model.MovePointer(10, 10);

            Assert.IsTrue(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void MovePointerWithPointStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new PointState(model._shapes);
            model.PressPointer(1, 1, LINE);
            model.MovePointer(10, 10);

            Assert.IsTrue(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void ReleasePointerWithNoPressTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.ReleasePointer();

            Assert.IsFalse(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void ReleasePointerWithDrawStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new DrawState(model._shapes);
            model.PressPointer(1, 1, LINE);
            model.MovePointer(10, 10);
            model.ReleasePointer();

            Assert.IsFalse(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void ReleasePointerWithPointStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new PointState(model._shapes);
            model.PressPointer(1, 1, LINE);
            model.MovePointer(10, 10);
            model.ReleasePointer();

            Assert.IsFalse(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void ReleasePointerWithPointStateTestNoMove()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new PointState(model._shapes);
            model.PressPointer(1, 1, LINE);
            model.MovePointer(1, 1);
            model.ReleasePointer();

            Assert.IsFalse(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void ReleasePointerWithModifyStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.CreateShape(LINE);
            model._mouse = new ModifyState(model._shapes);
            model.PressPointer(1, 1, LINE);
            model.MovePointer(10, 10);
            model.ReleasePointer();

            Assert.IsFalse(model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void DrawPannelWithDrawStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            var mockGraphics = new Mock<IGraphics>();
            model._mouse = new DrawState(model._shapes);

            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);

            model.DrawPannel(mockGraphics.Object, 1);

            mockGraphics.Verify(g => g.DrawLine(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Never);
        }

        // Test 註解
        [TestMethod()]
        public void DrawPannelWithPointStateNotSelecteddTest()
        {
            PowerPointModel model = new PowerPointModel();
            var mockGraphics = new Mock<IGraphics>();
            model._mouse = new PointState(model._shapes);

            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);

            model.DrawPannel(mockGraphics.Object, 1);

            mockGraphics.Verify(g => g.DrawLine(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Never);
        }

        // Test 註解
        [TestMethod()]
        public void DrawPannelWithPointStateHasSelecteddTest()
        {
            PowerPointModel model = new PowerPointModel();
            var mockGraphics = new Mock<IGraphics>();
            model._mouse = new PointState(model._shapes);

            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);

            model._shapes.SelectedIndex = 1;
            model._shapes.IsSelected = true;
            model.DrawPannel(mockGraphics.Object, 1);

            mockGraphics.Verify(g => g.DrawLine(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawButtonTest()
        {
            PowerPointModel model = new PowerPointModel();
            var mockGraphics = new Mock<IGraphics>();
            model._mouse = new PointState(model._shapes);

            model.CreateShape(LINE);
            model.CreateShape(CIRCLE);
            model.CreateShape(RECTANGLE);

            model.DrawButton(mockGraphics.Object, 1);

            mockGraphics.Verify(g => g.DrawButtonLine(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawButtonCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawButtonRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void ChangeToDrawStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.ChangeState(DRAW);
            Assert.IsTrue(model._mouse is DrawState);
        }

        // Test 註解
        [TestMethod()]
        public void ChangeToPointStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.ChangeState(POINT);
            Assert.IsTrue(model._mouse is PointState);
        }

        // Test 註解
        [TestMethod()]
        public void ChangeToNullStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.ChangeState("null");
            Assert.IsNull(model._mouse);
        }

        // Test 註解
        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            // Arrange
            var model = new PowerPointModel();

            var changePannelEventCalled = false;
            var changeButtonEventCalled = false;

            model.ChangePannelEvent += () => changePannelEventCalled = true;
            model.ChangeButtonEvent += () => changeButtonEventCalled = true;

            // Act
            model.NotifyModelChanged();

            // Assert
            Assert.IsTrue(changePannelEventCalled);
            Assert.IsTrue(changeButtonEventCalled);
        }
    }
}*/