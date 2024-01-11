using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Power_Point
{
    public class DrawState : IMouseState
    {
        private readonly PowerPointModel _model;
        private readonly Shapes _shapes;
        Shapes _originShapes;
        int _index;
        public double FirstPointX
        {
            get;
            set;
        }
        public double FirstPointY
        {
            get;
            set;
        }

        // 常數
        const string FIRST = "first";
        const string END = "end";

        public DrawState(PowerPointModel model, Shapes shapes)
        {
            _model = model;
            _shapes = shapes;
        }

        // 壓下滑鼠-繪畫
        public void MouseDown(double pointX, double pointY, string shapeType, int index)
        {
            _originShapes = _shapes.CopyDeep();
            FirstPointX = pointX;
            FirstPointY = pointY;
            _shapes.SetHintType(shapeType);
            _shapes.SetHint(FirstPointX, FirstPointY, FIRST);
            _shapes.SetHint(FirstPointX, FirstPointY, END);
            _index = index;
        }

        // 滑鼠移動-繪畫
        public void MouseMove(double pointX, double pointY)
        {
            _shapes.SetHint(pointX, pointY, END);
        }

        // 放開滑鼠-繪畫
        public void MouseUp()
        {
            _shapes.SetGraph();
            Shapes currentShapes = _shapes.CopyDeep();
            _shapes.InitializeHint();
            
            _model._commandManager.Execute(
                new DrawCommand(_model, _originShapes, currentShapes, _index)
            );

            _model.NotifyModelChanged();
        }
    }
}
