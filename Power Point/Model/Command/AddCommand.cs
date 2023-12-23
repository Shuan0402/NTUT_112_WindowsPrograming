using System;
using System.Drawing;

namespace Power_Point
{
    public class AddCommand : ICommand
    {
        private readonly string _shapeType;
        private readonly PowerPointModel _model;
        private string _info;
        private readonly Shapes _shapes;
        public AddCommand(PowerPointModel model, string shapeType)
        {
            _shapeType = shapeType;
            _model = model;
            _shapes = model._shapes;
        }

        // Execute
        public void Execute()
        {
            _shapes.CreateShape(_shapeType);
            _shapes.SetTopShapeInfo(_info);
            if (_model.IsFirstCreate)
            {
                _info = _shapes.GetTopShapeInfo();
                _model.IsFirstCreate = false;
            }
            else
            {
                _shapes.SetTopShapeInfo(_info);
            }
            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _info = _shapes.GetShapeData()[GetTopIndex()].Info;
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
