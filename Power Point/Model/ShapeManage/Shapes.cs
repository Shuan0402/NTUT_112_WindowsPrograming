using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        const int ONE = 1;
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;

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

        public int GetShapesSize
        {
            get
            {
                return _shapes.Count;
            }
        }

        // GetReccentShapeInfo
        public string GetTopShapeInfo()
        {
            return _temp.Info;
        }

        // SetReccentShapeInfo
        public void SetTopShapeInfo(string info)
        {
            if (info == null)
            {
                return;
            }
            string pattern = @"\((\w+), (\w+)\), \((\w+), (\w+)\)";
            Match match = Regex.Match(info, pattern);
            int pointOne = int.Parse(match.Groups[ONE].Value);
            int pointTwo = int.Parse(match.Groups[TWO].Value);
            int pointThree = int.Parse(match.Groups[THREE].Value);
            int pointFour = int.Parse(match.Groups[FOUR].Value);

            Point firstPoint = new Point(pointOne, pointTwo);
            Point endPoint = new Point(pointThree, pointFour);

            _shapes[_shapes.Count - 1].FirstPoint = firstPoint;
            _shapes[_shapes.Count - 1].EndPoint = endPoint;
        }

        // 新增形狀
        public string CreateShape(string shape) 
        {
            _temp = _shapeFactory.CreateShape(shape);
            _shapes.Add(_temp);
            return _temp.Info;
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
        public void DrawShape(IGraphics graphics, double rate)
        {
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics, rate);
            if (_hint.Name != SHAPE)
            {
                DrawHint(graphics, rate);
            }
        }

        // Draw hint
        private void DrawHint(IGraphics graphics, double rate)
        {
            _hint.Draw(graphics, rate);
        }

        // 繪製選取
        public void DrawSelect(IGraphics graphics, double rate)
        {
            if (IsSelected && SelectedIndex >= ZERO)
            {
                _shapes[SelectedIndex].DrawSelect(graphics, rate);
            }
        }

        // 將所有 shapes 中的 shape 都畫在縮圖上
        public void DrawButtonShape(IGraphics graphics, double rate)
        {
            foreach (Shape aShape in _shapes)
                aShape.DrawButton(graphics, rate);
        }

        // 新增繪製形狀
        public void SetGraph() 
        {
            _temp = _shapeFactory.CreateShape(_hint.Name);
            _temp.FirstPoint = _hint.FirstPoint;
            _temp.EndPoint = _hint.EndPoint;
            if (_temp.Name != SHAPE)
            {
                if (IsTempPointEqualX() || IsTempPointEqualY())
                {
                    _shapes.Add(_temp);
                }
            }
        }

        // IsTempPointXEqual
        private bool IsTempPointEqualX()
        {
            return GetPointX(_temp.FirstPoint) != GetPointX(_temp.EndPoint);
        }

        // IsTempPointXEqual
        private bool IsTempPointEqualY()
        {
            return GetPointY(_temp.FirstPoint) != GetPointY(_temp.EndPoint);
        }

        // GetPointX
        private double GetPointX(Point point)
        {
            return point.X;
        }

        // GetPointY
        private double GetPointY(Point point)
        {
            return point.Y;
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

        // SetShape
        public void SetShape(int index, double pointX, double pointY)
        {
            if (index >= 0)
            {
                Point firstPoint = _shapes[index].FirstPoint;
                Point endPoint = _shapes[index].EndPoint;

                _shapes[index].FirstPoint = new Point(GetPointX(firstPoint, pointX), GetPointY(firstPoint, pointY));
                _shapes[index].EndPoint = new Point(GetPointX(endPoint, pointX), GetPointY(endPoint, pointY));
            }
        }

        // GetPoint
        private double GetPointX(Point point, double width)
        {
            return point.X + width;
        }

        // GetPoint
        private double GetPointY(Point point, double height)
        {
            return point.Y + height;
        }
    }
}

