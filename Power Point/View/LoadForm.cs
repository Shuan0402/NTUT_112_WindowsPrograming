using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Power_Point
{
    public partial class LoadForm : Form
    {
        readonly Form1 _form;
        public LoadForm(Form1 form)
        {
            InitializeComponent();
            _form = form;
        }

        // test
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }

        // test
        private void ClickLoadButton(object sender, EventArgs e)
        {
            _form.LoadData();
            this.Close();
        }
    }
}
