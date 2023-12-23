using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Power_Point
{
    public interface ICommand
    {
        // Execute
        void Execute();
        // Revoke
        void Revoke();
    }
}
