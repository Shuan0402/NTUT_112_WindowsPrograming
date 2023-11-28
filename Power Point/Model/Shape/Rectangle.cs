using System;
using Power_Point;

namespace Power_Point
{
    public class Rectangle : Shape
    {
        // 常數
        const string RECTANGLE = "矩形";
        const string RECTANGLE_INFO = "{0}, {1}";

        public Rectangle()
        {
        }

        public override string Name
        {
            get
            {
                return RECTANGLE;
            }
        }

        public override string Info
        {
            get
            {
                return string.Format(RECTANGLE_INFO, FirstPoint.ToString(), EndPoint.ToString());
            }
        }

        // 覆蓋 Shape Draw 的 Draw Rectangle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(FirstPoint, EndPoint);
        }

        // 標示被選取的形狀
        public override void DrawSelect(IGraphics graphics)
        {
            graphics.DrawSelect(FirstPoint, EndPoint);
        }

        // 繪畫縮圖
        public override void DrawButton(IGraphics graphics)
        {
            graphics.DrawButtonRectangle(FirstPoint, EndPoint);
        }

        // 是否在選取範圍內
        public override bool SelectShape(Point point)
        {
            return (point.X >= GetMinPointX() && point.X <= GetMaxPointX() && point.Y >= GetMinPointY() && point.Y <= GetMaxPointY());
        }

        // 獲得起點 X 座標
        private float GetMinPointX()
        {
            return Math.Min((float)FirstPoint.X, (float)EndPoint.X);
        }

        // 獲得終點 X 座標
        private float GetMaxPointX()
        {
            return Math.Max((float)FirstPoint.X, (float)EndPoint.X);
        }

        // 獲得起點 Y 座標
        private float GetMinPointY()
        {
            return Math.Min((float)FirstPoint.Y, (float)EndPoint.Y);
        }

        // 獲得終點 Y 座標
        private float GetMaxPointY()
        {
            return Math.Max((float)FirstPoint.Y, (float)EndPoint.Y);
        }
    }
}
