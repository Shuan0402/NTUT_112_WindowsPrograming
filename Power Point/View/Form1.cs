using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        readonly PresentationModel _presentationModel;

        const string CHECKED = "Checked";
        const string IS_LINE_CHECKED = "IsLineChecked";
        const string IS_CIRCLE_CHECKED = "IsCircleChecked";
        const string IS_RECTANGLE_CHECKED = "IsRectangleChecked";
        const string IS_ARROW_CHECKED = "IsArrowChecked";

        public Form1(PresentationModel model)
        {
            InitializeComponent();
            _presentationModel = model;

            // 畫布建置
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            //Controls.Add(_canvas);

            // Pannel 狀態改變
            _presentationModel.PresentationPannelChanged += HandleCanvasChanged;
            // Slide Button 狀態改變
            _presentationModel.PresentationButtonChanged += HandleButtonChanged;
            _slideButton.Paint += HandleButtonPaint;

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(DeleteKeyDown);

            // 建立 Databinding
            _lineStripButton.DataBindings.Add(CHECKED, _presentationModel, IS_LINE_CHECKED);
            _circleStripButton.DataBindings.Add(CHECKED, _presentationModel, IS_CIRCLE_CHECKED);
            _rectangleStripButton.DataBindings.Add(CHECKED, _presentationModel, IS_RECTANGLE_CHECKED);
            _arrowStripButton.DataBindings.Add(CHECKED, _presentationModel, IS_ARROW_CHECKED);
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
                _dataGridShapeData.Rows.Add(DELETE, dataList[i].Name, dataList[i].Info);
            }
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
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                DataGridViewRow rowToRemove = _dataGridShapeData.Rows[e.RowIndex];
                _dataGridShapeData.Rows.Remove(rowToRemove);
                _presentationModel.DeleteShape(e.RowIndex);
            }
        }

        // 圖形選取下拉式清單
        private void SelectComboBoxShape(object sender, EventArgs e)
        {

        }

        // 說明關於欄位
        private void ClickMenuStrip(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        // 新增按鈕
        private void ClickButtonCreate(object sender, EventArgs e)
        {
            if (_comboBoxShape.SelectedIndex != -1)
            {
                string selectedShape = _comboBoxShape.SelectedItem.ToString();
                _presentationModel.CreateShape(selectedShape);
                ShowShapeList();
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
            _presentationModel.PointerPressed(e.X, e.Y);
        }

        // 放開滑鼠
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PointerReleased(e.X, e.Y);
            _canvas.Cursor = _presentationModel.GetCursors();
            _presentationModel.CheckArrow();
            ShowShapeList();
        }

        // 滑鼠移動
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PointerMoved(e.X, e.Y);
        }

        // 繪製畫圖
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.DrawPannel(e.Graphics);
        }

        // 繪製縮圖
        public void HandleButtonPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.DrawButton(e.Graphics);
        }

        // 更新畫布
        public void HandleCanvasChanged()
        {
            _canvas.Invalidate(true);
        }

        // 更新畫布
        public void HandleButtonChanged()
        {
            _slideButton.Invalidate(true);
        }

        // 按下鍵盤 Delete 鍵
        private void DeleteKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _presentationModel.DeleteSelectedShape();
                ShowShapeList();
            }
        }
    }
}
