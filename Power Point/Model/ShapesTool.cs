using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    class ShapesTool
    {
        double _hintFirstPointX;
        double _hintFirstPointY;
        double _hintEndPointX;
        double _hintEndPointY;

        // GetPointX
        private double GetPointX(Point point, double width)
        {
            return point.X + width;
        }

        // GetPointY
        private double GetPointY(Point point, double height)
        {
            return point.Y + height;
        }

        // Get Point
        public Point GetPoint(Point point, double width, double height)
        {
            Point newPoint = new Point(GetPointX(point, width), GetPointY(point, height));
            return newPoint;
        }

        // 深度複製 Shapes
        public Shapes CopyDeep(Shapes newShapes, Shape temp, int index, bool isSelected)
        {
            newShapes.Temp = temp;
            newShapes.Hint = new Shape
            {
                FirstPoint = new Point(0, 0),
                EndPoint = new Point(0, 0)
            };
            newShapes.SelectedIndex = index;
            newShapes.IsSelected = isSelected;

            return newShapes;
        }

        // 設置形狀 x 座標
        private void SetShapePointX(Shape hint, Shape temp)
        {
            SetHintPoint(hint);
            if (hint.FirstPoint.X > _hintEndPointX)
            {
                temp.LeftTopPoint.X = _hintEndPointX;
                temp.RightBottomPoint.X = _hintFirstPointX;
            }
            else
            {
                temp.LeftTopPoint.X = _hintFirstPointX;
                temp.RightBottomPoint.X = _hintEndPointX;
            }
        }

        // Set Hint Point
        private void SetHintPoint(Shape hint)
        {
            _hintFirstPointX = hint.FirstPoint.X;
            _hintFirstPointY = hint.FirstPoint.Y;
            _hintEndPointX = hint.EndPoint.X;
            _hintEndPointY = hint.EndPoint.Y;
        }

        // 設置形狀 y 座標
        private void SetShapePointY(Shape hint, Shape temp)
        {
            SetHintPoint(hint);
            if (_hintFirstPointY > _hintEndPointY)
            {
                temp.LeftTopPoint.Y = _hintEndPointY;
                temp.RightBottomPoint.Y = _hintFirstPointY;
            }
            else
            {
                temp.LeftTopPoint.Y = _hintFirstPointY;
                temp.RightBottomPoint.Y = _hintEndPointY;
            }
        }

        // Set Shape Point
        public void SetShapePoint(Shape hint, Shape temp)
        {
            SetShapePointX(hint, temp);
            SetShapePointY(hint, temp);
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

        // IsTempPointXEqual
        private bool IsTempPointEqualX(Shape temp)
        {
            return GetPointX(temp.FirstPoint) != GetPointX(temp.EndPoint);
        }

        // IsTempPointXEqual
        private bool IsTempPointEqualY(Shape temp)
        {
            return GetPointY(temp.FirstPoint) != GetPointY(temp.EndPoint);
        }

        // temp
        public bool IsTempPointEqual(Shape temp)
        {
            if (IsTempPointEqualX(temp) || IsTempPointEqualY(temp))
            {
                return true;
            }
            return false;
        }
    }
}
