using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using WindowsInput;
using OpenQA.Selenium.Interactions;
using PointerInputDevice = OpenQA.Selenium.Interactions.PointerInputDevice;
using System.Runtime.InteropServices;
using Keys = System.Windows.Forms.Keys;

namespace Power_PointTests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        [DllImport("user32.dll", SetLastError = true)]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        // 滑鼠事件
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MOVE = 0x0001;

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            if (_driver.WindowHandles.Count > 0)
            {
                SwitchTo(_root);
                _driver.CloseApp();
                _driver.Dispose();
            }
            
        }

        // 切換到對應的視窗
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // 使當前執行緒暫停指定時間
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // 執行按鈕點擊操作
        public void ClickElementByName(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // 執行按鈕點擊操作
        public void ClickElementById(string id)
        {
            _driver.FindElementByAccessibilityId(id).Click();
        }

        // 模擬使用者點擊該標籤控制項的操作
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // 觸發關閉當前應用程序窗口的動作
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        public void ClickDelete()
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
        }

        // 找到名稱為 "確定" 的元素，然後進行點擊
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // 點擊資料表中的某個儲存格，以觸發相應的事件或驗證應用程式的行為
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }

        // assert 特定 UI 元素的啟用狀態是否符合預期
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // assert 特定 UI 元素的是否 CHECKED
        public void AssertToolStripButtonChecked(string name, string state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.GetAttribute("LegacyState"));
        }

        // assert 特定 UI 元素的文本內容是否符合預期
        public void AssertText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // assert 特定 DataGridView 控制項的特定資料列是否包含預期的數據
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, List<string> data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
            }
        }

        // assert 特定 DataGridView 控制項的資料列數量是否符合預期
        public void AssertDataGridViewRowCountBy(string name, int count)
        {
            Assert.AreEqual(count.ToString(), FindElementById(name).GetAttribute("Grid.RowCount"));
        }

        // 模擬滑鼠按下
        public void MouseDown()
        {
            Actions actions = new Actions(_driver);
            actions.ClickAndHold();
        }

        // 模擬滑鼠移動
        public void MouseMove(string element, int x, int y)
        {
            Actions actions = new Actions(_driver);
            WindowsElement background = _driver.FindElementByAccessibilityId(element);
            actions.MoveToElement(background, x * 3 / 2, y * 3 / 2).Perform();
        }

        // 模擬滑鼠放開
        public void MouseUp()
        {
            Actions actions = new Actions(_driver);
            actions.Release();
        }

        // 模擬滑鼠點擊
        public void MouseClick(int x, int y)
        {
            Actions actions = new Actions(_driver);

            WindowsElement element = _driver.FindElementByAccessibilityId("_canvas");
            actions.ClickAndHold()
                .MoveToElement(element, x * 3 / 2, y * 3 / 2)
                .Release()
                .Perform();
        }

        // 在畫布按壓拖移放開滑鼠
        public void Draw(int x, int y)
        {
            Actions actions = new Actions(_driver);

            WindowsElement element = _driver.FindElementByAccessibilityId("_canvas");
            actions.ClickAndHold()
                .MoveToElement(element, x * 3 / 2, y * 3 / 2)
                .Release()
                .Perform();
        }

        // Name 回傳元件
        public WindowsElement FindElementByName(string name)
        {
            return _driver.FindElementByName(name);
        }

        // ID 回傳元件
        public WindowsElement FindElementById(string id)
        {
            return _driver.FindElementByAccessibilityId(id);
        }

        public void DeleteDataGridViewData(string name, int index)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);

            // 假設你要點擊第一行第一列的按鈕
            int rowIndex = 0;
            int columnIndex = 0;

            // 找到指定儲存格
            var cell = dataGridView.FindElementByName($"資料列 {index} 資料格 0");

            // 在儲存格中找到按鈕
            var button = cell.FindElementByTagName("Button"); // 使用實際的按鈕標籤名稱

            // 點擊按鈕
            button.Click();
        }

        public void SetWindowsSize(int x, int y)
        {
            WindowsElement windowElement = _driver.FindElementByAccessibilityId("Form1");
            int WindowsX = windowElement.Location.X + windowElement.Size.Width;
            int WindowsY = windowElement.Location.Y + windowElement.Size.Height;

            // 創建 Actions 實例
            Actions actions = new Actions(_driver);

            // 移動滑鼠到右下角
            actions.MoveToElement(windowElement, WindowsX, WindowsY)
                .ClickAndHold()
                .MoveToElement(windowElement, x, y)
                .Release()
                .Perform();
        }

        public void AssertWindowsSize()
        {
            WindowsElement _canvas = _driver.FindElementByAccessibilityId("_canvas");

            Assert.AreEqual(16 / 9, _canvas.Size.Width / _canvas.Size.Height);

        }
    }
}
