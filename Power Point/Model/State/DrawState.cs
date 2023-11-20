using System;

namespace Power_Point
{
    public class DrawState : IMouseState
    {
        private readonly Shapes _shapes;
        private double _firstPointX;
        private double _firstPointY;

        // 常數
        const string FIRST = "first";
        const string END = "end";

        public DrawState(Shapes shapes)
        {
            this._shapes = shapes;
        }

        // 壓下滑鼠-繪畫
        public void MousePress(double pointX, double pointY, string shapeType)
        {
            if (pointX > 0 && pointY > 0)
            {
                _firstPointX = pointX;
                _firstPointY = pointY;
                _shapes.SetHintType(shapeType);
                _shapes.SetHint(_firstPointX, _firstPointY, FIRST);
                _shapes.SetHint(_firstPointX, _firstPointY, END);
            }
        }

        // 滑鼠移動-繪畫
        public void MouseMove(double pointX, double pointY)
        {
            _shapes.SetHint(pointX, pointY, END);
        }

        // 放開滑鼠-繪畫
        public void MouseUp(double pointX, double pointY, string shapeType)
        {
            _shapes.SetHint(_firstPointX, _firstPointY, FIRST);
            _shapes.SetHint(pointX, pointY, END);

            _shapes.SetGraph(shapeType);
            _shapes.InitializeHint();
        }

        // 回傳起點
        public Point GetFirstPoint()
        {
            return new Point(_firstPointX, _firstPointY);
        }
    }

}
