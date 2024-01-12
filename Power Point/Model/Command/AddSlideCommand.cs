using System;
using System.Drawing;

namespace Power_Point
{
    public class AddSlideCommand : ICommand
    {
        private readonly PowerPointModel _model;
        Pages _pages;
        int _index;

        public AddSlideCommand(PowerPointModel model, Pages pages, int index)
        {
            _model = model;
            _pages = pages;
            _index = index;
        }

        // Execute
        public void Execute()
        {
            _pages.AddPage(_index);
            _model.NotifyModelChanged();
        }

        // Revoke
        public void Revoke()
        {
            _model.CurrentSlideIndex = _index - 1;
            _pages.DeletePage(_index - 1);
            _model.NotifyModelChanged();
        }
    }
}
