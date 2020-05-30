using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions
{
    public class ConstsntExpression : IExpression
    {

        private dynamic _value;

        public ConstsntExpression(string value)
        {
            int temp = 0;

            if (Int32.TryParse(value, out temp))
                _value = temp;
            else
                _value = value;
        }

        public dynamic Evaluate(Context context)
        {
            return _value;            
        }
    }
}
