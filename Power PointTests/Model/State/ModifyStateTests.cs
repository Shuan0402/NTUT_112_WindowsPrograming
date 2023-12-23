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
    public class ModifyStateTests
    {

        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";

        // Test 註解
        [TestMethod()]
        public void ModifyStateTest()
        {
            Shapes shapes = new Shapes();

            ModifyState modifyState = new ModifyState(shapes);

            PrivateObject privateObject = new PrivateObject(modifyState);
            Shapes stateShapes = privateObject.GetField("_shapes") as Shapes;

            Assert.AreEqual(shapes, stateShapes);
        }

        // Test 註解
        [TestMethod()]
        public void MouseDownTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new ModifyState(model._shapes);

            model.PressPointer(0, 0, "線");

            Assert.IsTrue(model._mouse is ModifyState);
        }

        // Test 註解
        [TestMethod()]
        public void MouseMoveTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new ModifyState(model._shapes);

            model.CreateShape(LINE);
            model.CreateShape(RECTANGLE);
            model.CreateShape(CIRCLE);

            PrivateObject privateObject = new PrivateObject(model._shapes);
            List<Shape> shapes = privateObject.GetField("_shapes") as List<Shape>;

            model._shapes.SelectedIndex = 1;
            model._shapes.IsSelected = true;
            model.IsPressed = true;

            shapes[1].FirstPoint.X = 5;
            shapes[1].EndPoint.X = 0;
            shapes[1].FirstPoint.Y = 5;
            shapes[1].EndPoint.Y = 0;

            model.PressPointer(0, 0, "線");
            model.MovePointer(10, 10);

            Assert.AreEqual(10, shapes[1].FirstPoint.X);
            Assert.AreEqual(10, shapes[1].FirstPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void MouseUpTest()
        {
            PowerPointModel model = new PowerPointModel();
            model._mouse = new ModifyState(model._shapes);

            model.PressPointer(0, 0, "線");
            model.MovePointer(10, 10);
            model.ReleasePointer();

            model._mouse.MouseUp();

            Assert.IsTrue(model._mouse is ModifyState);
        }
    }
}