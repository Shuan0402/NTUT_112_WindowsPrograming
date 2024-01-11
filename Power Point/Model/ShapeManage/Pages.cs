using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class Pages
    {
        public List<Shapes> _pages = new List<Shapes>();

        // draw
        public void DrawShape(IGraphics graphics, double rate, int index)
        {
            _pages[index].DrawShape(graphics, rate);
        }

        // draw
        public void DrawSelect(IGraphics graphics, double rate, int index)
        {
            _pages[index].DrawSelect(graphics, rate);
        }

        // draw
        public void DrawButton(IGraphics graphics, double rate, int index)
        {
            graphics.ClearAll();
            foreach(Shapes shapes in _pages)
            {
                _pages[index].DrawButtonShape(graphics, rate);
            }
        }

        // add
        public void AddPage(int index)
        {
            Shapes page = new Shapes();
            _pages.Insert(index, page);
        }

        // delete
        public void DeletePage(int index)
        {
            if(_pages.Count() > 1)
            {
                _pages.RemoveAt(index);
            }
        }

        // 將 shapes 中所有 shape 存進 shapedata 中
        public List<ShapeData> GetShapeData(int index)
        {
            if(index > -1)
            {
                return _pages[index].GetShapeData();
            }
            return _pages[0].GetShapeData();
        }

        public Shapes CopyDeep(int index)
        {
            return _pages[index].CopyDeep();
        }

        public void CreateShape(int index, string shapeType)
        {
            _pages[index].CreateShape(shapeType);
        }

        public void DeleteShape(int index, int slideIndex)
        {
            _pages[slideIndex].DeleteShape(index);
        }

        public int GetSelectedIndex(int index)
        {
            return _pages[index].SelectedIndex;
        }

        public void SetSelectedIndex(int index, int slideIndex)
        {
            _pages[slideIndex].SelectedIndex = index;
        }

        public void Clear(int index)
        {
            _pages[index].Clear();
        }

        public int SelectShape(int index, Point point)
        {
            return _pages[index].SelectShape(point);
        }

        public void SetSelectedShapeSize(int index, double pointX, double pointY)
        {
            _pages[index].SetSelectedShapeSize(pointX, pointY);
        }

        public void SetSelectedShapePosition(double width, double height, int index)
        {
            _pages[index].SetSelectedShapePosition(width, height);
        }

        public void SetShapes(int index, Shapes shapes)
        {
            _pages[index] = shapes.CopyDeep();
        }

        public bool IsInRightFloorPoint(int index, double pointX, double pointY)
        {
            return _pages[index].IsInRightFloorPoint(pointX, pointY);
        }
    }
}
