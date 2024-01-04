using System;
using System.Drawing;

namespace Power_Point
{
    public class AddCommand : ICommand
    {
        private readonly PowerPointModel _model;
        Shapes _originShapes;
        Shapes _currentShapes;

        public AddCommand(PowerPointModel model, Shapes originShapes, Shapes currentShapes)
        {
            _model = model;
            _originShapes = originShapes.DeepCopy();
            _currentShapes = currentShapes.DeepCopy();
        }

        // Execute
        public void Execute()
        {
            _model.SetShapes(_currentShapes);
            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _model.SetShapes(_originShapes);
            _model.NotifyModelChanged();
        }
    }
}
