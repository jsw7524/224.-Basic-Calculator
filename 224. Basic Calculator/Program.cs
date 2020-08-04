using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _224.Basic_Calculator
{
    public enum TokenType
    {
        OP,
        Val,
        Var
    }
    public class Token
    {
        public string op;
        public decimal val;
        public TokenType tkType;
        public Token(decimal d)
        {
            val = d;
            tkType = TokenType.Val;
        }
        public Token(string s)
        {
            op = s;
            tkType = TokenType.OP;
        }
        public Token(string variableName, decimal value)
        {
            op = variableName;
            val = value;
            tkType = TokenType.Var;
        }
    }

    public class MyCalculator
    {
        public Dictionary<string, int> precedenceTable = new Dictionary<string, int>
        {
            {"+",1},{"-",1},{"*",2},{"/",2},{"%",2},{"^",3},{"(",1000},{")",-1000},{"=",0}
        };

        public Dictionary<string, Decimal> symbolTable = new Dictionary<string, Decimal>();

        public List<Token> GetTokens(string input)
        {
            Regex regex = new Regex(@"(?<val>\d+)|(?<op>\+|\-|\*|\\|\(|\)|\^|%|=)|(?<var>[A-Za-z]\w*)");

            var mc = regex.Matches(input.Replace(" ", ""));
            List<Token> result = new List<Token>();
            foreach (Match m in mc)
            {
                Token token = null;
                if (m.Groups["op"].Success)
                {
                    token = new Token(m.Value);
                }
                else if (m.Groups["var"].Success)
                {
                    token = new Token(m.Value,0);
                }
                else
                {
                    token = new Token(Decimal.Parse(m.Value));
                }
                result.Add(token);
            }
            return result;
        }

        private Decimal GetValue(Stack<Token> valStack)
        {
            var v = valStack.Pop();
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
                if (opToken.op == "=")
                {
                    var d = GetValue(valStack);
                    var varToken = valStack.Pop();
                    var varName = varToken.op;
                    symbolTable[varName] = d;
                    varToken.val = d;
                    valStack.Push(varToken);
                    return;
                }
                Decimal b = GetValue(valStack);
                Decimal a = GetValue(valStack);
                switch (opToken.op)
                {
                    case "+":
                        valStack.Push(new Token(a + b));
                        break;
                    case "-":
                        valStack.Push(new Token(a - b));
                        break;
                    case "*":
                        valStack.Push(new Token(a * b));
                        break;
                    case "/":
                        valStack.Push(new Token(a / b));
                        break;
                    case "%":
                        valStack.Push(new Token(a % b));
                        break;
                    case "^":
                        valStack.Push(new Token((decimal)Math.Pow((double)a, (double)b)));
                        break;
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
            return GetValue(valStack);
        }
    }

    public class Solution
    {
        public int Calculate(string s)
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens(s);
            return int.Parse(myCalculator.EvaluateExpression(Tokens).ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Example
            //MyCalculator myCalculator = new MyCalculator();
            //var Tokens = myCalculator.GetTokens("2-4-(8+2-6+(8+4-(1)+8-10))");
            //myCalculator.EvaluateExpression(Tokens);
        }
    }
}
