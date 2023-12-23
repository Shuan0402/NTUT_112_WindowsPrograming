using System;
using System.Drawing;
using Power_Point;

namespace Power_Point
{
    public class Shape
    {
        // 常數
        const string SHAPE = "Shape";
        const string POINT_ZERO = "(0, 0)";

        public Shape()
        {
            Name = SHAPE;
            Info = POINT_ZERO;
            IsCalled = false;
        }

        // 使用的變數
        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Info
        {
            get;
            set;
        }

        public virtual Point FirstPoint
        {
            get;
            set;
        }

        public virtual Point EndPoint
        {
            get;
            set;
        }

        public bool IsCalled
        {
            get;
            set;
        }

        // DrawPannel 的框架
        public virtual void Draw(IGraphics graphics, double rate)
        {
            IsCalled = true;
        }

        // DrawButton 的框架
        public virtual void DrawButton(IGraphics graphics, double rate)
        {
            IsCalled = true;
        }

        // 是否在選取範圍內
        public virtual void DrawSelect(IGraphics graphics, double rate)
        {
            IsCalled = true;
        }

        // DrawButton 的框架
        public virtual bool SelectShape(Point point)
        {
            return false;
        }
    }
}