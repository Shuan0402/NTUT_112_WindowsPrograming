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

        // 變數
        public Shapes _shapes = new Shapes();
        private double FirstPointX;
        private double FirstPointY;
        private double EndPointX;
        private double EndPointY;
        private string ShapeType;

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


        const string DRAW = "draw";
        const string POINT = "point";
        const string MODIFY = "modify";
        const int MINUS_ONE = -1;

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

        // List<Shape> 管理
        // 將 shape 加入 shapes 中
        public void CreateShape(string shapeType)
        {
            Shapes _originShapes = _shapes.DeepCopy();
            _shapes.CreateShape(shapeType);
            Shapes _currentShapes = _shapes.DeepCopy();
            _commandManager.Execute(
              new AddCommand(this, _originShapes, _currentShapes)
            );
        }

        // 將 shape 從 shapes 中刪除
        public void DeleteShape(int index)
        {
            if (index == -1)
            {
                index = _shapes.SelectedIndex;
            }
            Shapes _originShapes = _shapes.DeepCopy();
            _shapes.DeleteShape(index);
            Shapes _currentShapes = _shapes.DeepCopy();
            _commandManager.Execute(
              new DeleteCommand(this, _originShapes, _currentShapes)
            );
        }

        // 刪除所選形狀
        public void DeleteSelecetedShape()
        {
            Shapes _originShapes = _shapes.DeepCopy();
            _shapes.DeleteSelectedShape();
            Shapes _currentShapes = _shapes.DeepCopy();
            _commandManager.Execute(
              new DeleteCommand(this, _originShapes, _currentShapes)
            );
        }

        // 獲得 shapedata
        public List<ShapeData> GetShapeData()
        {
            return _shapes.GetShapeData();
        }

        // 清空 shapes
        public void ClearShapes()
        {
            IsPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        // 滑鼠
        // 壓下滑鼠
        public void PressPointer(double pointX, double pointY, string shapeType)
        {
            if (pointX > 0 && pointY > 0 && _mouse != null && shapeType != "Shape")
            {
                IsPressed = true;
                if (IsShapeSizable)
                {
                    ChangeState(MODIFY);
                }
                _mouse.MouseDown(pointX, pointY, shapeType);
                FirstPointX = pointX;
                FirstPointY = pointY;
                EndPointX = FirstPointX;
                EndPointY = FirstPointY;
                ShapeType = shapeType;
            }
            NotifyModelChanged();
        }

        // 滑鼠移動
        public void MovePointer(double pointX, double pointY)
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
                IsShapeSizable = _shapes.IsInRightFloorPoint(pointX, pointY);
            }

            NotifyModelChanged();
        }

        // 放開滑鼠
        public void ReleasePointer()
        {
            if (IsPressed)
            {
                Point firstPoint = new Point(FirstPointX, FirstPointY);
                Point endPoint = new Point(EndPointX, EndPointY);
                _shapes.SelectedIndex = _shapes.SelectShape(endPoint);
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
        public void DrawPannel(IGraphics graphics, double rate)
        {
            graphics.ClearAll();
            _shapes.DrawShape(graphics, rate);
            if (_mouse is PointState)
            {
                _shapes.DrawSelect(graphics, rate);
            }
        }

        // 繪畫縮圖
        public void DrawButton(IGraphics graphics, double rate)
        {
            graphics.ClearAll();
            _shapes.DrawButtonShape(graphics, rate);
        }

        // 更改狀態
        public void ChangeState(string state)
        {
            switch (state)
            {
                case DRAW:
                    _mouse = new DrawState(this);
                    break;
                case POINT:
                    _mouse = new PointState(this);
                    break;
                case MODIFY:
                    _mouse = new ModifyState(this);
                    break;
            }
        }

        public void SetSelectedIndex(int index)
        {
            _shapes.SelectedIndex = index;
        }

        public void SetSelectedShapeSize(Point point)
        {
            _shapes.SetSelectedShapeSize(point.X, point.Y);
        }

        public void SetShapes(Shapes shapes)
        {
            _shapes = shapes.DeepCopy();
        }

        public void SetSelectedShapePosition(double width, double height)
        {
            _shapes.SetSelectedShapePosition(width, height);
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

    }
}

