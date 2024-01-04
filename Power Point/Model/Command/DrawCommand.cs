using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Power_Point
{
    public class DrawCommand : ICommand
    {
        PowerPointModel _model;
        Shapes _originShapes;
        Shapes _currentShapes;
        public DrawCommand(PowerPointModel model, Shapes originShapes, Shapes currentShapes)
        {
            _model = model;
            _originShapes = originShapes.DeepCopy();
            _currentShapes = currentShapes.DeepCopy();
        }

        // Execute
        public void Execute()
        {
            _model._shapes = _currentShapes.DeepCopy();
            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _model._shapes = _originShapes.DeepCopy();
            _model.NotifyModelChanged();
        }
    }
}
