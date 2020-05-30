using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interpreter24.LexicalAnalize
{
    public class Lexer
    {
        private string[] Separators = { " ", "+", "==", ",", "=", ";", "{", "}", "(", ")" };
        private string[] Keywords = { "while", "times", "if", "as" };
        private string[] Functions = { "Copy", "BackUp", "Delete", "FindAll", "Create", "MoveTo", "FindCopy" };
        private string[] Types = { "file", "int", "string", "stringlist"};

        public string SourceText { get; set; }

        public Lexer(string sourceText)
        {
            SourceText = sourceText;
        }

        public List<Token> Tokenize() 
        {
            var text = RemoveComments();

            var lines = SplitLines(text);

            var tokens = new List<Token>();

            foreach (var line in lines)
            {
                tokens.AddRange(GetTokens(line.Value, lineNumber: line.Key));
            }

            tokens.RemoveAll((t) => t.Type == TokenType.Space);

            return tokens;
        }

        private string RemoveComments() 
        {
            var multyiline = new Regex(@"(/\*[\w\W]*\*/)");
            var singleline = new Regex(@"(//((?!\*/).)*)(?!\*/)[^\r\n]");

            var source = SourceText;
            
            source = multyiline.Replace(source, String.Empty);
            source = singleline.Replace(source, String.Empty);
            
            return source;
        }
        
        private Dictionary<int, string> SplitLines(string text)
        {
            var allLines = text.Replace("\r", String.Empty).Split('\n').ToList();
            var actualLines = new Dictionary<int, string>();
            for (int i = 0; i < allLines.Count; i++)
            {
                if (SourceText.Contains(allLines[i])) 
                {
                    actualLines.Add(i + 1, allLines[i]);
                }
            }
            return actualLines;
        }
        
        private List<Token> GetTokens(string line, int lineNumber)
        {
            var lineTokens = new List<Token>();


            while (line.Length > 0)
            {
                int sepIndex = MinSeparatorIndex(line);
                if (sepIndex == Int32.MaxValue)
                {
                    lineTokens.Add(new Token()
                    {
                        LineNumber = lineNumber,
                        Type = GetTokenType(line, line),
                        Value = line
                    });
                    line = "";
                }
                else if (sepIndex == 0 && line[sepIndex] != '\"')
                {
                    lineTokens.Add(new Token()
                    {
                        LineNumber = lineNumber,
                        Type = GetSeparatorTokenType(line[sepIndex].ToString()),
                        Value = line[sepIndex].ToString()
                    });

                    line = line.Substring(sepIndex + 1);
                }
                else if (line[sepIndex] == '\"')
                {
                    string token = "\"";
                    int k = 0;
                    for (int i = sepIndex + 1; i < line.Length; i++)
                    {
                        if (line[i] != '\"')
                        {
                            token += line[i];
                            k++;
                        }
                        else
                        {
                            k++;
                            token += "\"";
                            break;
                        }
                    }
                    lineTokens.Add(new Token()
                    {
                        LineNumber = lineNumber,
                        Value = token,
                        Type = GetTokenType(token, line.Substring(0, k + 1))
                    });
                    line = line.Substring(k + 1);

                }
                else
                {
                    string token = line.Substring(0, sepIndex);

                    lineTokens.Add(new Token()
                    {
                        LineNumber = lineNumber,
                        Value = token,
                        Type = GetTokenType(token, line.Substring(sepIndex))
                    });
                    line = line.Substring(sepIndex);
                }
            }



            return lineTokens;
        }
        
        private int MinSeparatorIndex(string text)
        {
            int index = int.MaxValue;
            for (int i = 0; i < Separators.Length; i++)
            {
                int sepIndex = text.IndexOf(Separators[i]);
                if (sepIndex < index && sepIndex != -1)
                {
                    index = sepIndex;
                }
            }

            return index;
        }

        private TokenType GetTokenType(string token, string text)
        {
            if (IsKeyword(token)) return TokenType.Keyword;
            if (IsVariableType(token)) return TokenType.Type;
            if (IsConstant(token)) return TokenType.Constant;
            if (IsFunction(token)) return TokenType.Function;

            return TokenType.Variable;
        }
        
        private static TokenType GetSeparatorTokenType(string token)
        {
            switch (token)
            {
                case "+": { return TokenType.Addition; }
                case "-": { return TokenType.Subtraction; }
                case "/": { return TokenType.Division; }
                case "*": { return TokenType.Multiplication; }
                case "=": { return TokenType.Assignition; }
                case "==": { return TokenType.Equal; }
                case ",": { return TokenType.Comma; }
                case "(": { return TokenType.OpenBracket; }
                case ")": { return TokenType.CloseBracket; }
                case "{": { return TokenType.OpenBrace; }
                case "}": { return TokenType.CloseBrace; }
                case ";": { return TokenType.InstructionEnd; }
                case " ": { return TokenType.Space; }
                default: return TokenType.InapropriateToken;
            }
        }

        private bool IsConstant(string token)
        {
            int res;
            if (int.TryParse(token, out res))
            {
                return true;
            }
            else if (token[0] == '"' && token[token.Length - 1] == '"')
            {
                return true;
            }
            else
            return false;
        }

        private bool IsKeyword(string token) => Keywords.Contains(token);

        private bool IsVariableType(string token) => Types.Contains(token);
        
        private bool IsFunction(string token) => Functions.Contains(token);

    }
}
