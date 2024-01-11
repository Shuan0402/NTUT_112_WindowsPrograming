using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Power_PointTests
{
    [TestClass()]
    public class UITest
    {
        private Robot _robot;
        private const string APP_NAME = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

        private string targetAppPath;
        private const string MENU_FORM = "MenuForm";


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

        [TestMethod]
        public void TestTest()
        {

        }
    }
}
