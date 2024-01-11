using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class DrawCommandTests
    {
        // Test 註解
        [TestMethod()]
        public void DrawCommandTest()
        {
            PowerPointModel model = new PowerPointModel();
            Point firstPoint = new Point(10, 20);
            Point endPoint = new Point(30, 40);

            DrawCommand drawCommand = new DrawCommand(model, firstPoint, endPoint, "線");

            Assert.IsNotNull(drawCommand);

            PrivateObject privateObject = new PrivateObject(drawCommand);
            PowerPointModel drawModel = privateObject.GetField("model") as PowerPointModel;
            string shapeType = privateObject.GetField("shapeType") as string;

            Assert.AreEqual(model, drawModel);
            Assert.AreEqual(shapeType, shapeType);
            Assert.AreEqual(firstPoint.X, drawCommand.FirstPointX);
            Assert.AreEqual(firstPoint.Y, drawCommand.FirstPointY);
            Assert.AreEqual(endPoint.X, drawCommand.EndPointX);
            Assert.AreEqual(endPoint.Y, drawCommand.EndPointY);
        }

        // Test 註解
        [TestMethod()]
        public void UnExecuteTest()
        {
            PowerPointModel model = new PowerPointModel();
            Point firstPoint = new Point(10, 20);
            Point endPoint = new Point(30, 40);

            DrawCommand drawCommand = new DrawCommand(model, firstPoint, endPoint, "線");

            model.IsPressed = true;
            drawCommand.Execute();
            Assert.AreEqual(1, model._shapes.GetShapesSize);
            drawCommand.Revoke();
            Assert.AreEqual(0, model._shapes.GetShapesSize);

        }
    }
}*/