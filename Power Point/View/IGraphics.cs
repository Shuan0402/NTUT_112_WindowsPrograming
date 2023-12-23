using System;
using System.Collections.Generic;
using System.Text;

namespace Power_Point
{
    public interface IGraphics
    {
        // 清除
        void ClearAll();

        // 畫線
        void DrawLine(Point firstPoint, Point endPoint, double rate);
        // 畫線縮圖
        void DrawButtonLine(Point firstPoint, Point endPoint, double rate);

        // 畫圓
        void DrawCircle(Point firstPoint, Point endPoint, double rate);
        // 畫圓縮圖
        void DrawButtonCircle(Point firstPoint, Point endPoint, double rate);

        // 畫矩形
        void DrawRectangle(Point firstPoint, Point endPoint, double rate);
        // 畫矩形縮圖
        void DrawButtonRectangle(Point firstPoint, Point endPoint, double rate);

        // 畫選取
        void DrawSelect(Point firstPoint, Point endPoint, double rate);
    }
}
