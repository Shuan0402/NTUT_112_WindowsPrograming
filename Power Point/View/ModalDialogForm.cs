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

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allTextBoxesAreNumbers = AllTextBoxesAreNumbers();

            _okButton.Enabled = allTextBoxesAreNumbers;
        }

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

        private void _leftTopPointLabelX_Click(object sender, EventArgs e)
        {

        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void _leftTopTextBoxX_TextChanged(object sender, EventArgs e)
        {

        }

        private void _leftTopTextBoxY_TextChanged(object sender, EventArgs e)
        {

        }

        private void _rightBottomTextBoxX_TextChanged(object sender, EventArgs e)
        {

        }

        private void _rightBottomTextBoxY_TextChanged(object sender, EventArgs e)
        {

        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
