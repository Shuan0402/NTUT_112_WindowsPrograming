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
    public partial class SaveForm : Form
    {
        public bool IsSaved
        {
            get;
            set;
        }

        Form1 _form1;

        public SaveForm(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void _saveButton_Click(object sender, EventArgs e)
        {
            _saveButton.Enabled = false;

            await Task.Delay(10000);
            _form1.SaveData();

            _saveButton.Enabled = true;
        }
    }
}
