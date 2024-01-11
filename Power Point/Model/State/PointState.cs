using System;

namespace Power_Point
{
    public class PointState : IMouseState
    {
        readonly PowerPointModel _model;
        Shapes _originShapes;
        Shapes _currentShapes;
        private readonly Shapes _shapes;
        Point _point = new Point(0, 0);
        private double _firstPointX;
        private double _firstPointY;
        private double _endPointX;
        private double _endPointY;
        Point _currentPoint = new Point(0, 0);
        Point _originPoint = new Point(0, 0);
        int _index;

        public PointState(PowerPointModel model, Shapes shapes)
        {
            _model = model;
            _shapes = shapes;
        }

        // 壓下滑鼠-選取
        public void MouseDown(double pointX, double pointY, string shapeType, int index)
        {
            _originShapes = _shapes.CopyDeep();
            _currentShapes = _shapes.CopyDeep();
            _point = new Point(pointX, pointY);
            _shapes.SelectShape(_point);
            _firstPointX = pointX;
            _firstPointY = pointY;
            _originPoint = _point.CopyDeep();
            _currentPoint = _point.CopyDeep();
            _index = index;
        }

        // 移動滑鼠-選取
        public void MouseMove(double pointX, double pointY)
        {
            _point = new Point(pointX, pointY);
            _endPointX = _point.X;
            _endPointY = _point.Y;
            _model.SetSelectedShapePosition(_endPointX - _firstPointX, _endPointY - _firstPointY, _index);
            _firstPointX = _endPointX;
            _firstPointY = _endPointY;
            _currentPoint = _point.CopyDeep();
        }

        // 放開滑鼠-選取
        public void MouseUp()
        {
            _currentShapes = _shapes.CopyDeep();
            if (_originPoint.X != _currentPoint.X || _originPoint.Y != _currentPoint.Y)
            {
                _model._commandManager.Execute(
                    new MoveCommand(_model, _originShapes, _currentShapes, _index)
                );
            }
            _model.NotifyModelChanged();
        }
    }
}
