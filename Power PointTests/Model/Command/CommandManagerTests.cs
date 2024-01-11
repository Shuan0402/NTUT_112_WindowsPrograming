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
    public class CommandManagerTests
    {
        // Test 註解
        [TestMethod()]
        public void UndoTest()
        {
            PowerPointModel model = new PowerPointModel();
            CommandManager commandManager = new CommandManager();

            commandManager.Execute(
                new AddCommand(model, "線")
            );

            commandManager.Undo();

            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
        }

        // Test 註解
        [TestMethod()]
        public void RedoTest()
        {
            PowerPointModel model = new PowerPointModel();
            CommandManager commandManager = new CommandManager();

            commandManager.Execute(
                new AddCommand(model, "線")
            );

            commandManager.Undo();
            commandManager.Redo();

            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
        }
    }
}*/