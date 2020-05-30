using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24.LexicalAnalize
{
    public class Token
    {
        public int LineNumber { get; set; }
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"LineNumber:{LineNumber} TokenType:{Type} Value::{Value}\r\n";
        }
    }

    public enum TokenType 
    {
        Function,
        Constant,
        Assignition,
        Addition,
        Subtraction,
        Division,
        Multiplication,
        Keyword,
        Less,
        //LessOrEqual,
        Greater,
        //GreaterOrEqual,
        Equal,
        Type,
        InstructionEnd,
        OpenBrace,
        CloseBrace,
        OpenBracket,
        CloseBracket,
        InapropriateToken,
        Space,
        Comma,
        Variable
    }
}
