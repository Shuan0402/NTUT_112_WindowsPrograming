namespace Power_Point
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._dataGridShapeData = new System.Windows.Forms.DataGridView();
            this._deleteDataGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeDataGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dataDataGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._groupBoxDataShow = new System.Windows.Forms.GroupBox();
            this._comboBoxShape = new System.Windows.Forms.ComboBox();
            this._buttonCreate = new System.Windows.Forms.Button();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._introductionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._shapeStrip = new System.Windows.Forms.ToolStrip();
            this._undoStripButton = new System.Windows.Forms.ToolStripButton();
            this._redoStripButton = new System.Windows.Forms.ToolStripButton();
            this._addPageStripButton = new System.Windows.Forms.ToolStripButton();
            this._saveStripButton = new System.Windows.Forms.ToolStripButton();
            this._loadStripButton = new System.Windows.Forms.ToolStripButton();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._canvas = new Power_Point.DoubleBufferedPanel();
            this._lineStripButton = new BindableToolStripButton();
            this._rectangleStripButton = new BindableToolStripButton();
            this._circleStripButton = new BindableToolStripButton();
            this._arrowStripButton = new BindableToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridShapeData)).BeginInit();
            this._groupBoxDataShow.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this._shapeStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridShapeData
            // 
            this._dataGridShapeData.AllowUserToAddRows = false;
            this._dataGridShapeData.AllowUserToDeleteRows = false;
            this._dataGridShapeData.AllowUserToOrderColumns = true;
            this._dataGridShapeData.AllowUserToResizeColumns = false;
            this._dataGridShapeData.AllowUserToResizeRows = false;
            this._dataGridShapeData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridShapeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridShapeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteDataGrid,
            this._shapeDataGrid,
            this._dataDataGrid});
            this._dataGridShapeData.Location = new System.Drawing.Point(0, 94);
            this._dataGridShapeData.Name = "_dataGridShapeData";
            this._dataGridShapeData.ReadOnly = true;
            this._dataGridShapeData.RowHeadersVisible = false;
            this._dataGridShapeData.RowHeadersWidth = 62;
            this._dataGridShapeData.RowTemplate.Height = 31;
            this._dataGridShapeData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridShapeData.Size = new System.Drawing.Size(418, 460);
            this._dataGridShapeData.TabIndex = 0;
            this._dataGridShapeData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridShapeDataCellContent);
            // 
            // _deleteDataGrid
            // 
            this._deleteDataGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._deleteDataGrid.FillWeight = 50F;
            this._deleteDataGrid.HeaderText = "刪除";
            this._deleteDataGrid.MinimumWidth = 8;
            this._deleteDataGrid.Name = "_deleteDataGrid";
            this._deleteDataGrid.ReadOnly = true;
            this._deleteDataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteDataGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._deleteDataGrid.Text = "";
            // 
            // _shapeDataGrid
            // 
            this._shapeDataGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._shapeDataGrid.FillWeight = 50F;
            this._shapeDataGrid.HeaderText = "形狀";
            this._shapeDataGrid.MinimumWidth = 8;
            this._shapeDataGrid.Name = "_shapeDataGrid";
            this._shapeDataGrid.ReadOnly = true;
            // 
            // _dataDataGrid
            // 
            this._dataDataGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._dataDataGrid.HeaderText = "資訊";
            this._dataDataGrid.MinimumWidth = 8;
            this._dataDataGrid.Name = "_dataDataGrid";
            this._dataDataGrid.ReadOnly = true;
            // 
            // _groupBoxDataShow
            // 
            this._groupBoxDataShow.BackColor = System.Drawing.SystemColors.Control;
            this._groupBoxDataShow.Controls.Add(this._dataGridShapeData);
            this._groupBoxDataShow.Controls.Add(this._comboBoxShape);
            this._groupBoxDataShow.Controls.Add(this._buttonCreate);
            this._groupBoxDataShow.Location = new System.Drawing.Point(3, 0);
            this._groupBoxDataShow.Name = "_groupBoxDataShow";
            this._groupBoxDataShow.Size = new System.Drawing.Size(420, 555);
            this._groupBoxDataShow.TabIndex = 1;
            this._groupBoxDataShow.TabStop = false;
            this._groupBoxDataShow.Text = "資料顯示";
            // 
            // _comboBoxShape
            // 
            this._comboBoxShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxShape.FormattingEnabled = true;
            this._comboBoxShape.Items.AddRange(new object[] {
            "線",
            "矩形",
            "圓形"});
            this._comboBoxShape.Location = new System.Drawing.Point(122, 45);
            this._comboBoxShape.Margin = new System.Windows.Forms.Padding(4);
            this._comboBoxShape.Name = "_comboBoxShape";
            this._comboBoxShape.Size = new System.Drawing.Size(180, 26);
            this._comboBoxShape.TabIndex = 2;
            this._comboBoxShape.SelectedIndexChanged += new System.EventHandler(this.SelectComboBoxShape);
            // 
            // _buttonCreate
            // 
            this._buttonCreate.Location = new System.Drawing.Point(8, 30);
            this._buttonCreate.Margin = new System.Windows.Forms.Padding(4);
            this._buttonCreate.Name = "_buttonCreate";
            this._buttonCreate.Size = new System.Drawing.Size(84, 57);
            this._buttonCreate.TabIndex = 2;
            this._buttonCreate.Text = "新增";
            this._buttonCreate.UseVisualStyleBackColor = true;
            this._buttonCreate.Click += new System.EventHandler(this.ClickButtonCreate);
            // 
            // _menuStrip
            // 
            this._menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._introductionToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1284, 36);
            this._menuStrip.TabIndex = 4;
            this._menuStrip.Text = "menuStrip1";
            this._menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ClickMenuStrip);
            // 
            // _introductionToolStripMenuItem
            // 
            this._introductionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._introductionToolStripMenuItem.Name = "_introductionToolStripMenuItem";
            this._introductionToolStripMenuItem.Size = new System.Drawing.Size(62, 27);
            this._introductionToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _shapeStrip
            // 
            this._shapeStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._shapeStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineStripButton,
            this._rectangleStripButton,
            this._circleStripButton,
            this._arrowStripButton,
            this._undoStripButton,
            this._redoStripButton,
            this._addPageStripButton,
            this._saveStripButton,
            this._loadStripButton});
            this._shapeStrip.Location = new System.Drawing.Point(0, 36);
            this._shapeStrip.Name = "_shapeStrip";
            this._shapeStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this._shapeStrip.Size = new System.Drawing.Size(1284, 38);
            this._shapeStrip.TabIndex = 5;
            this._shapeStrip.Text = "toolStrip1";
            this._shapeStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ClickArrowStripItem);
            // 
            // _undoStripButton
            // 
            this._undoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoStripButton.Image")));
            this._undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoStripButton.Name = "_undoStripButton";
            this._undoStripButton.Size = new System.Drawing.Size(34, 28);
            this._undoStripButton.Text = "Undo";
            this._undoStripButton.Click += new System.EventHandler(this.ClickUndoStripButton);
            // 
            // _redoStripButton
            // 
            this._redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoStripButton.Image")));
            this._redoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoStripButton.Name = "_redoStripButton";
            this._redoStripButton.Size = new System.Drawing.Size(34, 28);
            this._redoStripButton.Text = "Redo";
            this._redoStripButton.Click += new System.EventHandler(this.ClickRedoStripButton);
            // 
            // _addPageStripButton
            // 
            this._addPageStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addPageStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_addPageStripButton.Image")));
            this._addPageStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addPageStripButton.Name = "_addPageStripButton";
            this._addPageStripButton.Size = new System.Drawing.Size(34, 28);
            this._addPageStripButton.Text = "NewSlide";
            this._addPageStripButton.Click += new System.EventHandler(this.AddPageStripButton);
            // 
            // _saveStripButton
            // 
            this._saveStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._saveStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_saveStripButton.Image")));
            this._saveStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveStripButton.Name = "_saveStripButton";
            this._saveStripButton.Size = new System.Drawing.Size(34, 28);
            this._saveStripButton.Text = "Save";
            this._saveStripButton.Click += new System.EventHandler(this.ClicksaveStripButton);
            // 
            // _loadStripButton
            // 
            this._loadStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._loadStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_loadStripButton.Image")));
            this._loadStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._loadStripButton.Name = "_loadStripButton";
            this._loadStripButton.Size = new System.Drawing.Size(34, 28);
            this._loadStripButton.Text = "Load";
            this._loadStripButton.Click += new System.EventHandler(this._loadStripButton_Click);
            // 
            // _splitContainer1
            // 
            this._splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer1.Location = new System.Drawing.Point(0, 74);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.Controls.Add(this._splitContainer2);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._groupBoxDataShow);
            this._splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintSplitContainer1Panel2);
            this._splitContainer1.Size = new System.Drawing.Size(1284, 565);
            this._splitContainer1.SplitterDistance = 856;
            this._splitContainer1.TabIndex = 7;
            this._splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveSplitContainer1Splitter);
            // 
            // _splitContainer2
            // 
            this._splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer2.Location = new System.Drawing.Point(0, 0);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.Controls.Add(this._canvas);
            this._splitContainer2.Size = new System.Drawing.Size(856, 565);
            this._splitContainer2.SplitterDistance = 122;
            this._splitContainer2.TabIndex = 7;
            this._splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveSplitContainer2Splitter);
            // 
            // _canvas
            // 
            this._canvas.AutoScroll = true;
            this._canvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._canvas.Cursor = System.Windows.Forms.Cursors.Default;
            this._canvas.Location = new System.Drawing.Point(3, 80);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(658, 396);
            this._canvas.TabIndex = 6;
            this._canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintPanel);
            this._canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PressCanvasMouse);
            // 
            // _lineStripButton
            // 
            this._lineStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineStripButton.Image")));
            this._lineStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineStripButton.Name = "_lineStripButton";
            this._lineStripButton.Size = new System.Drawing.Size(34, 33);
            this._lineStripButton.Text = "Line";
            this._lineStripButton.Click += new System.EventHandler(this.ClickLineStripButton);
            // 
            // _rectangleStripButton
            // 
            this._rectangleStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleStripButton.Image")));
            this._rectangleStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleStripButton.Name = "_rectangleStripButton";
            this._rectangleStripButton.Size = new System.Drawing.Size(34, 28);
            this._rectangleStripButton.Text = "Rectangle";
            this._rectangleStripButton.Click += new System.EventHandler(this.ClickRectangleStripButton);
            // 
            // _circleStripButton
            // 
            this._circleStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleStripButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._circleStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_circleStripButton.Image")));
            this._circleStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleStripButton.Name = "_circleStripButton";
            this._circleStripButton.Size = new System.Drawing.Size(34, 28);
            this._circleStripButton.Text = "Circle";
            this._circleStripButton.Click += new System.EventHandler(this.ClickCircleStripButton);
            // 
            // _arrowStripButton
            // 
            this._arrowStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._arrowStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_arrowStripButton.Image")));
            this._arrowStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._arrowStripButton.Name = "_arrowStripButton";
            this._arrowStripButton.Size = new System.Drawing.Size(34, 28);
            this._arrowStripButton.Text = "Arrow";
            this._arrowStripButton.Click += new System.EventHandler(this.ClickArrowStripButton);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1284, 639);
            this.Controls.Add(this._splitContainer1);
            this.Controls.Add(this._shapeStrip);
            this.Controls.Add(this._menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.MainMenuStrip = this._menuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridShapeData)).EndInit();
            this._groupBoxDataShow.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._shapeStrip.ResumeLayout(false);
            this._shapeStrip.PerformLayout();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridShapeData;
        private System.Windows.Forms.GroupBox _groupBoxDataShow;
        private System.Windows.Forms.Button _buttonCreate;
        private System.Windows.Forms.ComboBox _comboBoxShape;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _introductionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;

        const string DELETE = "刪除";
        const string LOCATION = "位置";
        private System.Windows.Forms.DataGridViewButtonColumn _deleteDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dataDataGrid;
        private System.Windows.Forms.ToolStrip _shapeStrip;
        private BindableToolStripButton _lineStripButton;
        private BindableToolStripButton _rectangleStripButton;
        private BindableToolStripButton _circleStripButton;
        private BindableToolStripButton _arrowStripButton;
        private DoubleBufferedPanel _canvas;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.BindingSource _bindingSource1;
        private System.Windows.Forms.ToolStripButton _undoStripButton;
        private System.Windows.Forms.ToolStripButton _redoStripButton;
        private System.Windows.Forms.SplitContainer _splitContainer2;
        private System.Windows.Forms.ToolStripButton _addPageStripButton;
        private System.Windows.Forms.ToolStripButton _saveStripButton;
        private System.Windows.Forms.ToolStripButton _loadStripButton;
    }
}

