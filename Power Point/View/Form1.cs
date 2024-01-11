using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Cursors = System.Windows.Forms.Cursors;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using KeyEventHandler = System.Windows.Forms.KeyEventHandler;

namespace Power_Point
{
    public partial class Form1 : Form
    {
        private readonly PresentationModel _presentationModel;

        const string CHECKED = "Checked";
        const string IS_LINE_CHECKED = "IsLineChecked";
        const string IS_CIRCLE_CHECKED = "IsCircleChecked";
        const string IS_RECTANGLE_CHECKED = "IsRectangleChecked";
        const string IS_ARROW_CHECKED = "IsArrowChecked";
        private Size canvasSize;
        private Size slideButtonSize;
        private System.Drawing.Point slideLocation;
        private double rate;
        private double slideButtonRate;
        List<Button> _slideList;
        double slideButtonWidth;

        Point LeftTopPoint;
        Point RightBottomPoint;

        // 輸入框

        public Form1(PresentationModel model)
        {
            _presentationModel = model;
            InitializeComponent();

            // 畫布建置
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            canvasSize = _canvas.Size;

            // Pannel 狀態改變
            _presentationModel.PresentationPannelChanged += HandleCanvasChanged;
            // Slide Button 狀態改變
            _presentationModel.PresentationButtonChanged += HandleButtonChanged;
            // 新增 Slide
            _presentationModel.PresentationPageAdded += HandlePageAdded;
            // 刪除 Slide
            _presentationModel.PresentationPageDeleted += HandlePageDeleted;

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(DeleteKeyDown);

            // 建立 Databinding
            _lineStripButton.DataBindings.Add(CHECKED, _presentationModel, IS_LINE_CHECKED);
            _circleStripButton.DataBindings.Add(CHECKED, _presentationModel, IS_CIRCLE_CHECKED);
            _rectangleStripButton.DataBindings.Add(CHECKED, _presentationModel, IS_RECTANGLE_CHECKED);
            _arrowStripButton.DataBindings.Add(CHECKED, _presentationModel, IS_ARROW_CHECKED);

            // 設定 undo、redo 狀態
            _redoStripButton.Enabled = false;
            _undoStripButton.Enabled = false;

            SetSplitContainerSize();
            RepositionPanel(); 

            this.Resize += ResizeMainForm;

            rate = 1;
            slideButtonRate = 1;

            // slidebutton
            slideButtonWidth = _splitContainer2.SplitterDistance - 2;
            slideButtonSize = new Size((int)slideButtonWidth, (int)(slideButtonWidth * 9.0 / 16.0));
            slideLocation = new System.Drawing.Point(0, 0);
            _slideList = new List<Button>();
            _presentationModel.OriginSlideIndex = -1;
            _presentationModel._currentSlideIndex = -1;
            AddNewSlide();
            _slideList[0].FlatStyle = FlatStyle.Flat;
            _slideList[0].FlatAppearance.BorderColor = Color.Blue;
            _slideList[0].FlatAppearance.BorderSize = 2;
            _slideList[0].BackColor = Color.White;

            // 輸入框
        }

