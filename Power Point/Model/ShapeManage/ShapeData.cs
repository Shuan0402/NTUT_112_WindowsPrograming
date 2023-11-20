using System;

namespace Power_Point
{
    public class ShapeData
    {
        public string Name 
        { 
            get;
            set;
        }
        public string Info 
        { 
            get;
            set; 
        }

        public ShapeData(string name, string info)
        {
            Name = name;
            Info = info;
        }
    }

}
