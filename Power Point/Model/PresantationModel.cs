using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Power_Point
{
    public class PresentationModel: INotifyPropertyChanged
    {
        public bool _isLineChecked = false;
        public bool _isCircleChecked = false;
        public bool _isRectangleChecked = false;
        public bool _isArrowChecked = false;
        public bool _isShapeSelected = false;
        string _selectShapeType = null;
        public readonly PowerPointModel _model;
        public PresentationModel(PowerPointModel model)
        {
            this._model = model;
        }

        // pm 事件傳回給 m
        public event PowerPointModel.PannelChangedEventHandler PresentationPannelChanged
        {
            add => _model.ChangePannelEvent += value;
            remove => _model.ChangePannelEvent -= value;
        }

        public event PowerPointModel.ButtonChangedEventHandler PresentationButtonChanged
        {
            add => _model.ChangeButtonEvent += value;
            remove => _model.ChangeButtonEvent -= value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // 通知 Property 改變
        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // 線按鈕是否被選取
        public bool IsLineChecked
        {
            get
            {
                return _isLineChecked;
            }
        }

        // 圓按鈕是否被選取
        public bool IsCircleChecked
        {
            get
            {
                return _isCircleChecked;
            }
        }

        // 矩形按鈕是否被選取
        public bool IsRectangleChecked
        {
            get
            {
                return _isRectangleChecked;
            }
        }

        public bool IsArrowChecked
        {
            get
            {
                return _isArrowChecked;
            }
        }

        // 取消選取圖形按鈕
        public void CheckArrow()
        {
            _selectShapeType = null;
            _isLineChecked = false;
            _isCircleChecked = false;
            _isRectangleChecked = false;
            _isArrowChecked = true;
            _model.ChangeState("point");
            Notify("IsArrowChecked");
            Notify("IsLineChecked");
            Notify("IsCircleChecked");
            Notify("IsRectangleChecked");
        }

        // Line
        public void CheckLine()
        {
            CheckArrow();
            if (!_isLineChecked)
            {
                _model.ChangeState("draw");
                _selectShapeType = "線";
                _isLineChecked = true;
                _isArrowChecked = false;
            }
            Notify("IsLineChecked");
            Notify("IsArrowChecked");
        }

        // Circle
        public void CheckCircle()
        {
            CheckArrow();
            if (!_isCircleChecked)
            {
                _model.ChangeState("draw");
                _selectShapeType = "圓形";
                _isCircleChecked = true;
                _isArrowChecked = false;
            }
            Notify("IsCircleChecked");
            Notify("IsArrowChecked");
        }

        // Rectangle
        public void CheckRectangle()
        {
            CheckArrow();
            if (!_isRectangleChecked)
            {
                _model.ChangeState("draw");
                _selectShapeType = "矩形";
                _isRectangleChecked = true;
                _isArrowChecked = false;
            }
            Notify("IsRectangleChecked");
            Notify("IsArrowChecked");
        }

        // 遍歷 Sahpes
        public List<ShapeData> GetShapeData()
        {
            List<ShapeData> dataList = _model.GetShapeData();
            return dataList;
        }

        // 新增 shape
        public void CreateShape(string selectedShape)
        {
            _model.CreateShape(selectedShape);
        }

        // 刪除 shape
        public void DeleteShape(int index)
        {
            _model.DeleteShape(index);
        }

        // 壓下滑鼠
        public void PointerPressed(double x, double y)
        {
            _model.PressPointer(x, y, _selectShapeType);
        }

        // 放開滑鼠
        public void PointerReleased(double x, double y)
        {
            _model.ChangeState("point");
            _model.ReleasePointer(x, y, _selectShapeType);
            CheckArrow();
        }

        // 滑鼠移動
        public void PointerMoved(double x, double y)
        {
            _model.MovePointer(x, y);
        }

        // 清除
        public void ClearShapes()
        {
            _model.ClearShapes();
        }

        // 新增繪圖
        public void DrawPannel(System.Drawing.Graphics graphics)
        {
            _model.DrawPannel(new FormsGraphicsAdaptor(graphics));
        }

        // 新增繪圖
        public void DrawButton(System.Drawing.Graphics graphics)
        {
            _model.DrawButton(new FormsGraphicsAdaptor(graphics));
        }

        // 控制滑鼠型態
        public Cursor GetCursors()
        {
            if (_selectShapeType == null)
            {
                return Cursors.Arrow;
            } else
            {
                return Cursors.Cross;
            }
        }

        // 刪除選取形狀
        public void DeleteSelectedShape()
        {
            _model.DeleteSelecetedShape();
        }
    }
}