        // 設定 DataGridColumn
        private void SetDataGridColumn()
        {
            _dataGridShapeData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridShapeData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dataGridShapeData.ReadOnly = true;
            _dataGridShapeData.RowHeadersVisible = false;
            _dataGridShapeData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // 遍歷 shapes
        private void SetShapes()
        {
            _dataGridShapeData.Rows.Clear();

            List<ShapeData> dataList = _presentationModel.GetShapeData();
            for (int i = 0; i < dataList.Count; i++)
            {
                string originalInfo = dataList[i].Info;
                string modifiedInfo = MultiplyValuesInInfo(originalInfo);
                _dataGridShapeData.Rows.Add(DELETE, dataList[i].Name, modifiedInfo);
            }
        }

        // MultiplyValuesInInfo
        private string MultiplyValuesInInfo(string info)
        {
            string pattern = @"\((\w+), (\w+)\)";
            string modifiedInfo = Regex.Replace(info, pattern, m =>
            {
                int value1 = int.Parse(m.Groups[1].Value);
                int value2 = int.Parse(m.Groups[2].Value);
                int newValue1 = (int)(value1 * (double)((double)_canvas.Width / (double)canvasSize.Width));
                int newValue2 = (int)(value2 * (double)((double)_canvas.Height / (double)canvasSize.Height));
                return $"({newValue1}, {newValue2})";
            });
            return modifiedInfo;
        }

        // 更新 datagridcolumn 資訊 
        private void ShowShapeList()
        {
            SetDataGridColumn();

            SetShapes();

            _dataGridShapeData.Refresh();
        }

        // 圖形資料表格
        private void ClickDataGridShapeDataCellContent(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowToRemove = _dataGridShapeData.Rows[e.RowIndex];
            _dataGridShapeData.Rows.Remove(rowToRemove);
            _presentationModel.DeleteShape(e.RowIndex, e.ColumnIndex, Keys.None);
        }

        // 圖形選取下拉式清單
        private void SelectComboBoxShape(object sender, EventArgs e)
        {
            _presentationModel.UnCheckSlide();
        }

        // 說明關於欄位
        private void ClickMenuStrip(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void OpenForm2()
        {
            using (Form2 modalDialog = new Form2())
            {
                if (modalDialog.ShowDialog() == DialogResult.OK)
                {
                    // 存取 modalDialog 中的 TextBox 的值
                    LeftTopPoint = modalDialog.LeftTopPoint;
                    RightBottomPoint = modalDialog.RightBottomPoint;

                    // 使用這些值進行其他處理
                }
            }
        }

        // 新增按鈕
        private void ClickButtonCreate(object sender, EventArgs e)
        {
            if (_comboBoxShape.SelectedIndex != -1)
            {
                string selectedShape = _comboBoxShape.SelectedItem.ToString();

                OpenForm2();

                _presentationModel.AddDataGridViewShape(selectedShape, LeftTopPoint, RightBottomPoint);
                
                ShowShapeList();

                RefreshUI();
                _presentationModel.UnCheckSlide();
            }
        }
        
        // shapeStrip
        private void ClickArrowStripItem(object sender, ToolStripItemClickedEventArgs e)
        {
            _presentationModel.CheckArrow();
            _canvas.Cursor = _presentationModel.GetCursors();
        }

        // 點選 Circle 按鈕
        private void ClickCircleStripButton(object sender, EventArgs e)
        {
            _presentationModel.CheckCircle();
            _canvas.Cursor = _presentationModel.GetCursors();
        }

        // 點選 Line 按鈕
        private void ClickLineStripButton(object sender, EventArgs e)
        {
            _presentationModel.CheckLine();
            _canvas.Cursor = _presentationModel.GetCursors();

        }

        // 點選 Rectangle 按鈕
        private void ClickRectangleStripButton(object sender, EventArgs e)
        {
            _presentationModel.CheckRectangle();
            _canvas.Cursor = _presentationModel.GetCursors();
        }

        // 點選 Arrow 按鈕
        private void ClickArrowStripButton(object sender, EventArgs e)
        {
            _presentationModel.CheckArrow();
            _canvas.Cursor = _presentationModel.GetCursors();
        }

        // EnterGroupBox
        private void EnterGroupBox(object sender, EventArgs e)
        {

        }

        // LoadForm
        private void LoadForm(object sender, EventArgs e)
        {

        }

        // Panel
        private void PaintPanel(object sender, PaintEventArgs e)
        {

        }

        // 壓下滑鼠
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PointerPressed(e.X / rate, e.Y / rate);
            RefreshUI();
        }

        // 滑鼠移動
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PointerMoved(e.X / rate, e.Y / rate);
            _canvas.Cursor = _presentationModel.GetCursors();
        }

        // 放開滑鼠
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PointerReleased();
            _canvas.Cursor = _presentationModel.GetCursors();
            _presentationModel.CheckArrow();
            ShowShapeList();
            RefreshUI();
        }

