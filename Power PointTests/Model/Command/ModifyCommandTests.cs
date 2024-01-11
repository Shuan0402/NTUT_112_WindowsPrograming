using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*
namespace Power_Point.Tests
{
    [TestClass()]
    public class ModifyCommandTests
    {
        // Test 註解
        [TestMethod()]
        public void ModifyCommandTest()
        {
            PowerPointModel model = new PowerPointModel();
            Point firstPoint = new Point(10, 20);
            Point endPoint = new Point(30, 40);

            ModifyCommand modifyCommand = new ModifyCommand(model, firstPoint, endPoint, "線");

            Assert.IsNotNull(modifyCommand);

            PrivateObject privateObject = new PrivateObject(modifyCommand);
            PowerPointModel modifyModel = privateObject.GetField("model") as PowerPointModel;
            string shapeType = privateObject.GetField("shapeType") as string;

            Assert.AreEqual(model, modifyModel);
            Assert.AreEqual(shapeType, shapeType);
            Assert.AreEqual(firstPoint.X, modifyCommand.FirstPointX);
            Assert.AreEqual(firstPoint.Y, modifyCommand.FirstPointY);
            Assert.AreEqual(endPoint.X, modifyCommand.EndPointX);
            Assert.AreEqual(endPoint.Y, modifyCommand.EndPointY);

            Assert.AreEqual(model._shapes.SelectedIndex, modifyCommand.Index);
        }

        // Test 註解
        [TestMethod()]
        public void ExecuteTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.CreateShape("線");
            string info = model._shapes.GetShapeData()[0].Info;
            string pattern = @"\((\w+), (\w+)\), \((\w+), (\w+)\)";

            Match match = System.Text.RegularExpressions.Regex.Match(info, pattern);
            int a = int.Parse(match.Groups[3].Value);
            int b = int.Parse(match.Groups[4].Value);

            Point firstPoint = new Point(a, b);
            Point endPoint = new Point(a + 20, b + 30);

            ModifyCommand modifyCommand = new ModifyCommand(model, firstPoint, endPoint, "線");

            model.IsPressed = true;
            model._shapes.IsSelected = true;
            model._shapes.SelectedIndex = 0;
            modifyCommand.Execute();

            info = model._shapes.GetShapeData()[0].Info;
            match = System.Text.RegularExpressions.Regex.Match(info, pattern);
            int c = int.Parse(match.Groups[3].Value);
            int d = int.Parse(match.Groups[4].Value);

            Point curEndPoint = new Point(c, d);

            Assert.AreEqual(0, curEndPoint.X - firstPoint.X);
            Assert.AreEqual(0, curEndPoint.Y - firstPoint.Y);
        }

        // Test 註解
        [TestMethod()]
        public void UnExecuteTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.CreateShape("線");
            string info = model._shapes.GetShapeData()[0].Info;
            string pattern = @"\((\w+), (\w+)\), \((\w+), (\w+)\)";

            Match match = System.Text.RegularExpressions.Regex.Match(info, pattern);
            int a = int.Parse(match.Groups[3].Value);
            int b = int.Parse(match.Groups[4].Value);

            Point firstPoint = new Point(a, b);
            Point endPoint = new Point(a + 20, b + 30);

            ModifyCommand modifyCommand = new ModifyCommand(model, firstPoint, endPoint, "線");

            model.IsPressed = true;
            model._shapes.IsSelected = true;
            model._shapes.SelectedIndex = 0;
            modifyCommand.Execute();
            modifyCommand.Revoke();

            info = model._shapes.GetShapeData()[0].Info;
            match = System.Text.RegularExpressions.Regex.Match(info, pattern);
            int c = int.Parse(match.Groups[3].Value);
            int d = int.Parse(match.Groups[4].Value);

            Point curEndPoint = new Point(c, d);

            Assert.AreEqual(0, curEndPoint.X - firstPoint.X);
            Assert.AreEqual(0, curEndPoint.Y - firstPoint.Y);
        }
    }
}*/