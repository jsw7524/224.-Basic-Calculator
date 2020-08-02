﻿using System;
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
        Val
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
    }

    public class MyCalculator
    {
        public Dictionary<string, int> precedenceTable = new Dictionary<string, int>
        {
            {"+",1},{"-",1},{"*",2},{"/",2},{"(",1000},{")",-1000}
        };

        public List<Token> GetTokens(string input)
        {
            Regex regex = new Regex(@"(?<val>\d+)|(?<op>\+|\-|\*|\\|\(|\))");
            var mc = regex.Matches(input.Replace(" ", ""));
            List<Token> result = new List<Token>();
            foreach (Match m in mc)
            {
                Token token = null;
                if (m.Groups["op"].Success)
                {
                    token = new Token(m.Value);
                }
                else
                {
                    token = new Token(Decimal.Parse(m.Value));
                }
                result.Add(token);
            }
            return result;
        }

        private void Compute(Token t, Stack<Token> opStack, Stack<Token> valStack)
        {
            while (precedenceTable[t.op] <= precedenceTable[opStack.Peek().op] )
            {
                Token opToken = opStack.Pop();
                if (opToken.op == "(")
                    return;
                Decimal b = valStack.Pop().val;
                Decimal a = valStack.Pop().val;
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
                }
                if (opStack.Count == 0)
                    return;
            }
        }

        public Decimal EvaluateExpression(List<Token> tokens)
        {
            Stack<Token> opStack = new Stack<Token>();
            Stack<Token> valStack = new Stack<Token>();

            if (tokens.FirstOrDefault().tkType == TokenType.OP)
                opStack.Push(tokens.FirstOrDefault());
            else
                valStack.Push(tokens.FirstOrDefault());

            foreach (Token t in tokens.Skip(1))
            {
                if (t.tkType == TokenType.OP)
                {
                    if (valStack.Count >= 2)
                        Compute(t, opStack, valStack);
                    if (t.op != ")")
                        opStack.Push(t);
                }
                else if (t.tkType == TokenType.Val)
                {
                    valStack.Push(t);
                }
            }
            while (opStack.Count > 0)
            {
                Token t = opStack.Peek();
                Compute(t, opStack, valStack);
            }
            return valStack.FirstOrDefault().val;
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
        }
    }
}
