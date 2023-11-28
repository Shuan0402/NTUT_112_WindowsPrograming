using System;

namespace Power_Point
{
    public class PointState : IMouseState
    {

        private readonly Shapes _shapes;
        Point _point = new Point(0, 0);
        private double _firstPointX;
        private double _firstPointY;
        private double _endPointX;
        private double _endPointY;

        public PointState(Shapes shapes)
        {
            this._shapes = shapes;
        }

        // 壓下滑鼠-選取
        public void MouseDown(double pointX, double pointY, string shapeType)
        {
            _point = new Point(pointX, pointY);
            _shapes.SelectShape(_point);
            _firstPointX = pointX;
            _firstPointY = pointY;
        }

        // 移動滑鼠-選取
        public void MouseMove(double pointX, double pointY)
        {
            _point = new Point(pointX, pointY);
            _endPointX = _point.X;
            _endPointY = _point.Y;
            _shapes.SetSelectedShapePosition(_endPointX - _firstPointX, _endPointY - _firstPointY);
            _firstPointX = _endPointX;
            _firstPointY = _endPointY;
        }

        // 放開滑鼠-選取
        public void MouseUp()
        {
        }
    }
}
