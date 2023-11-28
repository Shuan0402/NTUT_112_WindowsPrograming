using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Power_Point
{
    public class FormsGraphicsAdaptor : IGraphics
    {
        // 變數
        float _startPointX;
        float _startPointY;
        float _endPointX;
        float _endPointY;
        float _middlePointX;
        float _middlePointY;
        float _width;
        float _height;
        readonly Graphics _graphics;
        public Graphics GraphicsInstance => _graphics;

        // 常數
        const double THREE_POINT_EIGHT = 3.8;
        const int TWO = 2;
        const int FIVE = 5;
        const int TEN = 10;

        public FormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        public FormsGraphicsAdaptor()
        {
        }

        // 清除
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }
        
        // 畫線
        public virtual void DrawLine(Point firstPoint, Point endPoint)
        {
            _graphics.DrawLine(Pens.Black, (float)firstPoint.X, (float)firstPoint.Y, (float)endPoint.X, (float)endPoint.Y);
        }

        // 繪製線縮圖
        public virtual void DrawButtonLine(Point firstPoint, Point endPoint)
        {
            _graphics.DrawLine(Pens.Black, (float)(firstPoint.X / THREE_POINT_EIGHT), (float)(firstPoint.Y / THREE_POINT_EIGHT), (float)(endPoint.X / THREE_POINT_EIGHT), (float)(endPoint.Y / THREE_POINT_EIGHT));
        }

        // 畫圓
        public virtual void DrawCircle(Point firstPoint, Point endPoint)
        {
            float pointX = GetMinPointX(firstPoint, endPoint);
            float pointY = GetMinPointY(firstPoint, endPoint);
            float width = GetWidth(firstPoint, endPoint);
            float height = GetHeight(firstPoint, endPoint);

            _graphics.DrawEllipse(Pens.Black, pointX, pointY, width, height);
        }

        // 繪製圓縮圖
        public virtual void DrawButtonCircle(Point firstPoint, Point endPoint)
        {
            float pointX = (float)(GetMinPointX(firstPoint, endPoint) / THREE_POINT_EIGHT);
            float pointY = (float)(GetMinPointY(firstPoint, endPoint) / THREE_POINT_EIGHT);
            float width = (float)(GetWidth(firstPoint, endPoint) / THREE_POINT_EIGHT);
            float height = (float)(GetHeight(firstPoint, endPoint) / THREE_POINT_EIGHT);

            _graphics.DrawEllipse(Pens.Black, pointX, pointY, width, height);
        }

        // 畫矩形
        public virtual void DrawRectangle(Point firstPoint, Point endPoint)
        {
            float pointX = GetMinPointX(firstPoint, endPoint);
            float pointY = GetMinPointY(firstPoint, endPoint);
            float width = GetWidth(firstPoint, endPoint);
            float height = GetHeight(firstPoint, endPoint);

            _graphics.DrawRectangle(Pens.Black, pointX, pointY, width, height);
        }

        // 繪製矩形縮圖
        public virtual void DrawButtonRectangle(Point firstPoint, Point endPoint)
        {
            float pointX = (float)(GetMinPointX(firstPoint, endPoint) / THREE_POINT_EIGHT);
            float pointY = (float)(GetMinPointY(firstPoint, endPoint) / THREE_POINT_EIGHT);
            float width = (float)(GetWidth(firstPoint, endPoint) / THREE_POINT_EIGHT);
            float height = (float)(GetHeight(firstPoint, endPoint) / THREE_POINT_EIGHT);

            _graphics.DrawRectangle(Pens.Black, pointX, pointY, width, height);
        }

        // 畫選取框
        public virtual void DrawSelect(Point firstPoint, Point endPoint)
        {
            SetSelect(firstPoint, endPoint);

            _graphics.DrawRectangle(Pens.Gray, _startPointX, _startPointY, _width, _height);
            _graphics.DrawEllipse(Pens.Black, _startPointX - (float)FIVE, _startPointY - (float)FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Black, _startPointX - (float)FIVE, _endPointY - (float)FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Black, _endPointX - (float)FIVE, _endPointY - (float)FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Black, _endPointX - (float)FIVE, _startPointY - (float)FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Black, _startPointX - (float)FIVE, _middlePointY - (float)FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Black, _middlePointX - (float)FIVE, _endPointY - (float)FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Black, _middlePointX - (float)FIVE, _startPointY - (float)FIVE, TEN, TEN);
            _graphics.DrawEllipse(Pens.Black, _endPointX - (float)FIVE, _middlePointY - (float)FIVE, TEN, TEN);

        }

        // 設置選取形狀的所有資訊
        private void SetSelect(Point firstPoint, Point endPoint)
        {
            _startPointX = GetMinPointX(firstPoint, endPoint);
            _startPointY = GetMinPointY(firstPoint, endPoint);
            _endPointX = GetMaxPointX(firstPoint, endPoint);
            _endPointY = GetMaxPointY(firstPoint, endPoint);
            _middlePointX = (_startPointX + _endPointX) / TWO;
            _middlePointY = (_startPointY + _endPointY) / TWO;
            _width = GetWidth(firstPoint, endPoint);
            _height = GetHeight(firstPoint, endPoint);
        }

        // 計算座標數值
        // 獲得起點 X 座標
        private float GetMinPointX(Point firstPoint, Point endPoint)
        {
            return Math.Min((float)firstPoint.X, (float)endPoint.X);
        }

        // 獲得終點 X 座標
        private float GetMaxPointX(Point firstPoint, Point endPoint)
        {
            return Math.Max((float)firstPoint.X, (float)endPoint.X);
        }

        // 獲得起點 Y 座標
        private float GetMinPointY(Point firstPoint, Point endPoint)
        {
            return Math.Min((float)firstPoint.Y, (float)endPoint.Y);
        }

        // 獲得終點 Y 座標
        private float GetMaxPointY(Point firstPoint, Point endPoint)
        {
            return Math.Max((float)firstPoint.Y, (float)endPoint.Y);
        }

        // 獲得寬
        private float GetWidth(Point firstPoint, Point endPoint)
        {
            float max = Math.Max((float)firstPoint.X, (float)endPoint.X);
            return max - GetMinPointX(firstPoint, endPoint);
        }

        // 獲得高
        private float GetHeight(Point firstPoint, Point endPoint)
        {
            float max = Math.Max((float)firstPoint.Y, (float)endPoint.Y);
            return max - GetMinPointY(firstPoint, endPoint);
        }
    }
}
