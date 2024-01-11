using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Power_Point
{
    public class MoveCommand : ICommand
    {
        readonly PowerPointModel _model;
        readonly Shapes _originShapes;
        readonly Shapes _currentShapes;
        int _index;

        public MoveCommand(PowerPointModel model, Shapes originShapes, Shapes currentShapes, int index)
        {
            _model = model;
            _originShapes = originShapes.CopyDeep();
            _currentShapes = currentShapes.CopyDeep();
            _index = index;
        }

        // Execute
        public void Execute()
        {
            _model.SetShapes(_index, _currentShapes);
            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _model.SetShapes(_index, _originShapes);
            _model.NotifyModelChanged();
        }
    }
}
