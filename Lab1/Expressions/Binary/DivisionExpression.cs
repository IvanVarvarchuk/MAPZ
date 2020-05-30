using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions.Binary
{
    public class DivisionExpression : BinaryExpression
    {
        public override dynamic Evaluate(Context context)
        {
            return left.Evaluate(context) / (float)right.Evaluate(context);
        }
    }
}
