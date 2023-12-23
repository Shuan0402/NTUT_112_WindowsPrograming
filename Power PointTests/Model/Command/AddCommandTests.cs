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
    public class AddCommandTests
    {
        // Test 註解
        [TestMethod()]
        public void AddLineCommandTest()
        {
            PowerPointModel model = new PowerPointModel();

            AddCommand addCommand = new AddCommand(model, "線");

            PrivateObject privateObject = new PrivateObject(addCommand);
            string shapeType = privateObject.GetField("shapeType") as string;
            PowerPointModel addModel = privateObject.GetField("model") as PowerPointModel;

            Assert.AreEqual("線", shapeType);
            Assert.AreEqual(model, addModel);
        }

        // Test 註解
        [TestMethod()]
        public void UnExecuteTest()
        {
            PowerPointModel model = new PowerPointModel();
            AddCommand addCommand = new AddCommand(model, "矩形");

            addCommand.Execute();
            addCommand.Revoke();


            PrivateObject privateObject = new PrivateObject(addCommand);
            string info = privateObject.GetField("info") as string;

            Assert.IsNotNull(info);
            Assert.AreEqual(0, model._shapes.GetShapesSize);
        }
    }
}