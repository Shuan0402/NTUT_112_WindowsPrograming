using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Power_Point
{
    public class PresentationModel: INotifyPropertyChanged
    {
        private string _selectButtonType = null;
        public readonly PowerPointModel _model;

        const string DRAW = "draw";
        const string POINT = "point";
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";


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
        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsLineChecked
        {
            get;
            set;
        }

        // 圓按鈕是否被選取
        public bool IsCircleChecked
        {
            get;
            set;
        }

        // 矩形按鈕是否被選取
        public bool IsRectangleChecked
        {
            get;
            set;
        }

        public bool IsArrowChecked
        {
            get;
            set;
        }

        

        // 取消選取圖形按鈕
        public void CheckArrow()
        {
            _selectButtonType = null;
            IsLineChecked = false;
            IsCircleChecked = false;
            IsRectangleChecked = false;
            IsArrowChecked = true;
            _model.ChangeState(POINT);
            Notify("IsArrowChecked");
            Notify("IsLineChecked");
            Notify("IsCircleChecked");
            Notify("IsRectangleChecked");
        }

        // Line
        public void CheckLine()
        {
            CheckArrow();
            _model.ChangeState(DRAW);
            _selectButtonType = LINE;
            IsLineChecked = true;
            IsArrowChecked = false;
            
            Notify("IsLineChecked");
            Notify("IsArrowChecked");
        }

        // Circle
        public void CheckCircle()
        {
            CheckArrow();
            _model.ChangeState(DRAW);
            _selectButtonType = CIRCLE;
            IsCircleChecked = true;
            IsArrowChecked = false;
            
            Notify("IsCircleChecked");
            Notify("IsArrowChecked");
        }

        // Rectangle
        public void CheckRectangle()
        {
            CheckArrow();
            _model.ChangeState(DRAW);
            _selectButtonType = RECTANGLE;
            IsRectangleChecked = true;
            IsArrowChecked = false;
            
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
            _model.PressPointer(x, y, _selectButtonType);
        }

        // 放開滑鼠
        public void PointerReleased()
        {
            _model.ReleasePointer();
            _model.ChangeState(POINT);
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
        public void DrawPannel(FormsGraphicsAdaptor graphics)
        {
            _model.DrawPannel(graphics);
        }

        // 新增繪圖
        public void DrawButton(FormsGraphicsAdaptor graphics)
        {
            _model.DrawButton(graphics);
        }

        // 控制滑鼠型態
        public Cursor GetCursors()
        {
            if (_selectButtonType == null)
            {
                if (_model.IsShapeSizable)
                {
                    return Cursors.SizeNWSE;
                }
                return Cursors.Arrow;
            }
            else
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