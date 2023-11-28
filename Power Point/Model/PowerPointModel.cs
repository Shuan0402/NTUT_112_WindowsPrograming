using System;
using System.Collections.Generic;
using System.Text;

namespace Power_Point
{
    public class PowerPointModel
    {
        public IMouseState _mouse;
        // 事件宣告
        // Pannel change
        public virtual event PannelChangedEventHandler ChangePannelEvent;
        public delegate void PannelChangedEventHandler();
        // Button change
        public virtual event ButtonChangedEventHandler ChangeButtonEvent;
        public delegate void ButtonChangedEventHandler();

        // 變數
        public Shapes _shapes = new Shapes();

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

        public PowerPointModel()
        {
            IsPressed = false;
            //IsShapeSizable = false;
        } 

        // List<Shape> 管理
        // 將 shape 加入 shapes 中
        public void CreateShape(string shapeType)
        {
            _shapes.CreateShape(shapeType);
            NotifyModelChanged();
        }

        // 將 shape 從 shapes 中刪除
        public void DeleteShape(int index)
        {
            _shapes.DeleteShape(index);
            NotifyModelChanged();
        }

        // 刪除所選形狀
        public void DeleteSelecetedShape()
        {
            _shapes.DeleteSelectedShape();
            NotifyModelChanged();
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
            if (pointX > 0 && pointY > 0 && _mouse != null)
            {
                IsPressed = true;
                if (IsShapeSizable)
                {
                    ChangeState(MODIFY);
                }
                _mouse.MouseDown(pointX, pointY, shapeType);
            }
            NotifyModelChanged();
        }

        // 滑鼠移動
        public void MovePointer(double pointX, double pointY)
        {
            if (IsPressed)
            {
                _mouse.MouseMove(pointX, pointY);
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
        public void DrawPannel(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.DrawShape(graphics);
            if (_mouse is PointState)
            {
                _shapes.DrawSelect(graphics);
            }
        }

        // 繪畫縮圖
        public void DrawButton(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.DrawButtonShape(graphics);
        }

        // 更改狀態
        public void ChangeState(string state)
        {
            switch (state)
            {
                case DRAW:
                    _mouse = new DrawState(_shapes);
                    break;
                case POINT:
                    _mouse = new PointState(_shapes);
                    break;
                case MODIFY:
                    _mouse = new ModifyState(_shapes);
                    break;
            }
        }
    }
}

