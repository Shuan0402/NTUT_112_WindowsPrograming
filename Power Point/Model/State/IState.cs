using System;
using System.Collections.Generic;
using System.Text;

namespace Power_Point
{
    public interface IMouseState
    {
        // 壓下滑鼠
        void MousePress(double pointX, double pointY, string shapeType);
        // 放開滑鼠
        void MouseUp(double pointX, double pointY, string shapeType);
        // 移動滑鼠
        void MouseMove(double pointX, double pointY);
        // 回傳起點
        Point GetFirstPoint();
    }
}
