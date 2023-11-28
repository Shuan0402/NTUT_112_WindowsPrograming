using System;

namespace Power_Point
{
    public class ShapeFactory
    {
        // 常數
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";
        const int MAX_X = 453;
        const int MAX_Y = 354;

        // 變數
        Shape _shape = new Shape();

        // 新增形狀
        public Shape CreateShape(string shapeType)
        {
            switch (shapeType)
            {
                case LINE:
                    GenerateShape(shapeType);
                    break;
                case RECTANGLE:
                    GenerateShape(shapeType);
                    break;
                case CIRCLE:
                    GenerateShape(shapeType);
                    break;
                default:
                    GenerateShape(shapeType);
                    break;
            }
            return _shape;
        }

        // 生成隨機座標
        public void GenerateRandomInfo(Shape shape)
        {
            Random random = new Random();
            Point firstPoint = new Point(random.Next(0, MAX_X), random.Next(0, MAX_Y));
            Point endPoint = new Point(random.Next(0, MAX_X), random.Next(0, MAX_Y));
            shape.FirstPoint = firstPoint;
            shape.EndPoint = endPoint;
        }

        // 生成形狀
        private void GenerateShape(string shapeType)
        {
            switch (shapeType)
            {
                case LINE:
                    _shape = new Line();
                    break;
                case CIRCLE:
                    _shape = new Circle();
                    break;
                case RECTANGLE:
                    _shape = new Rectangle();
                    break;
                default:
                    _shape = new Shape();
                    break;
            }
            GenerateRandomInfo(_shape);
        } 
    }
}