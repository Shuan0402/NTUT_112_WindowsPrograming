
namespace Power_Point
{
    partial class LoadForm
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
            this._label1 = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this._loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._label1.Location = new System.Drawing.Point(65, 54);
            this._label1.Name = "label1";
            this._label1.Size = new System.Drawing.Size(145, 23);
            this._label1.TabIndex = 5;
            this._label1.Text = "是否要重新載入?";
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(160, 119);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 30);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _loadButton
            // 
            this._loadButton.Location = new System.Drawing.Point(44, 119);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(75, 30);
            this._loadButton.TabIndex = 3;
            this._loadButton.Text = "Load";
            this._loadButton.UseVisualStyleBackColor = true;
            this._loadButton.Click += new System.EventHandler(this.ClickLoadButton);
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 194);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._loadButton);
            this.Name = "LoadForm";
            this.Text = "LoadForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _loadButton;
    }
}