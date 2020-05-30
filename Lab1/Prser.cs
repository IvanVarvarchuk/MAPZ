using Interpreter24.Expressions;
using Interpreter24.LexicalAnalize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter24
{
    public class Prser
    {
        private List<Token> Tokens ;

        private int position;

        private Token Current() => Peek(0);

        private Token Peek(int n) => Tokens[position + n];

        private bool IsTypeMatch(TokenType type) => Current().Type == type;

        private Token Take()
        {
            Token current = Current();
            position++;
            return current;
        }

        private Context Context ;

        public Prser(List<Token> tokens, Context context)
        {
            Tokens = tokens;
            Context = context;
        }

        

        public List<IExpression> Parse() 
        {
            throw new NotImplementedException();
        }



    }
}
