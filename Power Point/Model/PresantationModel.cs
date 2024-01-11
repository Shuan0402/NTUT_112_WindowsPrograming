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

        public event PowerPointModel.PageAddEventHandler PresentationPageAdded
        {
            add => _model.AddPageEvent += value;
            remove => _model.AddPageEvent -= value;
        }

        public event PowerPointModel.PageDeleteEventHandler PresentationPageDeleted
        {
            add => _model.DeletePageEvent += value;
            remove => _model.DeletePageEvent -= value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // 通知 Property 改變
        public void NotifyProperty(string propertyName)
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

        public bool IsSlideChecked
        {
            get;
            set;
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _model.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _model.IsUndoEnabled;
            }
        }

        public int OriginSlideIndex
        {
            get
            {
                return _model._originSlideIndex;
            }
            set
            {
                _model._originSlideIndex = value;
            }
        }

        public int _currentSlideIndex
        {
            get
            {
                return _model._currentSlideIndex;
            }
            set
            {
                _model._currentSlideIndex = value;
            }
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
            NotifyProperty("IsArrowChecked");
            NotifyProperty("IsLineChecked");
            NotifyProperty("IsCircleChecked");
            NotifyProperty("IsRectangleChecked");
            UnCheckSlide();
        }

        // Line
        public void CheckLine()
        {
            CheckArrow();
            _model.ChangeState(DRAW);
            _selectButtonType = LINE;
            IsLineChecked = true;
            IsArrowChecked = false;
            
            NotifyProperty("IsLineChecked");
            NotifyProperty("IsArrowChecked");
        }

        // Circle
        public void CheckCircle()
        {
            CheckArrow();
            _model.ChangeState(DRAW);
            _selectButtonType = CIRCLE;
            IsCircleChecked = true;
            IsArrowChecked = false;
            
            NotifyProperty("IsCircleChecked");
            NotifyProperty("IsArrowChecked");
        }

        // Rectangle
        public void CheckRectangle()
        {
            CheckArrow();
            _model.ChangeState(DRAW);
            _selectButtonType = RECTANGLE;
            IsRectangleChecked = true;
            IsArrowChecked = false;
            
            NotifyProperty("IsRectangleChecked");
            NotifyProperty("IsArrowChecked");
        }

        // 遍歷 Sahpes
        public List<ShapeData> GetShapeData()
        {
            List<ShapeData> dataList = _model.GetShapeData(_currentSlideIndex);
            return dataList;
        }

        // 新增 shape
        public void CreateShape(string selectedShape)
        {
            _model.CreateShape(selectedShape, _currentSlideIndex);
            _model.IsFirstCreate = true;
        }

        // 刪除 shape
        public void DeleteShape(int rowIndex, int columnIndex, Keys keys)
        {
            if (IsSlideChecked)
            {
                return;
            }
            else if ((rowIndex != -1 && columnIndex == 0) || (keys == Keys.Delete))
            {
                _model.DeleteShape(rowIndex, _currentSlideIndex);
            }
        }

        // 壓下滑鼠
        public void PointerPressed(double x, double y)
        {
            _model.PressPointer(x, y, _selectButtonType, _currentSlideIndex);
        }

        // 放開滑鼠
        public void PointerReleased()
        {
            _model.ReleasePointer(_currentSlideIndex);
            _model.ChangeState(POINT);
            CheckArrow();
        }

        // 滑鼠移動
        public void PointerMoved(double x, double y)
        {
            _model.MovePointer(_currentSlideIndex, x, y);
        }

        // 清除
        public void ClearShapes()
        {
            _model.ClearShapes(_currentSlideIndex);
        }

        // 新增繪圖
        public void DrawPannel(FormsGraphicsAdaptor graphics, double rate)
        {
            _model.DrawPannel(graphics, rate, _currentSlideIndex);
        }

        // 新增繪圖
        public void DrawButton(FormsGraphicsAdaptor graphics, double rate, int index)
        {
            _model.DrawButton(graphics, rate, index);
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
            //_model.DeleteSelecetedShape();
        }

        // undo
        public void Undo()
        {
            _model.Undo();
        }

        // redo
        public void Redo()
        {
            _model.Redo();
        }

        // IsSelected
        public bool IsSelected()
        {
            return _model.IsSelected();
        }

        public void AddPage(int index)
        {
            _model.AddPage(index);
        }

        public void DeletePage(int index)
        {
            if (IsSlideChecked)
            {
                _model.DeletePage(index);
            }
        }

        public void CheckSlide()
        {
            IsSlideChecked = true;
        }

        public void UnCheckSlide()
        {
            IsSlideChecked = false;
        }

        public void SetOriginSlideIndex(int? index)
        {
            if (index == null)
            {
                return;
            }
            
            if(index < 0)
            {
                OriginSlideIndex = 0;
            }
            else
            {
                OriginSlideIndex = (int)index;
            }
        }

        public void SetCurrentSlideIndex(int? index)
        {
            if (index == null)
            {
                return;
            }

            if (index < 0)
            {
                _currentSlideIndex = 0;
            }
            else
            {
                _currentSlideIndex = (int)index;
            }
        }
    }
}