using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions.Unary
{
    public class PrintExpression : UnaryExpression
    {
        public override dynamic Evaluate (Context context)
        {
            var toPrint = Operand.Evaluate(context);
            context.Output = context.VariablesTable[toPrint]+ "\r\n";
            return null;
        }
    }
}
