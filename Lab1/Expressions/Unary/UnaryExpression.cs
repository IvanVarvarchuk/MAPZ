using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions
{
    public abstract class UnaryExpression : IExpression
    {
        public IExpression Operand { get; private set; }

        public abstract dynamic Evaluate(Context context);
    }
}
