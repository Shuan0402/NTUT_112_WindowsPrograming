using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Power_Point
{
    public class MoveCommand : ICommand
    {
        private readonly Point _originPoint;
        private readonly Point _currentPoint;
        private readonly PowerPointModel _model;
        double _width;
        double _height;
        const string POINT = "point";
        private readonly Shapes _shapes;
        public int Index
        {
            get;
            set;
        }

        public MoveCommand(PowerPointModel model, Point originPoint, Point currentPoint, int index)
        {
            _model = model;
            _shapes = model._shapes;
            _originPoint = originPoint;
            _currentPoint = currentPoint;
            Index = index;
        }

        // Execute
        public void Execute()
        {
            _model.ChangeState(POINT);
            SetWidth();
            SetHeight();
            if (_model.IsMoved)
            {
                _shapes.SetShape(Index, _width, _height);
            }
            else
            {
                _model.IsMoved = true;
            }

            _model.NotifyModelChanged();
        }

        // SetWidth
        private void SetWidth()
        {
            _width = GetCurrentPointX() - GetOriginPointX();
        }

        // SetHeight
        private void SetHeight()
        {
            _height = GetCurrentPointY() - GetOriginPointY();
        }

        // GetCurrentPoint
        private double GetCurrentPointX()
        {
            return _currentPoint.X;
        }

        // GetCurrentPoint
        private double GetCurrentPointY()
        {
            return _currentPoint.Y;
        }

        // GetCurrentPoint
        private double GetOriginPointX()
        {
            return _originPoint.X;
        }

        // GetCurrentPoint
        private double GetOriginPointY()
        {
            return _originPoint.Y;
        }

        // Revoke
        public void Revoke()
        {
            _model.ChangeState(POINT);
            _model._shapes.SetShape(Index, -_width, -_height);
            if (!_model.IsMoved)
            {
                _model.IsMoved = true;
            }
            _model.NotifyModelChanged();
        }
    }
}
