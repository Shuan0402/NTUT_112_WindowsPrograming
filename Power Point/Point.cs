using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Power_Point
{
    public class Point
    {
        // 常數
        public const string LEFT = "(";
        public const string RIGHT = ")";
        public const string COMMA = ", ";

        public double X
        { 
            get;
            set;
        }
        
        public double Y
        { 
            get;
            set;
        }

        public Point(double pointX, double pointY)
        {
            X = pointX;
            Y = pointY;
        }

        // 覆蓋原本的 Tostring()
        override public string ToString()
        {
            return LEFT + X.ToString() + COMMA + Y.ToString() + RIGHT;
        }

        // 深度複製 Point
        public Point CopyDeep()
        {
            Point copiedPoint = new Point(this.X, this.Y);
            return copiedPoint;
        }
    }
}