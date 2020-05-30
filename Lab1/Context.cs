using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24
{
    public class Context
    {
        public Context()
        {
            SyntaxTree = new ObservableCollection<ASTNode>();
            VariablesTable = new Dictionary<string, string>();
            output = new StringBuilder();
        }

        public ObservableCollection<ASTNode> SyntaxTree { get; private set; }

        public Dictionary<string, string> VariablesTable { get; private set; }

        private StringBuilder output;

        public string Output 
        {
            get { return output.ToString(); }
            set { output.Append(value); }
        }

        public bool IsExistInContext(string item) => VariablesTable.ContainsKey(item);

    }
}
