
namespace Power_Point
{
    partial class ModalDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._leftTopPointLabelX = new System.Windows.Forms.Label();
            this._leftTopPointLabelY = new System.Windows.Forms.Label();
            this._rightBottomPointLabelX = new System.Windows.Forms.Label();
            this._rightBottomPointLabelY = new System.Windows.Forms.Label();
            this._leftTopTextBoxX = new System.Windows.Forms.TextBox();
            this._leftTopTextBoxY = new System.Windows.Forms.TextBox();
            this._rightBottomTextBoxX = new System.Windows.Forms.TextBox();
            this._rightBottomTextBoxY = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _leftTopPointLabelX
            // 
            this._leftTopPointLabelX.AutoSize = true;
            this._leftTopPointLabelX.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._leftTopPointLabelX.Location = new System.Drawing.Point(74, 65);
            this._leftTopPointLabelX.Name = "_leftTopPointLabelX";
            this._leftTopPointLabelX.Size = new System.Drawing.Size(116, 23);
            this._leftTopPointLabelX.TabIndex = 0;
            this._leftTopPointLabelX.Text = "左上角座標 X";
            this._leftTopPointLabelX.Click += new System.EventHandler(this._leftTopPointLabelX_Click);
            // 
            // _leftTopPointLabelY
            // 
            this._leftTopPointLabelY.AutoSize = true;
            this._leftTopPointLabelY.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._leftTopPointLabelY.Location = new System.Drawing.Point(277, 65);
            this._leftTopPointLabelY.Name = "_leftTopPointLabelY";
            this._leftTopPointLabelY.Size = new System.Drawing.Size(116, 23);
            this._leftTopPointLabelY.TabIndex = 1;
            this._leftTopPointLabelY.Text = "左上角座標 Y";
            // 
            // _rightBottomPointLabelX
            // 
            this._rightBottomPointLabelX.AutoSize = true;
            this._rightBottomPointLabelX.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._rightBottomPointLabelX.Location = new System.Drawing.Point(74, 159);
            this._rightBottomPointLabelX.Name = "_rightBottomPointLabelX";
            this._rightBottomPointLabelX.Size = new System.Drawing.Size(116, 23);
            this._rightBottomPointLabelX.TabIndex = 2;
            this._rightBottomPointLabelX.Text = "右下角座標 X";
            // 
            // _rightBottomPointLabelY
            // 
            this._rightBottomPointLabelY.AutoSize = true;
            this._rightBottomPointLabelY.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._rightBottomPointLabelY.Location = new System.Drawing.Point(277, 159);
            this._rightBottomPointLabelY.Name = "_rightBottomPointLabelY";
            this._rightBottomPointLabelY.Size = new System.Drawing.Size(116, 23);
            this._rightBottomPointLabelY.TabIndex = 3;
            this._rightBottomPointLabelY.Text = "右下角座標 Y";
            // 
            // _leftTopTextBoxX
            // 
            this._leftTopTextBoxX.Location = new System.Drawing.Point(78, 106);
            this._leftTopTextBoxX.Name = "_leftTopTextBoxX";
            this._leftTopTextBoxX.Size = new System.Drawing.Size(112, 29);
            this._leftTopTextBoxX.TabIndex = 4;
            this._leftTopTextBoxX.TextChanged += new System.EventHandler(this._leftTopTextBoxX_TextChanged);
            // 
            // _leftTopTextBoxY
            // 
            this._leftTopTextBoxY.Location = new System.Drawing.Point(281, 106);
            this._leftTopTextBoxY.Name = "_leftTopTextBoxY";
            this._leftTopTextBoxY.Size = new System.Drawing.Size(112, 29);
            this._leftTopTextBoxY.TabIndex = 5;
            this._leftTopTextBoxY.TextChanged += new System.EventHandler(this._leftTopTextBoxY_TextChanged);
            // 
            // _rightBottomTextBox
            // 
            this._rightBottomTextBoxX.Location = new System.Drawing.Point(78, 200);
            this._rightBottomTextBoxX.Name = "_rightBottomTextBoxX";
            this._rightBottomTextBoxX.Size = new System.Drawing.Size(112, 29);
            this._rightBottomTextBoxX.TabIndex = 6;
            this._rightBottomTextBoxX.TextChanged += new System.EventHandler(this._rightBottomTextBoxX_TextChanged);
            // 
            // _rightBottomTextBoxY
            // 
            this._rightBottomTextBoxY.Location = new System.Drawing.Point(281, 200);
            this._rightBottomTextBoxY.Name = "_rightBottomTextBoxY";
            this._rightBottomTextBoxY.Size = new System.Drawing.Size(112, 29);
            this._rightBottomTextBoxY.TabIndex = 7;
            this._rightBottomTextBoxY.TextChanged += new System.EventHandler(this._rightBottomTextBoxY_TextChanged);
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(78, 268);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(112, 29);
            this._okButton.TabIndex = 8;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(281, 268);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(112, 29);
            this._cancelButton.TabIndex = 9;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 344);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._rightBottomTextBoxY);
            this.Controls.Add(this._rightBottomTextBoxX);
            this.Controls.Add(this._leftTopTextBoxY);
            this.Controls.Add(this._leftTopTextBoxX);
            this.Controls.Add(this._rightBottomPointLabelY);
            this.Controls.Add(this._rightBottomPointLabelX);
            this.Controls.Add(this._leftTopPointLabelY);
            this.Controls.Add(this._leftTopPointLabelX);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _leftTopPointLabelX;
        private System.Windows.Forms.Label _leftTopPointLabelY;
        private System.Windows.Forms.Label _rightBottomPointLabelX;
        private System.Windows.Forms.Label _rightBottomPointLabelY;
        private System.Windows.Forms.TextBox _leftTopTextBoxX;
        private System.Windows.Forms.TextBox _leftTopTextBoxY;
        private System.Windows.Forms.TextBox _rightBottomTextBoxX;
        private System.Windows.Forms.TextBox _rightBottomTextBoxY;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}