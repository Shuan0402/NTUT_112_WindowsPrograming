using System;
using System.Collections.Generic;
using System.Linq;

namespace Power_Point
{
    public class Shapes
    {
        // 變數
        private readonly List<Shape> _shapes = new List<Shape>();
        private readonly ShapeFactory _shapeFactory = new ShapeFactory();
        private Shape _temp;
        private Shape _hint = new Shape();

        // 常數
        const string FIRST = "first";
        const string END = "end";
        const string SHAPE = "Shape";
        const int FIVE = 5;
        const int ZERO = 0;
        //const int MINUS_ONE = -1;

        public Shapes()
        {
        }

        public int SelectedIndex
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }

        // 新增形狀
        public void CreateShape(string shape) 
        {
            _temp = _shapeFactory.CreateShape(shape);
            _shapes.Add(_temp);
        }

        // 刪除形狀
        public void DeleteShape(int index)
        {
            if (IsSelected)
            {
                IsSelected = false;
                SelectedIndex = -1;
            }
            _shapes.RemoveAt(index);
        }

        // 刪除選取形狀
        public void DeleteSelectedShape()
        {
            if (IsSelected)
            {
                _shapes.RemoveAt(SelectedIndex);
            }
            IsSelected = false;
            SelectedIndex = -1;
        }

        // 選取形狀
        public int SelectShape(Point point)
        {
            SelectedIndex = -1;
            IsSelected = false;
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].SelectShape(point))
                {
                    SelectedIndex = i ;
                    IsSelected = true;
                    break;
                }
            }
            return SelectedIndex;
        }

        // 將 shapes 中所有 shape 存進 shapedata 中
        public List<ShapeData> GetShapeData()
        {
            return _shapes.ConvertAll(Shape => new ShapeData(Shape.Name, Shape.Info));
        }

        // 設定 hint 的型態
        public void SetHintType(string hintType)
        {
            _hint = _shapeFactory.CreateShape(hintType);
        }

        // 設定 hint 的座標
        public void SetHint(double pointX, double pointY, string pointType)
        {
            switch (pointType)
            {
                case FIRST:
                    _hint.FirstPoint = new Point(pointX, pointY);
                    break;
                case END:
                    _hint.EndPoint = new Point(pointX, pointY);
                    break;
            }
        }

        // 初始化 hint
        public void InitializeHint()
        {
            _hint = new Shape();
        }

        // 將所有 shapes 中的 shape 都畫在畫布上
        public void DrawShape(IGraphics graphics)
        {
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (_hint.Name != SHAPE)
            {
                DrawHint(graphics);
            }
        }

        // Draw hint
        private void DrawHint(IGraphics graphics)
        {
            _hint.Draw(graphics);
        }

        // 繪製選取
        public void DrawSelect(IGraphics graphics)
        {
            if (IsSelected && SelectedIndex >= ZERO)
            {
                _shapes[SelectedIndex].DrawSelect(graphics);
            }
        }

        // 將所有 shapes 中的 shape 都畫在縮圖上
        public void DrawButtonShape(IGraphics graphics)
        {
            foreach (Shape aShape in _shapes)
                aShape.DrawButton(graphics);
        }

        // 新增繪製形狀
        public void SetGraph() 
        {
            _temp = _shapeFactory.CreateShape(_hint.Name);
            _temp.FirstPoint = _hint.FirstPoint;
            _temp.EndPoint = _hint.EndPoint;
            _shapes.Add(_temp);
        }

        // 清除畫面
        public void Clear()
        {
            _shapes.Clear();
        }

        // 更新形狀位置
        public void SetSelectedShapePosition(double width, double height)
        {
            if (IsSelected)
            {
                Point _newFirstPoint = new Point(_shapes[SelectedIndex].FirstPoint.X + width, _shapes[SelectedIndex].FirstPoint.Y + height);
                Point _newEndPoint = new Point(_shapes[SelectedIndex].EndPoint.X + width, _shapes[SelectedIndex].EndPoint.Y + height);
                _shapes[SelectedIndex].FirstPoint = _newFirstPoint;
                _shapes[SelectedIndex].EndPoint = _newEndPoint;
            }
        }

        // 更新形狀大小
        public void SetSelectedShapeSize(double pointX, double pointY)
        {
            if (_shapes[SelectedIndex].FirstPoint.X > _shapes[SelectedIndex].EndPoint.X)
            {
                _shapes[SelectedIndex].FirstPoint.X = pointX;
            }
            else
            {
                _shapes[SelectedIndex].EndPoint.X = pointX;
            }

            if (_shapes[SelectedIndex].FirstPoint.Y > _shapes[SelectedIndex].EndPoint.Y)
            {
                _shapes[SelectedIndex].FirstPoint.Y = pointY;
            }
            else
            {
                _shapes[SelectedIndex].EndPoint.Y = pointY;
            }
        }

        // 回傳是否在調整形狀大小的形狀範圍位置上
        public bool IsInRightFloorPoint(double pointX, double pointY)
        {
            if (IsSelected)
            {
                return (pointX >= GetRightFloorPoint().X - FIVE &&
                        pointX <= GetRightFloorPoint().X + FIVE &&
                        pointY >= GetRightFloorPoint().Y - FIVE &&
                        pointY <= GetRightFloorPoint().Y + FIVE);
            }
            else
            {
                return false;
            }
        }

        // GetRightFloorPoint
        public Point GetRightFloorPoint()
        {
            Point point = new Point(GetMaxPointX(), GetMaxPointY());
            return point;
        }

        // 獲得終點 X 座標
        private float GetMaxPointX()
        {
            return Math.Max((float)_shapes[SelectedIndex].FirstPoint.X, (float)_shapes[SelectedIndex].EndPoint.X);
        }

        // 獲得終點 Y 座標
        private float GetMaxPointY()
        {
            return Math.Max((float)_shapes[SelectedIndex].FirstPoint.Y, (float)_shapes[SelectedIndex].EndPoint.Y);
        }
    }
}

