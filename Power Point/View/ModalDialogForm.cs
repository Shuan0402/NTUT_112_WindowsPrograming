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
    public partial class ModalDialogForm : Form
    {
        private double _leftTopX;
        private double _leftTopY;
        private double _rightBottomX;
        private double _rightBottomY;

        public Point LeftTopPoint
        {
            get
            {
                return new Point(_leftTopX, _leftTopY);
            }
        }

        public Point RightBottomPoint
        {
            get
            {
                return new Point(_rightBottomX, _rightBottomY);
            }
        }

        public ModalDialogForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            _okButton.Enabled = false;

            _leftTopTextBoxX.TextChanged += TextBox_TextChanged;
            _leftTopTextBoxY.TextChanged += TextBox_TextChanged;
            _rightBottomTextBoxX.TextChanged += TextBox_TextChanged;
            _rightBottomTextBoxY.TextChanged += TextBox_TextChanged;
        }

        // test
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allTextBoxesAreNumbers = AllTextBoxesAreNumbers();

            _okButton.Enabled = allTextBoxesAreNumbers;
        }

        // test
        private bool AllTextBoxesAreNumbers()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    if (!double.TryParse(textBox.Text, out double value))
                    {
                        return false;
                    }

                    SetBoxNumber(textBox.Name, value);
                }
            }

            if(_leftTopX < _rightBottomX && _leftTopY < _rightBottomY)
            {
                return true;
            }
            return false;
        }

        // test
        private void SetBoxNumber(string name, double value)
        {
            switch (name)
            {
                case "_leftTopTextBoxX":
                    _leftTopX = value;
                    break;
                case "_leftTopTextBoxY":
                    _leftTopY = value;
                    break;
                case "_rightBottomTextBoxX":
                    _rightBottomX = value;
                    break;
                case "_rightBottomTextBoxY":
                    _rightBottomY = value;
                    break;
            }
        }

        // test
        private void LeftTopPointLabelX_Click(object sender, EventArgs e)
        {

        }

        // test
        private void ClickOkButton(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // test
        private void ChangrLeftTopTextBoxX_Text(object sender, EventArgs e)
        {

        }

        // test
        private void ChangeLeftTopTextBoxY_Text(object sender, EventArgs e)
        {

        }

        // test
        private void ChangeRightBottomTextBoxX_Text(object sender, EventArgs e)
        {

        }

        // test
        private void ChangeRightBottomTextBoxY_Text(object sender, EventArgs e)
        {

        }

         //test
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
