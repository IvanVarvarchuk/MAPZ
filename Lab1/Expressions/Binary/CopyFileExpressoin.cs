using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions.Binary
{
    public class CopyFileExpressoin : BinaryExpression
    {
        public override dynamic Evaluate(Context context)
        {
            var sourcePath = context.VariablesTable[left.Evaluate(context)];
            var destinitionPath = context.VariablesTable[right.Evaluate(context)];

            FileInfo fileInfo = new FileInfo(sourcePath);
            if (fileInfo.Exists)
            {
                fileInfo.CopyTo(destinitionPath, true);
                context.Output = $"File ftom {sourcePath} is copied to {destinitionPath} .\r\n";
                return true;
            }
            else
            {
                context.Output = $"File {sourcePath} is not exist.\r\n";
                return false;
            }
        }
    }
}
