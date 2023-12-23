using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Power_Point
{
    public class DrawCommand : ICommand
    {
        private readonly string _shapeType;
        public double FirstPointX
        {
            get;
            set;
        }
        public double FirstPointY
        {
            get;
            set;
        }
        public double EndPointX
        {
            get;
            set;
        }
        public double EndPointY
        {
            get;
            set;
        }
        private readonly PowerPointModel _model;
        const string DRAW = "draw";
        private readonly Shapes _shapes; 

        public DrawCommand(PowerPointModel model, Point firstPoint, Point endPoint, string shapeType)
        {
            _model = model;
            _shapes = model._shapes;
            FirstPointX = firstPoint.X;
            FirstPointY = firstPoint.Y;
            EndPointX = endPoint.X;
            EndPointY = endPoint.Y;
            _shapeType = shapeType;
        }

        // Execute
        public void Execute()
        {
            _model.ChangeState(DRAW);
            _model._mouse.MouseDown(FirstPointX, FirstPointY, _shapeType);
            _model._mouse.MouseMove(EndPointX, EndPointY);
            _model._mouse.MouseUp();
            
            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _shapes.DeleteShape(GetTopIndex());
            _model.NotifyModelChanged();
        }

        // GetTopIndex
        private int GetTopIndex()
        {
            return _shapes.GetShapesSize - 1;
        }
    }
}
