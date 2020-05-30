using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions
{
    public interface IExpression
    {
        dynamic Evaluate(Context context);
    }
}
