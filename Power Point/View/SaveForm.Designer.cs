
namespace Power_Point
{
    partial class SaveForm
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
            this._saveButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(41, 135);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 30);
            this._saveButton.TabIndex = 0;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.ClickSaveButton);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(157, 135);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 30);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._label1.Location = new System.Drawing.Point(64, 67);
            this._label1.Name = "label1";
            this._label1.Size = new System.Drawing.Size(145, 23);
            this._label1.TabIndex = 2;
            this._label1.Text = "是否確定要儲存?";
            // 
            // SaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 194);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._saveButton);
            this.Name = "SaveForm";
            this.Text = "SaveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _label1;
    }
}