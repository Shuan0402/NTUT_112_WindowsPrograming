using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Windows.Forms;
/*
namespace Power_Point.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";

        // Test 註解
        [TestMethod()]
        public void IsButtonCheckedTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model)
            {
                IsArrowChecked = true,
                IsCircleChecked = true,
                IsLineChecked = true,
                IsRectangleChecked = true
            };

            Assert.IsTrue(presentationModel.IsArrowChecked);
            Assert.IsTrue(presentationModel.IsCircleChecked);
            Assert.IsTrue(presentationModel.IsLineChecked);
            Assert.IsTrue(presentationModel.IsRectangleChecked);
        }

        // Test 註解
        [TestMethod()]
        public void PresentationModelTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);
            Assert.AreEqual(model, presentationModel._model);
        }

        // Test 註解
        [TestMethod()]
        public void CheckArrowTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CheckArrow();

            PrivateObject privateObject = new PrivateObject(presentationModel);
            string selectShapeType = privateObject.GetField("_selectButtonType") as string;
            Assert.AreEqual(null, selectShapeType);
            Assert.IsFalse(presentationModel.IsLineChecked);
            Assert.IsFalse(presentationModel.IsCircleChecked);
            Assert.IsFalse(presentationModel.IsRectangleChecked);
            Assert.IsTrue(presentationModel.IsArrowChecked);
            Assert.IsTrue(presentationModel._model._mouse is PointState);
        }

        // Test 註解
        [TestMethod()]
        public void CheckLineTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model)
            {
                IsLineChecked = false
            };
            presentationModel.CheckLine();

            PrivateObject privateObject = new PrivateObject(presentationModel);
            string selectShapeType = privateObject.GetField("_selectButtonType") as string;
            Assert.AreEqual(LINE, selectShapeType);
            Assert.IsTrue(presentationModel.IsLineChecked);
            Assert.IsFalse(presentationModel.IsCircleChecked);
            Assert.IsFalse(presentationModel.IsRectangleChecked);
            Assert.IsFalse(presentationModel.IsArrowChecked);
            Assert.IsTrue(presentationModel._model._mouse is DrawState);
        }

        // Test 註解
        [TestMethod()]
        public void CheckCircleTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model)
            {
                IsCircleChecked = false
            };
            presentationModel.CheckCircle();

            PrivateObject privateObject = new PrivateObject(presentationModel);
            string selectShapeType = privateObject.GetField("_selectButtonType") as string;
            Assert.AreEqual(CIRCLE, selectShapeType);
            Assert.IsFalse(presentationModel.IsLineChecked);
            Assert.IsTrue(presentationModel.IsCircleChecked);
            Assert.IsFalse(presentationModel.IsRectangleChecked);
            Assert.IsFalse(presentationModel.IsArrowChecked);
            Assert.IsTrue(presentationModel._model._mouse is DrawState);
        }

        // Test 註解
        [TestMethod()]
        public void CheckRectangleTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model)
            {
                IsRectangleChecked = false
            };
            presentationModel.CheckRectangle();

            PrivateObject privateObject = new PrivateObject(presentationModel);
            string selectShapeType = privateObject.GetField("_selectButtonType") as string;
            Assert.AreEqual(RECTANGLE, selectShapeType);
            Assert.IsFalse(presentationModel.IsLineChecked);
            Assert.IsFalse(presentationModel.IsCircleChecked);
            Assert.IsTrue(presentationModel.IsRectangleChecked);
            Assert.IsFalse(presentationModel.IsArrowChecked);
            Assert.IsTrue(presentationModel._model._mouse is DrawState);
        }

        // Test 註解
        [TestMethod()]
        public void GetShapeDataTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(CIRCLE);
            presentationModel.CreateShape(RECTANGLE);

            List<ShapeData> shapeDatas = presentationModel.GetShapeData();

            PrivateObject privateObject = new PrivateObject(presentationModel._model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            for (int i = 0; i < shapeDatas.Count; i++)
            {
                Assert.AreEqual(shapeList[i].Name, shapeDatas[i].Name);
                Assert.AreEqual(shapeList[i].Info, shapeDatas[i].Info);
            }
        }

        // Test 註解
        [TestMethod()]
        public void CreateShapeTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(CIRCLE);
            presentationModel.CreateShape(RECTANGLE);

            PrivateObject privateObject = new PrivateObject(presentationModel._model._shapes);
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
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(CIRCLE);
            presentationModel.CreateShape(RECTANGLE);
            presentationModel.DeleteShape(1);

            PrivateObject privateObject = new PrivateObject(presentationModel._model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(2, shapeList.Count);
            Assert.IsTrue(shapeList[0] is Line);
            Assert.IsTrue(shapeList[1] is Rectangle);
        }

        // Test 註解
        [TestMethod()]
        public void PointerPressedWithStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);
            model._mouse = new DrawState(model._shapes);

            presentationModel.PointerPressed(10, 10);

            Assert.IsTrue(presentationModel._model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void PointerPressedWithNoStateTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.PointerPressed(10, 10);

            Assert.IsFalse(presentationModel._model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void PointerPressedWithMinusInputTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.PointerPressed(-10, -10);

            Assert.IsFalse(presentationModel._model.IsPressed);
        }

        // Test 註解
        [TestMethod()]
        public void PointerReleasedTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);
            model._mouse = new DrawState(model._shapes);

            presentationModel.PointerPressed(10, 10);
            presentationModel.PointerMoved(20, 20);
            presentationModel.PointerReleased();

            Assert.IsFalse(presentationModel._model.IsPressed);
            Assert.IsTrue(presentationModel._model._mouse is PointState);
        }

        // Test 註解
        [TestMethod()]
        public void PointerMovedTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);
            model._mouse = new DrawState(model._shapes);

            presentationModel.PointerPressed(10, 10);
            presentationModel.PointerMoved(20, 20);

            Assert.IsTrue(presentationModel._model.IsPressed);
            Assert.IsNotNull(presentationModel._model._mouse);
        }

        // Test 註解
        [TestMethod()]
        public void ClearShapesTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(CIRCLE);
            presentationModel.CreateShape(RECTANGLE);
            presentationModel.ClearShapes();


            PrivateObject privateObject = new PrivateObject(presentationModel._model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;
            Assert.IsFalse(presentationModel._model.IsPressed);
            Assert.AreEqual(0, shapeList.Count);
        }

        // Test 註解
        [TestMethod()]
        public void DrawPannelWithPointStateNotSelectTest()
        {
            var mockGraphics = new Mock<FormsGraphicsAdaptor>();
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(RECTANGLE);
            presentationModel.CreateShape(CIRCLE);
            presentationModel._model._mouse = new PointState(presentationModel._model._shapes);
            presentationModel._model._shapes.SelectedIndex = -1;
            presentationModel._model._shapes.IsSelected = false;

            // 模擬 FormsGraphicsAdaptor 的行為
            mockGraphics.Setup(x => x.DrawLine(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();

            presentationModel.DrawPannel(mockGraphics.Object, 1);

            // 驗證繪圖方法是否被呼叫
            mockGraphics.Verify(g => g.DrawLine(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Never);
        }

        // Test 註解
        [TestMethod()]
        public void DrawPannelWithPointStateHasSelectTest()
        {
            var mockGraphics = new Mock<FormsGraphicsAdaptor>();
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(RECTANGLE);
            presentationModel.CreateShape(CIRCLE);
            presentationModel._model._mouse = new PointState(presentationModel._model._shapes);
            presentationModel._model._shapes.SelectedIndex = 1;
            presentationModel._model._shapes.IsSelected = true;

            // 模擬 FormsGraphicsAdaptor 的行為
            mockGraphics.Setup(x => x.DrawLine(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();

            presentationModel.DrawPannel(mockGraphics.Object, 1);

            // 驗證繪圖方法是否被呼叫
            mockGraphics.Verify(g => g.DrawLine(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawPannelWithDrawStateTest()
        {
            var mockGraphics = new Mock<FormsGraphicsAdaptor>();
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(RECTANGLE);
            presentationModel.CreateShape(CIRCLE);
            presentationModel._model._mouse = new DrawState(presentationModel._model._shapes);

            // 模擬 FormsGraphicsAdaptor 的行為
            mockGraphics.Setup(x => x.DrawLine(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawSelect(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();

            presentationModel.DrawPannel(mockGraphics.Object, 1);

            // 驗證繪圖方法是否被呼叫
            mockGraphics.Verify(g => g.DrawLine(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void DrawButtonTest()
        {
            var mockGraphics = new Mock<FormsGraphicsAdaptor>();
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(RECTANGLE);
            presentationModel.CreateShape(CIRCLE);

            // 模擬 FormsGraphicsAdaptor 的行為
            mockGraphics.Setup(x => x.DrawButtonLine(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawButtonRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();
            mockGraphics.Setup(x => x.DrawButtonCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1)).Verifiable();

            presentationModel.DrawButton(mockGraphics.Object, 1);

            // 驗證繪圖方法是否被呼叫
            mockGraphics.Verify(g => g.DrawButtonLine(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawButtonRectangle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
            mockGraphics.Verify(g => g.DrawButtonCircle(It.IsAny<Point>(), It.IsAny<Point>(), 1), Times.Once);
        }

        // Test 註解
        [TestMethod()]
        public void GetButtonCheckedCursorsTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CheckCircle();

            Cursor cursor = presentationModel.GetCursors();
            Assert.AreEqual(Cursors.Cross, cursor);
        }

        // Test 註解
        [TestMethod()]
        public void GetSizeCursorsTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CheckArrow();
            model.IsShapeSizable = true;

            Cursor cursor = presentationModel.GetCursors();
            Assert.AreEqual(Cursors.SizeNWSE, cursor);
        }

        // Test 註解
        [TestMethod()]
        public void GetArrowCheckedCursorsTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CheckArrow();

            Cursor cursor = presentationModel.GetCursors();
            Assert.AreEqual(Cursors.Arrow, cursor);
        }

        // Test 註解
        [TestMethod()]
        public void DeleteHasSelectedShapeTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(CIRCLE);
            presentationModel.CreateShape(RECTANGLE);

            presentationModel._model._shapes.IsSelected = true;
            presentationModel._model._shapes.SelectedIndex = 1;

            presentationModel.DeleteSelectedShape();

            PrivateObject privateObject = new PrivateObject(presentationModel._model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(2, shapeList.Count);
            Assert.IsTrue(shapeList[0] is Line);
            Assert.IsTrue(shapeList[1] is Rectangle);
            Assert.IsFalse(presentationModel._model._shapes.IsSelected);
        }

        // Test 註解
        [TestMethod()]
        public void DeleteHasNotSelectedShapeTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            presentationModel.CreateShape(LINE);
            presentationModel.CreateShape(CIRCLE);
            presentationModel.CreateShape(RECTANGLE);

            presentationModel._model._shapes.IsSelected = false;
            presentationModel._model._shapes.SelectedIndex = -1;

            presentationModel.DeleteSelectedShape();

            PrivateObject privateObject = new PrivateObject(presentationModel._model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(3, shapeList.Count);
            Assert.IsTrue(shapeList[0] is Line);
            Assert.IsTrue(shapeList[1] is Circle);
            Assert.IsTrue(shapeList[2] is Rectangle);
            Assert.IsFalse(presentationModel._model._shapes.IsSelected);
        }

        // Test 註解
        [TestMethod()]
        public void PresentationPannelChangedTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            var mockEventHandler = new Mock<PowerPointModel.PannelChangedEventHandler>();

            presentationModel.PresentationPannelChanged += mockEventHandler.Object;
            presentationModel.PresentationPannelChanged -= mockEventHandler.Object;

            var eventInfo = presentationModel.GetType().GetEvent("PresentationPannelChanged");
            Assert.IsNotNull(eventInfo, "Event not found");
        }

        // Test 註解
        [TestMethod()]
        public void PresentationButtonChangedTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);

            var mockEventHandler = new Mock<PowerPointModel.ButtonChangedEventHandler>();

            presentationModel.PresentationButtonChanged += mockEventHandler.Object;
            presentationModel.PresentationButtonChanged -= mockEventHandler.Object;

            var eventInfo = presentationModel.GetType().GetEvent("PresentationButtonChanged");
            Assert.IsNotNull(eventInfo, "Event not found");
        }

        // Test 註解
        [TestMethod()]
        public void NotifyIsNullTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel obj = new PresentationModel(model);

            bool eventRaised = false;

            obj.NotifyProperty("SomeProperty");

            Assert.IsFalse(eventRaised, "PropertyChanged event should have been raised");
        }

        // Test 註解
        [TestMethod()]
        public void NotifyNotNullTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel obj = new PresentationModel(model);

            bool eventRaised = false;
            obj.PropertyChanged += (sender, args) => eventRaised = true;

            obj.NotifyProperty("SomeProperty");

            Assert.IsTrue(eventRaised, "PropertyChanged event should have been raised");
        }

        // Test 註解
        [TestMethod()]
        public void IsRedoEnabledTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);
            CommandManager commandManager = new CommandManager();

            commandManager.Execute(
                new AddCommand(model, "線")
            );

            Assert.IsFalse(presentationModel.IsRedoEnabled);
        }

        // Test 註解
        [TestMethod()]
        public void IsUndoEnabledTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);
            CommandManager commandManager = new CommandManager();

            commandManager.Execute(
                new AddCommand(model, "線")
            );

            Assert.IsFalse(presentationModel.IsUndoEnabled);
        }

        // Test 註解
        [TestMethod()]
        public void UndoTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);
            presentationModel.CreateShape("線");
            presentationModel.Undo();

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(0, shapeList.Count);
        }

        // Test 註解
        [TestMethod()]
        public void RedoTest()
        {
            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);
            presentationModel.CreateShape("線");
            presentationModel.Undo();
            presentationModel.Redo();

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapeList = privateObject.GetField("_shapes") as List<Shape>;

            Assert.AreEqual(1, shapeList.Count);
        }
    }
}*/