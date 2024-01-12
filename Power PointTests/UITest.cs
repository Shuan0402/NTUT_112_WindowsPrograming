using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace Power_PointTests
{
    [TestClass()]
    public class UITest
    {
        private Robot _robot;
        private const string APP_NAME = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

        private string targetAppPath;
        private const string MENU_FORM = "MenuForm";
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";
        const string CHECKED = "1048724";



        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "Power Point";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "Power Point.exe");
            _robot = new Robot(targetAppPath, MENU_FORM);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        //
        // Draw
        //
        // Line
        [TestMethod]
        public void TestDrawLine()
        {
            _robot.ClickElementByName("Line");
            _robot.AssertToolStripButtonChecked("Line", CHECKED);
            _robot.MouseMove("_canvas", 50, 50);
            _robot.Draw(100, 200);
            List<string> lineData = new List<string>();
            lineData.Add("刪除");
            lineData.Add("線");
            lineData.Add("(50, 50), (100, 200)");
            _robot.AssertDataGridViewRowDataBy("_dataGridShapeData", 0, lineData);
        }

        // Rectangle
        [TestMethod]
        public void TestDrawRectangle()
        {
            _robot.ClickElementByName("Rectangle");
            _robot.AssertToolStripButtonChecked("Rectangle", CHECKED);
            _robot.MouseMove("_canvas", 50, 50);
            _robot.Draw(100, 200);
            List<string> rectangleData = new List<string>();
            rectangleData.Add("刪除");
            rectangleData.Add("矩形");
            rectangleData.Add("(50, 50), (100, 200)");
            _robot.AssertDataGridViewRowDataBy("_dataGridShapeData", 0, rectangleData);
        }

        // Circle
        [TestMethod]
        public void TestDrawCircle()
        {
            _robot.ClickElementByName("Circle");
            _robot.AssertToolStripButtonChecked("Circle", CHECKED);
            _robot.MouseMove("_canvas", 50, 50);
            _robot.Draw(100, 200);
            List<string> circleData = new List<string>();
            circleData.Add("刪除");
            circleData.Add("圓形");
            circleData.Add("(50, 50), (100, 200)");
            _robot.AssertDataGridViewRowDataBy("_dataGridShapeData", 0, circleData);
        }

        //
        // RedoUndo
        //
        // Draw
        [TestMethod]
        public void TestRedoUndoDraw()
        {
            _robot.ClickElementByName("Line");
            _robot.MouseMove("_canvas", 50, 50);
            _robot.Draw(100, 200);
            _robot.Sleep(1);
            _robot.ClickElementByName("Undo");
            _robot.AssertDataGridViewRowCountBy("_dataGridShapeData", 0);
            _robot.Sleep(1);
            _robot.ClickElementByName("Redo");
            _robot.AssertDataGridViewRowCountBy("_dataGridShapeData", 1);
        }

        // Create
        [TestMethod]
        public void TestRedoUndoCreate()
        {
        }

        //
        // DataGridView
        //
        // Line
        [TestMethod]
        public void TestAddLineDataGridView()
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

            _robot.ClickElementById("_comboBoxShape");
            _robot.ClickElementByName("線");
            _robot.ClickElementByName("新增");
            _robot.FindElementById("_leftTopTextBoxX").SendKeys(OpenQA.Selenium.Keys.NumberPad1);
            _robot.FindElementById("_leftTopTextBoxY").SendKeys(OpenQA.Selenium.Keys.NumberPad2);
            _robot.FindElementById("_rightBottomTextBoxX").SendKeys(OpenQA.Selenium.Keys.NumberPad8);
            _robot.FindElementById("_rightBottomTextBoxY").SendKeys(OpenQA.Selenium.Keys.NumberPad9);
            _robot.ClickElementByName("OK");

            List<string> data = new List<string>();
            data.Add("刪除");
            data.Add("線");
            data.Add("(1, 2), (8, 9)");
            _robot.AssertDataGridViewRowDataBy("_dataGridShapeData", 0, data);

            _robot.ClickElementByName("刪除 資料列 0");
            _robot.AssertDataGridViewRowCountBy("_dataGridShapeData", 0);
        }

        // Rectangle
        [TestMethod]
        public void TestAddRectangleDataGridView()
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

            _robot.ClickElementById("_comboBoxShape");
            _robot.ClickElementByName("矩形");
            _robot.ClickElementByName("新增");
            _robot.FindElementById("_leftTopTextBoxX").SendKeys(OpenQA.Selenium.Keys.NumberPad1);
            _robot.FindElementById("_leftTopTextBoxY").SendKeys(OpenQA.Selenium.Keys.NumberPad2);
            _robot.FindElementById("_rightBottomTextBoxX").SendKeys(OpenQA.Selenium.Keys.NumberPad8);
            _robot.FindElementById("_rightBottomTextBoxY").SendKeys(OpenQA.Selenium.Keys.NumberPad9);
            _robot.ClickElementByName("OK");

            List<string> data = new List<string>();
            data.Add("刪除");
            data.Add("矩形");
            data.Add("(1, 2), (8, 9)");
            _robot.AssertDataGridViewRowDataBy("_dataGridShapeData", 0, data);

            _robot.ClickElementByName("刪除 資料列 0");
            _robot.AssertDataGridViewRowCountBy("_dataGridShapeData", 0);
        }

        // Circle
        [TestMethod]
        public void TestAddDataGridView()
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

            _robot.ClickElementById("_comboBoxShape");
            _robot.ClickElementByName("圓形");
            _robot.ClickElementByName("新增");
            _robot.FindElementById("_leftTopTextBoxX").SendKeys(OpenQA.Selenium.Keys.NumberPad1);
            _robot.FindElementById("_leftTopTextBoxY").SendKeys(OpenQA.Selenium.Keys.NumberPad2);
            _robot.FindElementById("_rightBottomTextBoxX").SendKeys(OpenQA.Selenium.Keys.NumberPad8);
            _robot.FindElementById("_rightBottomTextBoxY").SendKeys(OpenQA.Selenium.Keys.NumberPad9);
            _robot.ClickElementByName("OK");

            List<string> data = new List<string>();
            data.Add("刪除");
            data.Add("圓形");
            data.Add("(1, 2), (8, 9)");
            _robot.AssertDataGridViewRowDataBy("_dataGridShapeData", 0, data);

            _robot.ClickElementByName("刪除 資料列 0");
            _robot.AssertDataGridViewRowCountBy("_dataGridShapeData", 0);
        }


        // slide
        [TestMethod]
        public void TestAddSlide()
        {
            _robot.ClickElementByName("NewSlide");
            Assert.IsNotNull(_robot.FindElementById("_slideButton1"));
            _robot.ClickElementById("_slideButton1");
            _robot.ClickDelete();
            _robot.Sleep(3);
        }

        // move
        [TestMethod]
        public void TestMoveRectangle()
        {
            _robot.ClickElementByName("Rectangle");
            _robot.AssertToolStripButtonChecked("Rectangle", CHECKED);
            _robot.MouseMove("_canvas", 50, 50);
            _robot.Draw(100, 200);
            List<string> rectangleData = new List<string>();
            _robot.MouseMove("_canvas", 60, 90);
            _robot.Draw(20, 30);

            rectangleData.Add("刪除");
            rectangleData.Add("矩形");
            rectangleData.Add("(10, -10), (60, 140)");

            _robot.Sleep(3);

            _robot.AssertDataGridViewRowDataBy("_dataGridShapeData", 0, rectangleData);
        }

        [TestMethod]
        public void TestMoveCircle()
        {
            _robot.ClickElementByName("Circle");
            _robot.AssertToolStripButtonChecked("Circle", CHECKED);
            _robot.MouseMove("_canvas", 50, 50);
            _robot.Draw(100, 200);
            List<string> data = new List<string>();
            _robot.MouseMove("_canvas", 60, 90);
            _robot.Draw(20, 30);

            data.Add("刪除");
            data.Add("圓形");
            data.Add("(10, -10), (60, 140)");

            _robot.Sleep(3);

            _robot.AssertDataGridViewRowDataBy("_dataGridShapeData", 0, data);
        }

        [TestMethod]
        public void TestMoveLine()
        {
            _robot.ClickElementByName("Line");
            _robot.AssertToolStripButtonChecked("Line", CHECKED);
            _robot.MouseMove("_canvas", 50, 50);
            _robot.Draw(100, 200);
            List<string> data = new List<string>();
            _robot.MouseMove("_canvas", 60, 90);
            _robot.Draw(20, 30);

            data.Add("刪除");
            data.Add("線");
            data.Add("(10, -10), (60, 140)");

            _robot.Sleep(3);

            _robot.AssertDataGridViewRowDataBy("_dataGridShapeData", 0, data);
        }

        [TestMethod]
        public void TestSetWindowsSize()
        {
            _robot.SetWindowsSize(500, 500);
            _robot.Sleep(3);
            _robot.AssertWindowsSize();
        }
    }
}
