using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Power_Point
{
    public class ModifyCommand : ICommand
    {
        readonly Point _originPoint = new Point(0, 0);
        readonly Point _currentPoint = new Point(0, 0);
        readonly int _selectedIndex;
        private readonly PowerPointModel _model;
        int _index;

        public ModifyCommand(PowerPointModel model, Point originPoint, Point currentPoint, int selectedIndex, int index)
        {
            _model = model;
            _selectedIndex = selectedIndex;
            _originPoint = originPoint.CopyDeep();
            _currentPoint = currentPoint.CopyDeep();
            _index = index;
        }

        // Execute
        public void Execute()
        {
            _model.SetSelectedIndex(_selectedIndex, _index);
            _model.SetSelectedShapeSize(_currentPoint, _index);
            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _model.SetSelectedIndex(_selectedIndex, _index);
            _model.SetSelectedShapeSize(_originPoint, _index);
            _model.NotifyModelChanged();
        }
    }
}
