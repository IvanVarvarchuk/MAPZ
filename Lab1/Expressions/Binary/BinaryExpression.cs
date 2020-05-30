using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions
{
    public abstract class BinaryExpression : IExpression
    {
        protected IExpression left;

        protected IExpression right;

        public abstract dynamic Evaluate(Context context);
    }
}
