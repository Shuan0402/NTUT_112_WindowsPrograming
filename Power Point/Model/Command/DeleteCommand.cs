using System;
using System.Drawing;

namespace Power_Point
{
    public class DeleteCommand : ICommand
    {
        public int Index
        {
            get;
            set;
        }

        private readonly PowerPointModel _model;
        ShapeData _shape;
        public DeleteCommand(PowerPointModel model, int index)
        {
            Index = index;
            _model = model;
        }

        // Execute
        public void Execute()
        {
            _shape = _model._shapes.GetShapeData()[Index];
            _model._shapes.DeleteShape(Index);
            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _model._shapes.CreateShape(_shape.Name);
            _model._shapes.SetTopShapeInfo(_shape.Info);
            _model.NotifyModelChanged();
        }
    }
}
