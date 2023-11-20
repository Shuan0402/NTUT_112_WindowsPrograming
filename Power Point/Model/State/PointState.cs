using System;

namespace Power_Point
{
    public class PointState : IMouseState
    {

        private readonly Shapes _shapes;
        private double _firstPointX;
        private double _firstPointY;
        private double _endPointX;
        private double _endPointY;

        public PointState(Shapes shapes)
        {
            this._shapes = shapes;
        }

        // 壓下滑鼠-選取
        public void MousePress(double pointX, double pointY, string shapeType)
        {
            Point point = new Point(pointX, pointY);
            _shapes.SelectShape(point);
            _firstPointX = pointX;
            _firstPointY = pointY;
        }

        // 放開滑鼠-選取
        public void MouseUp(double pointX, double pointY, string shapeType)
        {
        }

        // 移動滑鼠-選取
        public void MouseMove(double pointX, double pointY)
        {
            _endPointX = pointX;
            _endPointY = pointY;
            _shapes.SetShape(_endPointX - _firstPointX, _endPointY - _firstPointY);
            _firstPointX = _endPointX;
            _firstPointY = _endPointY;
        }

        // 回傳起點
        public Point GetFirstPoint()
        {
            return new Point(0, 0);
        }
    }
}
