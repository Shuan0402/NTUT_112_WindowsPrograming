using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace Power_Point
{
    public class Shapes
    {
        // 變數
        List<Shape> _shapes = new List<Shape>();
        private readonly ShapeFactory _shapeFactory = new ShapeFactory();
        private readonly ShapesTool _shapesTool = new ShapesTool();

        // 常數
        const string FIRST = "first";
        const string END = "end";
        const string SHAPE = "Shape";
        const int FIVE = 5;
        const int ZERO = 0;

        public Shapes()
        {
            InitializeHint();
        }

        public int SelectedIndex
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }

        public int GetShapesSize
        {
            get
            {
                return _shapes.Count;
            }
        }

        public Shape Temp
        {
            get;
            set;
        }

        public Shape Hint
        {
            get;
            set;
        }

        // test
        public string AddDataGridViewShape(string shapeType, Point LeftTop, Point RightBottom)
        {
            Temp = _shapeFactory.CreateShape(shapeType);
            Temp.SetLeftTopPoint(LeftTop);
            Temp.SetRightBottomPoint(RightBottom);
            _shapes.Add(Temp);
            return Temp.Info;
        }

        // 刪除形狀
        public void DeleteShape(int index)
        {
            
            _shapes.RemoveAt(index);
            if (IsSelected)
            {
                IsSelected = false;
                SelectedIndex = -1;
            }
        }

        // 選取形狀
        public int SelectShape(Point point)
        {
            SelectedIndex = -1;
            IsSelected = false;
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].SelectShape(point))
                {
                    SelectedIndex = i ;
                    IsSelected = true;
                    break;
                }
            }
            return SelectedIndex;
        }

        // 將 shapes 中所有 shape 存進 shapedata 中
        public List<ShapeData> GetShapeData()
        {
            return _shapes.ConvertAll(Shape => new ShapeData(Shape.Name, Shape.Info));
        }

        // 設定 hint 的型態
        public void SetHintType(string hintType)
        {
            Hint = _shapeFactory.CreateShape(hintType);
        }

        // 設定 hint 的座標
        public void SetHint(double pointX, double pointY, string pointType)
        {
            switch (pointType)
            {
                case FIRST:
                    Hint.FirstPoint = new Point(pointX, pointY);
                    break;
                case END:
                    Hint.EndPoint = new Point(pointX, pointY);
                    break;
            }
        }

        // 初始化 hint
        public void InitializeHint()
        {
            Hint = new Shape();
        }

        // 將所有 shapes 中的 shape 都畫在畫布上
        public void DrawShape(IGraphics graphics, double rate)
        {
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics, rate);
            if (Hint.Name != SHAPE)
            {
                DrawHint(graphics, rate);
            }
        }

        // Draw hint
        private void DrawHint(IGraphics graphics, double rate)
        {
            Hint.Draw(graphics, rate);
        }

        // 繪製選取
        public void DrawSelect(IGraphics graphics, double rate)
        {
            if (IsSelected && SelectedIndex >= ZERO)
            {
                _shapes[SelectedIndex].DrawSelect(graphics, rate);
            }
        }

        // 將所有 shapes 中的 shape 都畫在縮圖上
        public void DrawButtonShape(IGraphics graphics, double rate)
        {
            foreach (Shape aShape in _shapes)
                aShape.DrawButton(graphics, rate);
        }

        // 新增繪製形狀
        public void SetGraph() 
        {
            Temp = new Shape();
            Temp = _shapeFactory.CreateShape(Hint.Name);
            Temp.FirstPoint = Hint.FirstPoint;
            Temp.EndPoint = Hint.EndPoint;
            _shapesTool.SetShapePoint(Hint, Temp);
            if (Temp.Name != SHAPE)
            {
                if (_shapesTool.IsTempPointEqual(Temp))
                {
                    _shapes.Add(Temp);
                }
            }
        }

        // 清除畫面
        public void Clear()
        {
            _shapes.Clear();
        }

        // 更新形狀位置
        public void SetSelectedShapePosition(double width, double height)
        {
            if (IsSelected)
            {
                Point _newFirstPoint = new Point(_shapes[SelectedIndex].FirstPoint.X + width, _shapes[SelectedIndex].FirstPoint.Y + height);
                Point _newEndPoint = new Point(_shapes[SelectedIndex].EndPoint.X + width, _shapes[SelectedIndex].EndPoint.Y + height);
                _shapes[SelectedIndex].FirstPoint = _newFirstPoint;
                _shapes[SelectedIndex].EndPoint = _newEndPoint;
            }
        }

        // 更新形狀大小
        public void SetSelectedShapeSize(double pointX, double pointY)
        {
            SetSelectedShapeSizeX(pointX);
            SetSelectedShapeSizeY(pointY);
            _shapesTool.SetShapePoint(Hint, Temp);
        }

        // 設置被選取的形狀X長度
        private void SetSelectedShapeSizeX(double pointX)
        {
            if (_shapes[SelectedIndex].FirstPoint.X > _shapes[SelectedIndex].EndPoint.X)
            {
                _shapes[SelectedIndex].FirstPoint.X = pointX;
            }
            else
            {
                _shapes[SelectedIndex].EndPoint.X = pointX;
            }
        }

        // 設置被選取的形狀Y長度
        private void SetSelectedShapeSizeY(double pointY)
        {
            if (_shapes[SelectedIndex].FirstPoint.Y > _shapes[SelectedIndex].EndPoint.Y)
            {
                _shapes[SelectedIndex].FirstPoint.Y = pointY;
            }
            else
            {
                _shapes[SelectedIndex].EndPoint.Y = pointY;
            }
        }

        // 獲得被選取形狀的座標
        public Point GetSelectedShapePoint()
        {
            return _shapes[SelectedIndex].RightBottomPoint;
        }

        // 回傳是否在調整形狀大小的形狀範圍位置上
        public bool IsInRightFloorPoint(double pointX, double pointY)
        {
            if (IsSelected)
            {
                return (pointX >= GetRightFloorPoint().X - FIVE &&
                        pointX <= GetRightFloorPoint().X + FIVE &&
                        pointY >= GetRightFloorPoint().Y - FIVE &&
                        pointY <= GetRightFloorPoint().Y + FIVE);
            }
            return false;
        }

        // GetRightFloorPoint
        public Point GetRightFloorPoint()
        {
            Point point = new Point(GetMaxPointX(), GetMaxPointY());
            return point;
        }

        // 獲得終點 X 座標
        private float GetMaxPointX()
        {
            return Math.Max((float)_shapes[SelectedIndex].FirstPoint.X, (float)_shapes[SelectedIndex].EndPoint.X);
        }

        // 獲得終點 Y 座標
        private float GetMaxPointY()
        {
            return Math.Max((float)_shapes[SelectedIndex].FirstPoint.Y, (float)_shapes[SelectedIndex].EndPoint.Y);
        }

        // SetShape
        public void SetShape(int index, double pointX, double pointY)
        {
            if (index >= 0)
            {
                Point firstPoint = _shapes[index].FirstPoint;
                Point endPoint = _shapes[index].EndPoint;

                _shapes[index].FirstPoint = _shapesTool.GetPoint(firstPoint, pointX, pointY);
                _shapes[index].EndPoint = _shapesTool.GetPoint(endPoint, pointX, pointY);
            }
        }

        // 深度複製 Shapes
        public Shapes CopyDeep()
        {
            Shapes newShapes = (Shapes)this.MemberwiseClone();
            newShapes._shapes = new List<Shape>();

            foreach (Shape originalShape in this._shapes)
            {
                Shape clonedShape = originalShape.GetShapeClone();
                newShapes._shapes.Add(clonedShape);
            }

            newShapes = _shapesTool.CopyDeep(newShapes, this.Temp, this.SelectedIndex, this.IsSelected);

            return newShapes;
        }

        // test
        public void SetShapeDataList(List<ShapeData> shapeDataList)
        {
            _shapes.Clear();
            foreach (ShapeData shapeData in shapeDataList)
            {
                _shapes.Add(GetNewShape(shapeData));
            }
        }

        // test
        private Shape GetNewShape(ShapeData shapeData)
        {
            Shape newShape = new Shape
            {
                Name = shapeData.Name,
                Info = shapeData.Info
            };

            return newShape;
        }
    }
}

