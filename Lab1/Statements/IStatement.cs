using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Statements
{
    public interface IStatement
    {
        IStatement Next { get; set; }

        void Execute();
    }
}
