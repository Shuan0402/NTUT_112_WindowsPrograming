using System;
using Power_Point;

namespace Power_Point
{
    public class Circle : Shape
    {
        // 常數
        const string CIRCLE = "圓形";
        const string CIRCLE_INFO = "{0}, {1}";
        const double DOUBLE_TWO = 2.0;
        const int TWO = 2;
        const int ONE = 1;
        double _firstPointX;
        double _firstPointY;
        double _endPointX;
        double _endPointY;

        public Circle()
        {
        }
        
        public override string Name
        {
            get
            {
                return CIRCLE;
            }
        }

        public override string Info
        {
            get
            {
                return string.Format(CIRCLE_INFO, FirstPoint.ToString(), EndPoint.ToString());
            }
        }

        // 覆蓋 Shape Draw 的 Draw Circle
        public override void Draw(IGraphics graphics, double rate)
        {
            graphics.DrawCircle(FirstPoint, EndPoint,rate);
        }

        // 繪畫縮圖
        public override void DrawButton(IGraphics graphics, double rate)
        {
            graphics.DrawButtonCircle(FirstPoint, EndPoint, rate);
        }

        // 標示被選取的形狀
        public override void DrawSelect(IGraphics graphics, double rate)
        {
            graphics.DrawSelect(FirstPoint, EndPoint, rate);
        }

        // 是否在選取範圍內
        public override bool SelectShape(Point point)
        {
            SetPoint();
            double radiusX = Math.Abs(_endPointX - _firstPointX) / DOUBLE_TWO; // X 軸半徑
            double radiusY = Math.Abs(_endPointY - _firstPointY) / DOUBLE_TWO; // Y 軸半徑
            double centerPointX = (_firstPointX + _endPointX) / DOUBLE_TWO; // 中心點 X 座標
            double centerPointY = (_firstPointY + _endPointY) / DOUBLE_TWO; // 中心點 Y 座標

            // 座標轉換
            double pointX = point.X - centerPointX;
            double pointY = point.Y - centerPointY;

            return (Math.Pow(pointX, TWO) / Math.Pow(radiusX, TWO)) + (Math.Pow(pointY, TWO) / Math.Pow(radiusY, TWO)) <= ONE;
        }

        // 設定起點終點
        private void SetPoint()
        {
            _firstPointX = FirstPoint.X;
            _firstPointY = FirstPoint.Y;
            _endPointX = EndPoint.X;
            _endPointY = EndPoint.Y;
        }
    }
}
