using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions.Binary
{
    class SubstructionExpression : BinaryExpression
    {
        public override dynamic Evaluate(Context context)
        {
            return left.Evaluate(context) - right.Evaluate(context);
        }
    }
}
