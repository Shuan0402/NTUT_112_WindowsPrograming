using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Power_Point
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PowerPointModel model = new PowerPointModel();
            PresentationModel presentationModel = new PresentationModel(model);
            Application.Run(new Form1(presentationModel));
        }
    }
}
