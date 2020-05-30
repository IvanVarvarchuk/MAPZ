using Interpreter24.LexicalAnalize;
using System.Collections.ObjectModel;

namespace Interpreter24
{
    public class ASTNode
    {
        public ASTNode()
        {
            Children = new ObservableCollection<ASTNode> ();
        }

        public ASTNode(string nodeType, string value)
        {
            NodeType = nodeType;
            Value = value;
            Children = new ObservableCollection<ASTNode> ();
        }

        public string NodeType { get; set; }

        public string Value { get; set; }

        public ObservableCollection<ASTNode> Children { get; set; }

    }
}