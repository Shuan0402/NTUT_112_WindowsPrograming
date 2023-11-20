using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
public class BindableToolStripButton : ToolStripButton, IBindableComponent
{

    public BindableToolStripButton() : base() 
    { 
    }
    public BindableToolStripButton(String text) : base(text) 
    {
    }
    public BindableToolStripButton(System.Drawing.Image image) : base(image) 
    {
    }
    public BindableToolStripButton(String text, System.Drawing.Image image) : base(text, image)
    { 
    }
    public BindableToolStripButton(String text, System.Drawing.Image image, EventHandler onClick) : base(text, image, onClick)
    {
    }
    public BindableToolStripButton(String text, System.Drawing.Image image, EventHandler onClick, String name) : base(text, image, onClick, name)
    {
    }

    #region IBindableComponent Members
    private BindingContext _bindingContext;
    private ControlBindingsCollection _dataBindings;

    [Browsable(false)]
    public BindingContext BindingContext
    {
        get
        {
            if (_bindingContext == null)
            {
                _bindingContext = new BindingContext();
            }
            return _bindingContext;
        }
        set
        {
            _bindingContext = value;
        }
    }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ControlBindingsCollection DataBindings
    {
        get
        {
            if (_dataBindings == null)
            {
                _dataBindings = new ControlBindingsCollection(this);
            }
            return _dataBindings;
        }
    }
    #endregion

}