using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Power_Point
{
    public class CommandManager
    {
        readonly Stack<ICommand> _undo = new Stack<ICommand>();
        readonly Stack<ICommand> _redo = new Stack<ICommand>();

        // Execute
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        // Undo
        public void Undo()
        {
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.Revoke();
        }

        // Redo
        public void Redo()
        {
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
