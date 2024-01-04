using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Power_Point
{
    public class ModifyCommand : ICommand
    {
        Point _originPoint = new Point(0, 0);
        Point _currentPoint = new Point(0, 0);
        Shapes _shapes;
        int _selectedIndex;
        private readonly PowerPointModel _model;

        const string MODIFY = "modify";

        public ModifyCommand(PowerPointModel model, Point originPoint, Point currentPoint, int index)
        {
            _model = model;
            _shapes = model._shapes;
            _selectedIndex = index;
            _originPoint = originPoint.DeepCopy();
            _currentPoint = currentPoint.DeepCopy();
        }

        // Execute
        public void Execute()
        {
            _model.SetSelectedIndex(_selectedIndex);
            _model.SetSelectedShapeSize(_currentPoint);
            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _model.SetSelectedIndex(_selectedIndex);
            _model.SetSelectedShapeSize(_originPoint);
            _model.NotifyModelChanged();
        }
    }
}
