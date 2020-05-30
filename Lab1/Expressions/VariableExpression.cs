using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions
{
    class VariableExpression : IExpression
    {
        public VariableExpression(string id)
        {
            idenifier = id;
            
        }
        private string idenifier;
        private dynamic _value;

        public dynamic Evaluate(Context context)
        {
            if (!context.VariablesTable.ContainsKey(idenifier))
            {
                context.VariablesTable.Add(idenifier, String.Empty);
            }
            return idenifier;
        }
    }
}
