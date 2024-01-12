using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Power_Point
{
    public class PresentationModel: INotifyPropertyChanged
    {
        private string _selectButtonType = null;
        public readonly PowerPointModel _model;

        const string DRAW = "draw";
        const string POINT = "point";
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";


        public PresentationModel(PowerPointModel model)
        {
            this._model = model;
        }

        // pm 事件傳回給 m
        public event PowerPointModel.PannelChangedEventHandler PresentationPannelChanged
        {
            add => _model.ChangePannelEvent += value;
            remove => _model.ChangePannelEvent -= value;
        }

        public event PowerPointModel.ButtonChangedEventHandler PresentationButtonChanged
        {
            add => _model.ChangeButtonEvent += value;
            remove => _model.ChangeButtonEvent -= value;
        }

        public event PowerPointModel.PageAddEventHandler PresentationPageAdded
        {
            add => _model.AddPageEvent += value;
            remove => _model.AddPageEvent -= value;
        }

        public event PowerPointModel.PageDeleteEventHandler PresentationPageDeleted
        {
            add => _model.DeletePageEvent += value;
            remove => _model.DeletePageEvent -= value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // 通知 Property 改變
        public void NotifyProperty(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsLineChecked
        {
            get;
            set;
        }

        // 圓按鈕是否被選取
        public bool IsCircleChecked
        {
            get;
            set;
        }

        // 矩形按鈕是否被選取
        public bool IsRectangleChecked
        {
            get;
            set;
        }

        public bool IsArrowChecked
        {
            get;
            set;
        }

        public bool IsSlideChecked
        {
            get;
            set;
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _model.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _model.IsUndoEnabled;
            }
        }

        public int OriginSlideIndex
        {
            get
            {
                return _model.OriginSlideIndex;
            }
            set
            {
                _model.OriginSlideIndex = value;
            }
        }

        public int CurrentSlideIndex
        {
            get
            {
                return _model.CurrentSlideIndex;
            }
            set
            {
                _model.CurrentSlideIndex = value;
            }
        }

        // 取消選取圖形按鈕
        public void CheckArrow()
        {
            _selectButtonType = null;
            IsLineChecked = false;
            IsCircleChecked = false;
            IsRectangleChecked = false;
            IsArrowChecked = true;
            _model.ChangeState(POINT);
            NotifyProperty("IsArrowChecked");
            NotifyProperty("IsLineChecked");
            NotifyProperty("IsCircleChecked");
            NotifyProperty("IsRectangleChecked");
            UnCheckSlide();
        }

        // Line
        public void CheckLine()
        {
            CheckArrow();
            _model.ChangeState(DRAW);
            _selectButtonType = LINE;
            IsLineChecked = true;
            IsArrowChecked = false;
            
            NotifyProperty("IsLineChecked");
            NotifyProperty("IsArrowChecked");
        }

        // Circle
        public void CheckCircle()
        {
            CheckArrow();
            _model.ChangeState(DRAW);
            _selectButtonType = CIRCLE;
            IsCircleChecked = true;
            IsArrowChecked = false;
            
            NotifyProperty("IsCircleChecked");
            NotifyProperty("IsArrowChecked");
        }

        // Rectangle
        public void CheckRectangle()
        {
            CheckArrow();
            _model.ChangeState(DRAW);
            _selectButtonType = RECTANGLE;
            IsRectangleChecked = true;
            IsArrowChecked = false;
            
            NotifyProperty("IsRectangleChecked");
            NotifyProperty("IsArrowChecked");
        }

        // 遍歷 Sahpes
        public List<ShapeData> GetShapeData()
        {
            List<ShapeData> dataList = _model.GetShapeData(CurrentSlideIndex);
            return dataList;
        }

        // 新增
        public void AddDataGridViewShape(string selectedShape, Point LeftTopPoint, Point RightBottomPoint)
        {
            _model.AddDataGridViewShape(selectedShape, LeftTopPoint, RightBottomPoint, CurrentSlideIndex);
            _model.IsFirstCreate = true;
        }

        // 刪除 shape
        public void DeleteShape(int rowIndex, int columnIndex, Keys keys)
        {
            if (IsSlideChecked)
            {
                return;
            }
            else if ((rowIndex != -1 && columnIndex == 0) || (keys == Keys.Delete))
            {
                _model.DeleteShape(rowIndex, CurrentSlideIndex);
            }
        }

        // 壓下滑鼠
        public void PointerPressed(double x, double y)
        {
            _model.PressPointer(x, y, _selectButtonType, CurrentSlideIndex);
        }

        // 放開滑鼠
        public void PointerReleased()
        {
            _model.ReleasePointer(CurrentSlideIndex);
            _model.ChangeState(POINT);
            CheckArrow();
        }

        // 滑鼠移動
        public void PointerMoved(double x, double y)
        {
            _model.MovePointer(CurrentSlideIndex, x, y);
        }

        // 清除
        public void ClearShapes()
        {
            _model.ClearShapes(CurrentSlideIndex);
        }

        // 新增繪圖
        public void DrawPannel(FormsGraphicsAdaptor graphics, double rate)
        {
            _model.DrawPannel(graphics, rate, CurrentSlideIndex);
        }

        // 新增繪圖
        public void DrawButton(FormsGraphicsAdaptor graphics, double rate, int index)
        {
            _model.DrawButton(graphics, rate, index);
        }

        // 控制滑鼠型態
        public Cursor GetCursors()
        {
            if (_selectButtonType == null)
            {
                if (_model.IsShapeSizable)
                {
                    return Cursors.SizeNWSE;
                }
                return Cursors.Arrow;
            }
            else
            {
                return Cursors.Cross;
            }
        }

        // 刪除選取形狀
        public void DeleteSelectedShape()
        {
            //_model.DeleteSelecetedShape();
        }

        // undo
        public void Undo()
        {
            _model.Undo();
        }

        // redo
        public void Redo()
        {
            _model.Redo();
        }

        // IsSelected
        public bool IsSelected()
        {
            return _model.IsSelected();
        }

        // test
        public void AddPage(int index)
        {
            _model.AddPage(index);
        }

        // test
        public void DeletePage(int index)
        {
            if (IsSlideChecked)
            {
                _model.DeletePage(index);
            }
        }

        // test
        public void CheckSlide()
        {
            IsSlideChecked = true;
            _model.UnSelected(CurrentSlideIndex);
        }

        // test
        public void UnCheckSlide()
        {
            IsSlideChecked = false;
        }

        public int PagesCount
        {
            get
            {
                return _model.PagesCount;
            }
        }

        // test
        public void SetOriginSlideIndex(int? index)
        {
            if (index == null)
            {
                return;
            }
            
            if(index < 0)
            {
                OriginSlideIndex = 0;
            }
            else
            {
                OriginSlideIndex = (int)index;
            }
        }

        // test
        public void SetCurrentSlideIndex(int? index)
        {
            if (index == null)
            {
                return;
            }

            if (index < 0)
            {
                CurrentSlideIndex = 0;
            }
            else
            {
                CurrentSlideIndex = (int)index;
            }
        }

        // test
        public string GetData()
        {
            int pageCount = _model.GetPageCount();
            string data = "";
            for(int i = 0; i < pageCount; i++)
            {
                data += ("page: " + i.ToString() + "\n");
                List<ShapeData> dataList = GetShapeData(i);
                for(int j = 0; j < GetListCount(dataList); j++)
                {
                    data += (dataList[j].Name + ": " + dataList[j].Info + "\n");
                }
            }
            return data;
        }

        // test
        private int GetListCount(List<ShapeData> shapeDatas)
        {
            return shapeDatas.Count();
        }

        // test
        private List<ShapeData> GetShapeData(int index)
        {
            return _model.GetShapeData(index);
        }

        // test
        public void LoadData(string[] lines)
        {
            _model.ClearPages();
            int index = 0;
            foreach(string line in lines)
            {
                Debug.Print(line);
                if(line.StartsWith("page: "))
                {
                    if(line != "page: 0")
                    {
                        AddPage(index);
                    }
                    index++;
                }
                else
                {
                    _ = new string[2];
                    string[] data = line.Split(new[] { ": " }, StringSplitOptions.None);
                    _ = new List<Point>();
                    List<Point> points = ParsePoints(data[1]);

                    AddDataGridViewShape(data[0], points[0], points[1]);
                }
            }
            Debug.Print(_model.GetPageCount().ToString());
        }

        // 轉
        public List<Point> ParsePoints(string input)
        {
            List<Point> points = new List<Point>();

            MatchCollection matches = Regex.Matches(input, @"\((\d+),\s(\d+)\)");

            foreach (Match match in matches)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                Point point = new Point(x, y);
                points.Add(point);
            }

            return points;
        }
    }
}