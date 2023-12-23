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
    public class DeleteCommandTests
    {
        // Test 註解
        [TestMethod()]
        public void DeleteCommandTest()
        {
            PowerPointModel model = new PowerPointModel();

            DeleteCommand deleteCommand = new DeleteCommand(model, 1);

            PrivateObject privateObject = new PrivateObject(deleteCommand);
            PowerPointModel deleteModel = privateObject.GetField("model") as PowerPointModel;

            Assert.AreEqual(1, deleteCommand.Index);
            Assert.AreEqual(model, deleteModel);
        }

        // Test 註解
        [TestMethod()]
        public void UnExecuteTest()
        {
            PowerPointModel model = new PowerPointModel();
            model.CreateShape("線");
            model.CreateShape("線");
            int indexToDelete = 0;
            DeleteCommand deleteCommand = new DeleteCommand(model, indexToDelete);

            deleteCommand.Execute();

            ShapeData deletedShapeInfo = model._shapes.GetShapeData()[indexToDelete];

            deleteCommand.Revoke();

            Assert.AreEqual(2, model._shapes.GetShapesSize);
            Assert.AreEqual(deletedShapeInfo.Name, model._shapes.GetShapeData()[0].Name);
            Assert.AreEqual(deletedShapeInfo.Info, model._shapes.GetShapeData()[0].Info);

        }
    }
}