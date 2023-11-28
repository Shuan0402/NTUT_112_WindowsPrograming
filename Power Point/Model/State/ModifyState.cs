using System;

namespace Power_Point
{
    public class ModifyState : IMouseState
    {

        private readonly Shapes _shapes;

        public ModifyState(Shapes shapes)
        {
            this._shapes = shapes;
        }

        // 壓下滑鼠-選取
        public void MouseDown(double pointX, double pointY, string shapeType)
        {
        }

        // 移動滑鼠-選取
        public void MouseMove(double pointX, double pointY)
        {
            _shapes.SetSelectedShapeSize(pointX, pointY);
        }

        // 放開滑鼠-選取
        public void MouseUp()
        {
        }
    }
}
