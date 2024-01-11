using System;
using System.Collections.Generic;
using System.Text;

namespace Power_Point
{
    public class PowerPointModel
    {
        public IMouseState _mouse;
        public CommandManager _commandManager = new CommandManager();
        // 事件宣告
        // Pannel change
        public virtual event PannelChangedEventHandler ChangePannelEvent;
        public delegate void PannelChangedEventHandler();
        // Button change
        public virtual event ButtonChangedEventHandler ChangeButtonEvent;
        public delegate void ButtonChangedEventHandler();
        // Add page
        public virtual event PageAddEventHandler AddPageEvent;
        public delegate void PageAddEventHandler();
        // Delete page
        public virtual event PageDeleteEventHandler DeletePageEvent;
        public delegate void PageDeleteEventHandler();

        // 變數
        public Shapes _shapes = new Shapes();
        public Pages _pages = new Pages();
        private double FirstPointX;
        private double FirstPointY;
        private double EndPointX;
        private double EndPointY;

        public bool IsPressed
        {
            get;
            set;
        }

        public bool IsShapeSizable
        {
            get;
            set;
        }

        public int _originSlideIndex
        {
            get;
            set;
        }

        public int _currentSlideIndex
        {
            get;
            set;
        }

        const string DRAW = "draw";
        const string POINT = "point";
        const string MODIFY = "modify";

        public PowerPointModel()
        {
            IsPressed = false;
            IsFirstCreate = true;
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        public bool IsMoved
        {
            get;
            set;
        }

        public bool IsFirstCreate
        {
            get;
            set;
        }

        // AddDataGridViewShape
        public void AddDataGridViewShape(string shapeType, Point LeftTopPoint, Point RightBottomPoint, int index)
        {
            Shapes _originShapes = _pages.CopyDeep(index);
            _pages.AddDataGridViewShape(shapeType, LeftTopPoint, RightBottomPoint, index);
            Shapes _currentShapes = _pages.CopyDeep(index);
            _commandManager.Execute(
                new AddCommand(this, _originShapes, _currentShapes, index)
            );
        }



        // 將 shape 從 shapes 中刪除
        public void DeleteShape(int index, int slideIndex)
        {
            if (index == -1)
            {
                return;
            }
            SetIndex(index, slideIndex);
            Shapes _originShapes = _pages.CopyDeep(slideIndex);
            _pages.DeleteShape(index, slideIndex);
            Shapes _currentShapes = _pages.CopyDeep(slideIndex);
            _commandManager.Execute(
                new DeleteCommand(this, _originShapes, _currentShapes, slideIndex)
            );
        }

        // Set Index
        private void SetIndex(int index, int slideIndex)
        {
            if (index == -1)
            {
                _ = _pages.GetSelectedIndex(slideIndex);
            }
        }

        // 獲得 shapedata
        public List<ShapeData> GetShapeData(int index)
        {
            return _pages.GetShapeData(index);
        }

        // 清空 shapes
        public void ClearShapes(int index)
        {
            IsPressed = false;
            _pages.Clear(index);
            NotifyModelChanged();
        }

        // 滑鼠
        // 壓下滑鼠
        public void PressPointer(double pointX, double pointY, string shapeType, int index)
        {
            if (pointX > 0 && pointY > 0 && _mouse != null && shapeType != "Shape")
            {
                IsPressed = true;
                if (IsShapeSizable)
                {
                    ChangeState(MODIFY);
                }
                _mouse.MouseDown(pointX, pointY, shapeType, index);
                FirstPointX = pointX;
                FirstPointY = pointY;
                EndPointX = FirstPointX;
                EndPointY = FirstPointY;
            }
            NotifyModelChanged();
        }

        // 滑鼠移動
        public void MovePointer(int index, double pointX, double pointY)
        {
            if (IsPressed)
            {
                _mouse.MouseMove(pointX, pointY);
                IsMoved = false;
                EndPointX = pointX;
                EndPointY = pointY;
            }
            else
            {
                //IsShapeSizable = _shapes.IsInRightFloorPoint(pointX, pointY);
                IsShapeSizable = _pages.IsInRightFloorPoint(index, pointX, pointY);
            }

            NotifyModelChanged();
        }

        // 放開滑鼠
        public void ReleasePointer(int slideIndex)
        {
            if (IsPressed)
            {
                _ = new Point(FirstPointX, FirstPointY);
                Point endPoint = new Point(EndPointX, EndPointY);
                _shapes.SelectedIndex = _shapes.SelectShape(endPoint);
                //_pages.SetSelectedIndex(index)
                int index = _pages.SelectShape(slideIndex, endPoint);
                _pages.SetSelectedIndex(index, slideIndex);
                _mouse.MouseUp();
                IsPressed = false;
                NotifyModelChanged();
            }
        }

        // 畫布事件觸發
        // 通知 Handler，畫布狀態改變
        public void NotifyModelChanged()
        {
            ChangePannelEvent?.Invoke();
            ChangeButtonEvent?.Invoke();
        }

        // 更新畫面
        public void DrawPannel(IGraphics graphics, double rate, int index)
        {
            graphics.ClearAll();
            _pages.DrawShape(graphics, rate, index);
            if (_mouse is PointState)
            {
                _pages.DrawSelect(graphics, rate, index);
            }
        }

        // 繪畫縮圖
        public void DrawButton(IGraphics graphics, double rate, int index)
        {
            graphics.ClearAll();
            _pages.DrawButton(graphics, rate, index);
        }

        // 更改狀態
        public void ChangeState(string state)
        {
            switch (state)
            {
                case DRAW:
                    _mouse = new DrawState(this, _pages._pages[_currentSlideIndex]);
                    break;
                case POINT:
                    _mouse = new PointState(this, _pages._pages[_currentSlideIndex]);
                    break;
                case MODIFY:
                    _mouse = new ModifyState(this, _pages._pages[_currentSlideIndex]);
                    break;
            }
        }
        
        // 設置被選取的形狀索引
        public void SetSelectedIndex(int index, int slideIndex)
        {
            //_shapes.SelectedIndex = index;
            _pages.SetSelectedIndex(index, slideIndex);
        }

        // 設置被選取的形狀大小
        public void SetSelectedShapeSize(Point point, int slideIndex)
        {
            //_shapes.SetSelectedShapeSize(point.X, point.Y);
            _pages.SetSelectedShapeSize(slideIndex, point.X, point.Y);
        }

        // 設置形狀
        public void SetShapes(int index, Shapes shapes)
        {
            _pages.SetShapes(index, shapes);
        }

        // 設置被選取的形狀位置
        public void SetSelectedShapePosition(double width, double height, int index)
        {
            _pages.SetSelectedShapePosition(width, height, index);
        }

        // Undo
        public void Undo()
        {
            _commandManager.Undo();
        }

        // Redo
        public void Redo()
        {
            _commandManager.Redo();
        }

        // IsSelected
        public bool IsSelected()
        {
            return _shapes.IsSelected;
        }

        public void AddPage(int index)
        {
            _pages.AddPage(index);
            NotifySlideAdd();
        }

        public void DeletePage(int index)
        {
            _pages.DeletePage(index);
            NotifySlideDelete();
        }

        public void NotifySlideAdd()
        {
            AddPageEvent?.Invoke();
        }

        public void NotifySlideDelete()
        {
            DeletePageEvent?.Invoke();
        }

        public void UnSelected(int index)
        {
            _pages.UnSelected(index);
        }
    }
}

