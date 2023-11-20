using Power_point;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Power_Point
{
    public class Shapes
    {
        // 變數
        private readonly List<Shape> _shapes = new List<Shape>();
        private readonly ShapeFactory _shapeFactory = new ShapeFactory();
        Shape _hint = new Shape();
        int _selectedShape = -1;
        bool _isSelected = false;

        // 常數
        const string FIRST = "first";
        const string END = "end";

        public Shapes()
        {
        }

        // 新增形狀
        public void CreateShape(string shape) 
        {
            Shape temp = _shapeFactory.CreateShape(shape);
            _shapes.Add(temp);
        }

        // 刪除形狀
        public void DeleteShape(int index)
        {
            if (_isSelected)
            {
                _isSelected = false;
            }
            _shapes.RemoveAt(index);
        }

        // 刪除選取形狀
        public void DeleteSelectedShape()
        {
            if (_isSelected)
            {
                _shapes.RemoveAt(_selectedShape);
            }
            _isSelected = false;
        }

        // 選取形狀
        public int SelectShape(Point point)
        {
            _selectedShape = -1;
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].SelectShape(point))
                {
                    _selectedShape = i ;
                    _isSelected = true;
                    return _selectedShape;
                }
            }
            _isSelected = false;
            return _selectedShape;
        }

        // 將 shapes 中所有 shape 存進 shapedata 中
        public List<ShapeData> GetShapeData()
        {
            return _shapes.ConvertAll(Shape => new ShapeData(Shape.Name, Shape.Info));
        }

        // 設定 hint 的型態
        public void SetHintType(string hintType)
        {
            _hint = _shapeFactory.CreateShape(hintType);
        }

        // 設定 hint 的座標
        public void SetHint(double pointX, double pointY, string pointType)
        {

            if (pointType == FIRST)
            {
                _hint.FirstPoint = new Point(pointX, pointY);
            } else if (pointType == END)
            {
                _hint.EndPoint = new Point(pointX, pointY);
            }
        }

        // 初始化 hint
        public void InitializeHint()
        {
            _hint = null;
        }

        // 將所有 shapes 中的 shape 都畫在畫布上
        public void DrawShape(IGraphics graphics)
        {
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (_hint != null)
            {
                _hint.Draw(graphics);
            }
        }

        // 繪製選取
        public void DrawSelect(IGraphics graphics)
        {
            if (_isSelected && _selectedShape >= 0)
            {
                _shapes[_selectedShape].DrawSelect(graphics);
            }
        }

        // 將所有 shapes 中的 shape 都畫在縮圖上
        public void DrawButtonShape(IGraphics graphics)
        {
            foreach (Shape aShape in _shapes)
                aShape.DrawButton(graphics);
        }

        // 新增繪製形狀
        public void SetGraph(string shapeType) 
        {
            Shape temp = _shapeFactory.CreateShape(shapeType);
            temp.FirstPoint = _hint.FirstPoint;
            temp.EndPoint = _hint.EndPoint;
            _shapes.Add(temp);
        }

        // 清除畫面
        public void Clear()
        {
            _shapes.Clear();
        }

        // 更新形狀位置
        public void SetShape(double width, double height)
        {
            if (_isSelected)
            {
                Point _newFirstPoint = new Point(_shapes[_selectedShape].FirstPoint.X + width, _shapes[_selectedShape].FirstPoint.Y + height);
                Point _newEndPoint = new Point(_shapes[_selectedShape].EndPoint.X + width, _shapes[_selectedShape].EndPoint.Y + height);
                _shapes[_selectedShape].FirstPoint = _newFirstPoint;
                _shapes[_selectedShape].EndPoint = _newEndPoint;
            }
        }
    }
}

