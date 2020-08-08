using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _224.Basic_Calculator
{
    public class JswCalculator
    {
        private Dictionary<string, int> precedenceTable;
        private string tokenPattern;
        private Dictionary<string, Decimal> symbolTable;
        public JswCalculator() : this(null, null, null) { }

        public JswCalculator(Dictionary<string, int> precedenceTable, string tokenPattern, Dictionary<string, decimal> symbolTable)
        {
            this.precedenceTable = precedenceTable ?? new Dictionary<string, int> { { "+", 1 }, { "-", 1 }, { "*", 2 }, { "/", 2 }, { "%", 2 }, { "^", 3 }, { "(", 1000 }, { ")", -1000 }, { "=", 0 } };
            this.tokenPattern = tokenPattern ?? @"(?<val>\d+(\.\d+)?)|(?<op>\+|\-|\*|\\|\(|\)|\^|%|=)|(?<var>[A-Za-z]\w*)";
            this.symbolTable = symbolTable ?? new Dictionary<string, Decimal>();
        }

        public List<Token> GetTokens(string input)
        {
            Regex regex = new Regex(tokenPattern);
            var cleanInput = input.Replace(" ", "");
            var mc = regex.Matches(cleanInput);
            List<Token> result = new List<Token>();
            StringBuilder sb = new StringBuilder();
            foreach (Match m in mc)
            {
                Token token = null;
                if (m.Groups["op"].Success)
                {
                    token = new Token(m.Value);
                }
                else if (m.Groups["var"].Success)
                {
                    var tmp = 0m;
                    if (symbolTable.ContainsKey(m.Value))
                        tmp = symbolTable[m.Value];
                    token = new Token(m.Value, tmp);
                }
                else
                {
                    token = new Token(Decimal.Parse(m.Value));
                }
                sb.Append(m.Value);
                result.Add(token);
            }
            if (sb.ToString() != cleanInput)
            {
                throw new Exception("fail to get all tokens");
            }
            return result;
        }

        private Decimal GetValue(Token v)
        {
            if (v.tkType == TokenType.Val)
                return v.val;
            if (v.tkType == TokenType.Var)
                return symbolTable[v.op];
            throw new Exception("fail to get value ");
        }

        private void Compute(Token t, Stack<Token> opStack, Stack<Token> valStack)
        {
            if (opStack.Count == 0)
                return;
            if (valStack.Count == 0)
                return;
            while (opStack.Count > 0 && precedenceTable[t.op] <= precedenceTable[opStack.Peek().op] && (opStack.Peek().op != "("))
            {
                Token opToken = opStack.Pop();
                Token b = valStack.Pop();
                Token a = valStack.Pop();
                switch (opToken.op)
                {
                    case "+":
                        valStack.Push(new Token(GetValue(a) + GetValue(b)));
                        break;
                    case "-":
                        valStack.Push(new Token(GetValue(a) - GetValue(b)));
                        break;
                    case "*":
                        valStack.Push(new Token(GetValue(a) * GetValue(b)));
                        break;
                    case "/":
                        valStack.Push(new Token(GetValue(a) / GetValue(b)));
                        break;
                    case "%":
                        valStack.Push(new Token(GetValue(a) % GetValue(b)));
                        break;
                    case "^":
                        valStack.Push(new Token((decimal)Math.Pow((double)GetValue(a), (double)GetValue(b))));
                        break;
                    case "=":
                        symbolTable[a.op] = GetValue(b);
                        a.val = GetValue(b);
                        valStack.Push(a);
                        return;
                }
            }
        }

        public Decimal EvaluateExpression(List<Token> tokens)
        {
            Stack<Token> opStack = new Stack<Token>();
            Stack<Token> valStack = new Stack<Token>();

            foreach (Token t in tokens)
            {
                if (t.tkType == TokenType.OP)
                {
                    Compute(t, opStack, valStack);
                    if (opStack.Count > 0 && (opStack.Peek().op == "(" && t.op == ")"))
                    {
                        opStack.Pop();
                        continue;
                    }
                    opStack.Push(t);
                }
                else
                {
                    valStack.Push(t);
                }
            }
            while (opStack.Count > 0)
            {
                Compute(opStack.Peek(), opStack, valStack);
            }
            return GetValue(valStack.Pop());
        }
    }
}
