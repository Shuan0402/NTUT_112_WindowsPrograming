using System;
using System.Collections.Generic;

namespace Power_Point
{
    public class DrawState : IMouseState
    {
        private readonly Shapes _shapes;
        public double FirstPointX
        {
            get;
            set;
        }
        public double FirstPointY
        {
            get;
            set;
        }

        // 常數
        const string FIRST = "first";
        const string END = "end";

        public DrawState(Shapes shapes)
        {
            this._shapes = shapes;
        }

        // 壓下滑鼠-繪畫
        public void MouseDown(double pointX, double pointY, string shapeType)
        {
            FirstPointX = pointX;
            FirstPointY = pointY;
            _shapes.SetHintType(shapeType);
            _shapes.SetHint(FirstPointX, FirstPointY, FIRST);
            _shapes.SetHint(FirstPointX, FirstPointY, END);
        }

        // 滑鼠移動-繪畫
        public void MouseMove(double pointX, double pointY)
        {
            _shapes.SetHint(pointX, pointY, END);
        }

        // 放開滑鼠-繪畫
        public void MouseUp()
        {
            _shapes.SetGraph();
            _shapes.InitializeHint();
        }
    }

}
