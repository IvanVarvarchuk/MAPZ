using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions.Binary
{
    public class AdditionExpression : BinaryExpression
    {
        public override dynamic Evaluate(Context context)
        {
            var leftOperand = left.Evaluate(context);
            var rightOperand = right.Evaluate(context);

            ApendSyntaxTrre(context);

            return leftOperand + rightOperand;
        }

        private void ApendSyntaxTrre(Context context)
        {
            var node = new ASTNode("Addition","+");
            context.SyntaxTree.Add(node);
        }
    }
}
