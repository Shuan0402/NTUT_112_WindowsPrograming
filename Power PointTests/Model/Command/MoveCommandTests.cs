using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Power_Point.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        // Test 註解
        [TestMethod()]
        public void MoveCommandTest()
        {
            PowerPointModel model = new PowerPointModel();

            Point firstPoint = new Point(10, 20);
            Point endPoint = new Point(30, 40);

            MoveCommand moveCommand = new MoveCommand(model, firstPoint, endPoint, 0);

            Assert.IsNotNull(moveCommand);

            PrivateObject privateObject = new PrivateObject(moveCommand);
            PowerPointModel drawModel = privateObject.GetField("model") as PowerPointModel;
            Point oriPoint = privateObject.GetField("oriPoint") as Point;
            Point curPoint = privateObject.GetField("curPoint") as Point;

            Assert.AreEqual(model, drawModel);
            Assert.AreEqual(firstPoint, oriPoint);
            Assert.AreEqual(endPoint, curPoint);
        }

        // Test 註解
        [TestMethod()]
        public void ExecuteTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.CreateShape("線");
            Point originalPoint = new Point(10, 20);
            Point currentPoint = new Point(30, 40);
            int index = 0;

            MoveCommand moveCommand = new MoveCommand(model, originalPoint, currentPoint, index);

            string info = model._shapes.GetShapeData()[0].Info;
            string pattern = @"\((\w+), (\w+)\), \((\w+), (\w+)\)";

            Match match = System.Text.RegularExpressions.Regex.Match(info, pattern);
            int a = int.Parse(match.Groups[1].Value);
            int b = int.Parse(match.Groups[2].Value);

            Point oriFirstPoint = new Point(a, b);

            model.IsMoved = true;
            moveCommand.Execute();

            info = model._shapes.GetShapeData()[0].Info;
            match = System.Text.RegularExpressions.Regex.Match(info, pattern);
            int c = int.Parse(match.Groups[1].Value);
            int d = int.Parse(match.Groups[2].Value);

            Point curFirstPoint = new Point(c, d);

            Assert.AreEqual(20, curFirstPoint.X - oriFirstPoint.X);
            Assert.AreEqual(20, curFirstPoint.Y - oriFirstPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void UnExecuteMovedTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.CreateShape("線");
            Point originalPoint = new Point(10, 20);
            Point currentPoint = new Point(30, 40);
            int index = 0;

            MoveCommand moveCommand = new MoveCommand(model, originalPoint, currentPoint, index);

            string info = model._shapes.GetShapeData()[0].Info;
            string pattern = @"\((\w+), (\w+)\), \((\w+), (\w+)\)";

            Match match = System.Text.RegularExpressions.Regex.Match(info, pattern);
            int a = int.Parse(match.Groups[1].Value);
            int b = int.Parse(match.Groups[2].Value);

            Point oriFirstPoint = new Point(a, b);

            
            moveCommand.Execute();
            model.IsMoved = true;
            moveCommand.Revoke();

            info = model._shapes.GetShapeData()[0].Info;
            match = System.Text.RegularExpressions.Regex.Match(info, pattern);
            int c = int.Parse(match.Groups[1].Value);
            int d = int.Parse(match.Groups[2].Value);

            Point curFirstPoint = new Point(c, d);

            Assert.AreEqual(-20, curFirstPoint.X - oriFirstPoint.X);
            Assert.AreEqual(-20, curFirstPoint.Y - oriFirstPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void UnExecuteNotMovedTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.CreateShape("線");
            Point originalPoint = new Point(10, 20);
            Point currentPoint = new Point(30, 40);
            int index = 0;

            MoveCommand moveCommand = new MoveCommand(model, originalPoint, currentPoint, index);

            moveCommand.Execute();
            model.IsMoved = false;
            moveCommand.Revoke();

            Assert.IsTrue(model.IsMoved);
        }
    }
}