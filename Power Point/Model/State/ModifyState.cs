using System;

namespace Power_Point
{
    public class ModifyState : IMouseState
    {
        readonly PowerPointModel _model;
        private readonly Shapes _shapes;
        Point _originPoint;// = new Point(0, 0);
        Point _currentPoint;// = new Point(0, 0);
        int _selectedIndex;
        int _index;

        public ModifyState(PowerPointModel model, Shapes shapes)
        {
            _model = model;
            _shapes = shapes;
        }

        // 壓下滑鼠-選取
        public void MouseDown(double pointX, double pointY, string shapeType, int index)
        {
            _originPoint = _shapes.GetSelectedShapePoint().CopyDeep();
            _currentPoint = _originPoint.CopyDeep();
            _selectedIndex = _shapes.SelectedIndex;
            _index = index;
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
            _ = _shapes.CopyDeep();
            _model._commandManager.Execute(
                new ModifyCommand(_model, _originPoint, _currentPoint, _selectedIndex, _index)
            );

            _model.NotifyModelChanged();
        }
    }
}
