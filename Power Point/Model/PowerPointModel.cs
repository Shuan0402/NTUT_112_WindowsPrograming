using System;
using System.Collections.Generic;
using System.Text;

namespace Power_Point
{
    public class PowerPointModel
    {
        private IMouseState _mouse;
        // 事件宣告
        // Pannel change
        public event PannelChangedEventHandler ChangePannelEvent;
        public delegate void PannelChangedEventHandler();
        // Button change
        public event ButtonChangedEventHandler ChangeButtonEvent;
        public delegate void ButtonChangedEventHandler();

        // 變數
        readonly Shapes _shapes = new Shapes();
        bool _isPressed = false;

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
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        // 滑鼠
        // 壓下滑鼠
        public void PressPointer(double pointX, double pointY, string shapeType)
        {
            if (pointX > 0 && pointY > 0 && _mouse != null)
            {
                _isPressed = true;
                _mouse.MousePress(pointX, pointY, shapeType);
            }
            NotifyModelChanged();
        }

        // 滑鼠移動
        public void MovePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _mouse.MouseMove(pointX, pointY);
                NotifyModelChanged();
            }
        }

        // 放開滑鼠
        public void ReleasePointer(double pointX, double pointY, string shapeType)
        {
            if (_isPressed)
            {
                if (shapeType == null)
                {
                    _mouse.MouseUp(pointX, pointY, shapeType);
                }
                else
                {
                    _shapes.SetGraph(shapeType);
                    _mouse.MouseUp(pointX, pointY, shapeType);
                    _shapes.InitializeHint();
                }
                _isPressed = false;
                NotifyModelChanged();
            }
        }
    
        // 畫布事件觸發
        // 通知 Handler，畫布狀態改變
        void NotifyModelChanged()
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
            if (state == "draw")
            {
                _mouse = new DrawState(_shapes);
            }
            else if (state == "point")
            {
                _mouse = new PointState(_shapes);
            }
        }
    }
}

