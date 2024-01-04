using System;

namespace Power_Point
{
    public class ModifyState : IMouseState
    {
        PowerPointModel _model;
        private readonly Shapes _shapes;
        Point _originPoint = new Point(0, 0);
        Point _currentPoint = new Point(0, 0);
        int _selectedIndex;

        Shapes originShapes;

        public ModifyState(PowerPointModel model)
        {
            this._model = model;
            this._shapes = model._shapes;
        }

        // 壓下滑鼠-選取
        public void MouseDown(double pointX, double pointY, string shapeType)
        {
            _originPoint = _shapes.GetSelectedShapePoint().DeepCopy();
            _selectedIndex = _shapes.SelectedIndex;
        }

        // 移動滑鼠-選取
        public void MouseMove(double pointX, double pointY)
        {
            _shapes.SetSelectedShapeSize(pointX, pointY);

            _currentPoint.X = pointX;
            _currentPoint.Y = pointY;
        }

        // 放開滑鼠-選取
        public void MouseUp()
        {
            Shapes currentShapes = _shapes.DeepCopy();
            _model._commandManager.Execute(
                new ModifyCommand(_model, _originPoint, _currentPoint, _selectedIndex)
            );

            _model.NotifyModelChanged();
        }
    }
}
