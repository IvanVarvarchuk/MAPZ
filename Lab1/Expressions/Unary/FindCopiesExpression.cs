using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.Expressions.Unary
{
       
    class FindCopiesExpression : UnaryExpression
    {
        public override dynamic Evaluate(Context context)
        {
            string toFinPpath = context.VariablesTable[Operand.Evaluate(context)];

            var allFilesList = Directory.GetFiles(toFinPpath, "*.*", SearchOption.AllDirectories);
            
            int filesCount = allFilesList.Length;

            List<(string name, string hash)> finalDetails = new List<(string name, string hash)>();
            
            List<string> toDelete = new List<string>();
            
            finalDetails.Clear();
            
            foreach (var item in allFilesList)
            {
                using (var fs = new FileStream(item, FileMode.Open, FileAccess.Read))
                {
                    var elem = (name:item, hash:BitConverter.ToString(SHA1.Create().ComputeHash(fs)));
                    finalDetails.Add(elem);
                }
            }
            
            var similarList = finalDetails
                .GroupBy(f => f.hash)
                .Select(g => new { FileHash = g.Key, Files = g.Select(z => z.name).ToList() });
            
            toDelete.AddRange(similarList.SelectMany(f => f.Files.Skip(1)).ToList());
            
            context.Output= $"Total copies files {toDelete.Count} \r\n";
            
            foreach (string deleted in toDelete)
            {
                context.Output =$"{deleted} \r\n";
            }
            return null;
        }
    }
}