        // 繪製畫圖
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.DrawPannel(new FormsGraphicsAdaptor(e.Graphics), rate);
        }

        // 繪製縮圖
        public void HandleButtonPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Button slide = sender as Button;
            _presentationModel.DrawButton(new FormsGraphicsAdaptor(e.Graphics), slideButtonRate, _slideList.IndexOf(slide));
        }

        // 更新畫布
        public void HandleCanvasChanged()
        {
            _canvas.Invalidate(true);
        }

        // 更新按鍵
        public void HandleButtonChanged()
        {
            foreach(Button slide in _slideList)
            {
                slide.Invalidate(true);
            }
            
        }

        // 按下鍵盤 Delete 鍵
        private void DeleteKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.DeleteShape(-1, 0, e.KeyCode);
            _presentationModel.DeletePage(_presentationModel._currentSlideIndex);
            ShowShapeList();
        }

        // splitContainer1_Panel2_Paint
        private void PaintSplitContainer1Panel2(object sender, PaintEventArgs e)
        {

        }

        // _undoStripButton_Click
        private void ClickUndoStripButton(object sender, EventArgs e)
        {
            _presentationModel.Undo();
            RefreshUI();
            HandleCanvasChanged();
            HandleButtonChanged();
            _presentationModel.UnCheckSlide();
        }

        // _redoStripButton_Click
        private void ClickRedoStripButton(object sender, EventArgs e)
        {
            _presentationModel.Redo();
            RefreshUI();
            HandleCanvasChanged();
            HandleButtonChanged();
            _presentationModel.UnCheckSlide();
        }

        // RefreshUI
        void RefreshUI()
        {
            _redoStripButton.Enabled = _presentationModel.IsRedoEnabled;
            _undoStripButton.Enabled = _presentationModel.IsUndoEnabled;
            Invalidate();
            ShowShapeList();
        }

        // splitContainer1_SplitterMoved
        private void MoveSplitContainer1Splitter(object sender, SplitterEventArgs e)
        {
            SetSplitContainerSize();
            rate = (double)((double)_canvas.Width / (double)canvasSize.Width);
            HandleCanvasChanged();
        }

        // splitContainer2_SplitterMoved
        private void MoveSplitContainer2Splitter(object sender, SplitterEventArgs e)
        {
            SetSplitContainerSize();
            rate = (double)((double)_canvas.Width / (double)canvasSize.Width);
            slideButtonRate = (double)((double)slideButtonWidth / (double)slideButtonSize.Width);

            HandleCanvasChanged();
        }

        // SetSplitContainerSize
        private void SetSplitContainerSize()
        {
            slideButtonWidth = _splitContainer2.SplitterDistance - 2;
            slideButtonSize = new Size((int)slideButtonWidth, (int)(slideButtonWidth * 9.0 / 16.0));

            if (_slideList != null)
            {
                foreach (Button slide in _slideList)
                {
                    slide.Size = slideButtonSize;
                }
            }

            int canvasWidth = _splitContainer1.SplitterDistance - _splitContainer2.SplitterDistance - _splitContainer2.SplitterWidth;
            _canvas.Size = new Size(canvasWidth, (int)(canvasWidth * 9.0 / 16.0));

            int panel2Width = _splitContainer1.Width - _splitContainer1.SplitterDistance - _splitContainer1.SplitterWidth;

            _groupBoxDataShow.Width = panel2Width;
            _dataGridShapeData.Width = panel2Width;

            RepositionPanel();
        }

        

        // MainForm_Resize
        private void ResizeMainForm(object sender, EventArgs e)
        {
            // 重新定位 Panel
            RepositionPanel();
            rate = (double)((double)_canvas.Width / (double)canvasSize.Width);
            slideButtonRate = (double)((double)slideButtonWidth / (double)slideButtonSize.Width);
        }
        // RepositionPanel
        private void RepositionPanel()
        {
            int splitContainerPannel2Width = _splitContainer2.Width - _splitContainer2.SplitterDistance - _splitContainer2.SplitterWidth;

            int newPanelX = (splitContainerPannel2Width - _canvas.Width) / 2;
            int newPanelY = (_splitContainer2.Height - _canvas.Height) / 2;

            _canvas.Location = new System.Drawing.Point(newPanelX, newPanelY);
        }

        // _canvas_MouseDown
        private void PressCanvasMouse(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void AddPageStripButton(object sender, EventArgs e)
        {
            if (_slideList.Count() == 5)
            {
                return;
            }
            AddNewSlide();
            CheckSlide();

            RefreshUI();
            HandleCanvasChanged();
        }

        private void AddNewSlide()
        {
            _presentationModel.OriginSlideIndex = (int)_presentationModel._currentSlideIndex;
            _presentationModel._currentSlideIndex++;
            _presentationModel.AddPage(_presentationModel._currentSlideIndex);
        }
        
        // _slideButton_Click
        private void ClickSlideButton(object sender, EventArgs e)
        {
            Button slide = sender as Button;

            if (slide != null)
            {
                _presentationModel.OriginSlideIndex = _presentationModel._currentSlideIndex;
                _presentationModel._currentSlideIndex = _slideList.IndexOf(slide);
                _presentationModel.CheckSlide();
            }

            HandleCanvasChanged();
            RefreshUI();
            CheckSlide();
        }

        // check
        private void CheckSlide()
        {
            _slideList[_presentationModel.OriginSlideIndex].FlatAppearance.BorderSize = 0;
            _slideList[_presentationModel._currentSlideIndex].FlatAppearance.BorderSize = 2;
        }

        // add
        public void HandlePageAdded()
        {
            _presentationModel.OriginSlideIndex = _presentationModel._currentSlideIndex - 1;
            Button newButton = new Button();
            newButton.Name = "_slideButton" + _slideList.Count().ToString();
            newButton.Size = slideButtonSize;
            newButton.Width -= 2;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.BackColor = Color.White;
            newButton.FlatAppearance.BorderColor = Color.Blue;
            newButton.FlatAppearance.BorderSize = 2;

            System.Drawing.Point point = new System.Drawing.Point(0, (newButton.Height + 5) * _slideList.Count());
            newButton.Location = point;
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += new System.EventHandler(this.ClickSlideButton);
            newButton.Paint += HandleButtonPaint;
            _splitContainer2.Panel1.Controls.Add(newButton);
            _slideList.Add(newButton);

            _presentationModel._currentSlideIndex = _slideList.IndexOf(newButton);
        }

        // delete
        public void HandlePageDeleted()
        {
            _splitContainer2.Panel1.Controls.RemoveAt(_presentationModel._currentSlideIndex);
            _slideList.RemoveAt(_presentationModel._currentSlideIndex);
            SetSlideLocation();
            _presentationModel.SetOriginSlideIndex(_presentationModel._currentSlideIndex - 1);
            _presentationModel.SetCurrentSlideIndex(_presentationModel._currentSlideIndex - 1);
            _presentationModel.UnCheckSlide();
            CheckSlide();
        }

        // set
        private void SetSlideLocation()
        {
            foreach (Button slide in _slideList)
            {
                System.Drawing.Point point = new System.Drawing.Point(0, (slide.Height + 5) * _slideList.IndexOf(slide));
                slide.Location = point;
            }
        }
    }
}
