using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions.Binary
{
    public class FindAllExpression : BinaryExpression
    {

        public override dynamic Evaluate(Context context)
        {
            var toFindPath = context.VariablesTable[left.Evaluate(context)];
            var fileMask = context.VariablesTable[right.Evaluate(context)];

            var directories = Directory.GetFiles(toFindPath, fileMask, SearchOption.AllDirectories);

            if (directories == null)
            {
                context.Output = $"In {toFindPath} any {fileMask} was found.\r\n";
                return false;
            }
            else
            {
                foreach (string dir in directories)
                {
                    context.Output = $"Found in {dir} \r\n";
                }

                return true;

            }
        }
    }
}
