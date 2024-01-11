using System;
using System.Collections.Generic;
using System.Text;

namespace Power_Point
{
    public interface IMouseState
    {
        // 壓下滑鼠
        void MouseDown(double pointX, double pointY, string shapeType, int index);
        // 放開滑鼠
        void MouseUp();
        // 移動滑鼠
        void MouseMove(double pointX, double pointY);
    }
}
