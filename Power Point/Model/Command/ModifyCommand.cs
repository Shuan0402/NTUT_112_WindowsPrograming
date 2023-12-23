using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Power_Point
{
    public class ModifyCommand : ICommand
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
        public int Index
        {
            get;
            set;
        }

        const string MODIFY = "modify";

        public ModifyCommand(PowerPointModel model, Point firstPoint, Point endPoint, string shapeType)
        {
            _model = model;
            FirstPointX = firstPoint.X;
            FirstPointY = firstPoint.Y;
            EndPointX = endPoint.X;
            EndPointY = endPoint.Y;
            _shapeType = shapeType;
            Index = _model._shapes.SelectedIndex;
        }

        // Execute
        public void Execute()
        {
            _model.ChangeState(MODIFY);
            _model._shapes.SelectedIndex = Index;
            _model._mouse.MouseDown(FirstPointX, FirstPointY, _shapeType);
            _model._mouse.MouseMove(EndPointX, EndPointY);
            _model._mouse.MouseUp();

            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _model.ChangeState(MODIFY);
            _model._shapes.SelectedIndex = Index;
            _model._mouse.MouseDown(EndPointX, EndPointY, _shapeType);
            _model._mouse.MouseMove(FirstPointX, FirstPointY);
            _model._mouse.MouseUp();
            _model.NotifyModelChanged();
        }
    }
}
