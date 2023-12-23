using System;
using Power_Point;

namespace Power_Point
{
    public class Line : Shape
    {
        // 常數
        const string LINE = "線";
        public const string LINE_INFO = "{0}, {1}";

        public Line()
        {
        }

        public override string Name
        {
            get
            {
                return LINE;
            }
        }

        public override string Info
        {
            get
            {
                return string.Format(LINE_INFO, FirstPoint.ToString(), EndPoint.ToString());
            }
            set
            {

            }
        }

        // 覆蓋 Shape Draw 的 Draw Line
        public override void Draw(IGraphics graphics, double rate)
        {
            graphics.DrawLine(FirstPoint, EndPoint, rate);
        }

        // 標示被選取的形狀
        public override void DrawSelect(IGraphics graphics, double rate)
        {
            graphics.DrawSelect(FirstPoint, EndPoint, rate);
        }

        // 繪畫縮圖
        public override void DrawButton(IGraphics graphics, double rate)
        {
            graphics.DrawButtonLine(FirstPoint, EndPoint, rate);
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
