using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class Pages
    {
        public List<Shapes> PagesList
        {
            get;
            set;
        }

        public Pages()
        {
            PagesList = new List<Shapes>();
        }

        public int PagesCount
        {
            get
            {
                return PagesList.Count();
            }
        }

        // draw
        public void DrawShape(IGraphics graphics, double rate, int index)
        {
            PagesList[index].DrawShape(graphics, rate);
        }

        // draw
        public void DrawSelect(IGraphics graphics, double rate, int index)
        {
            PagesList[index].DrawSelect(graphics, rate);
        }

        // draw
        public void DrawButton(IGraphics graphics, double rate, int index)
        {
            graphics.ClearAll();
            for (int i = 0; i < PagesList.Count(); i++)
            {
                if (index > -1 && index < PagesList.Count())
                {
                    PagesList[index].DrawButtonShape(graphics, rate);
                }
            }
        }

        // add
        public void AddPage(int index)
        {
            Shapes page = new Shapes();
            PagesList.Insert(index, page);
        }

        // delete
        public void DeletePage(int index)
        {
            if (PagesList.Count() > 1)
            {
                PagesList.RemoveAt(index);
            }
        }

        // 將 shapes 中所有 shape 存進 shapedata 中
        public List<ShapeData> GetShapeData(int index)
        {
            if (index > -1 && index < PagesList.Count())
            {
                return PagesList[index].GetShapeData();
            }
            return PagesList[0].GetShapeData();
        }

        // test
        public Shapes CopyDeep(int index)
        {
            if (index > -1 && index < PagesList.Count())
            {
                return PagesList[index].CopyDeep();
            }
            Shapes temps = new Shapes();
            PagesList.Add(temps);
            return PagesList[0].CopyDeep();
        }

        // test
        public void AddDataGridViewShape(string shapeType, Point LeftTopPoint, Point RightBottomPoint, int index)
        {
            if (index > -1 && index < PagesList.Count())
            {
                PagesList[index].AddDataGridViewShape(shapeType, LeftTopPoint, RightBottomPoint);
            }
        }

        // test
        public void DeleteShape(int index, int slideIndex)
        {
            if (index > -1 && index < PagesList.Count())
            {
                PagesList[slideIndex].DeleteShape(index);
            }
        }

        // test
        public int GetSelectedIndex(int index)
        {
            if (index > -1 && index < PagesList.Count())
            {
                return PagesList[index].SelectedIndex;
            }
            return PagesList[0].SelectedIndex;
        }

        // test
        public void SetSelectedIndex(int index, int slideIndex)
        {
            if (slideIndex > -1 && slideIndex < PagesList.Count())
            {
                PagesList[slideIndex].SelectedIndex = index;
            }
        }

        // test
        public void Clear(int index)
        {
            if (index > -1 && index < PagesList.Count())
            {
                PagesList[index].Clear();
            }
        }

        // test
        public int SelectShape(int index, Point point)
        {
            if (index > -1 && index < PagesList.Count())
            {
                return PagesList[index].SelectShape(point);
            }
            return PagesList[0].SelectShape(point);
        }

        // test
        public void SetSelectedShapeSize(int index, double pointX, double pointY)
        {
            if (index > -1 && index < PagesList.Count())
            {
                PagesList[index].SetSelectedShapeSize(pointX, pointY); 
            }
        }

        // test
        public void SetSelectedShapePosition(double width, double height, int index)
        {
            if (index > -1 && index < PagesList.Count())
            {
                PagesList[index].SetSelectedShapePosition(width, height);
            }
        }

        // test
        public void SetShapes(int index, Shapes shapes)
        {
            if (index > -1 && index < PagesList.Count())
            {
                PagesList[index] = shapes.CopyDeep();
            }
        }

        // test
        public bool IsInRightFloorPoint(int index, double pointX, double pointY)
        {
            if (index > -1 && index < PagesList.Count())
            {
                return PagesList[index].IsInRightFloorPoint(pointX, pointY);
            }
            return PagesList[0].IsInRightFloorPoint(pointX, pointY);
        }

        // test
        public void SelectNot(int index)
        {
            if (index > -1 && index < PagesList.Count())
            {
                PagesList[index].IsSelected = false;
            }
        }

        // test
        public int GetPageCount()
        {
            return PagesList.Count();
        }
        
        // test
        public void Clear()
        {
            PagesList.Clear();
        }
    }
}
