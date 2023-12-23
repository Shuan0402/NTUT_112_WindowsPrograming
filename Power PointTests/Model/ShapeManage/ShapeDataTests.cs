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
    public class ShapeDataTests
    {
        // Test 註解
        [TestMethod()]
        public void ShapeDataTest()
        {
            ShapeData shapeData = new ShapeData("name", "info");

            Assert.AreEqual("name", shapeData.Name);
            Assert.AreEqual("info", shapeData.Info);
        }
    }
}