using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _224.Basic_Calculator
{
    public class JswCalculator
    {
        private Dictionary<string, CalFunction> precedenceTable;
        private string tokenPattern;
        private Dictionary<string, Decimal> symbolTable;
        public JswCalculator() : this(null, null, null) { }

        public JswCalculator(Dictionary<string, CalFunction> precedenceTable, string tokenPattern, Dictionary<string, decimal> symbolTable)
        {
            //tokens[0] is b
            //tokens[1] is a
            this.precedenceTable = precedenceTable ?? new Dictionary<string, CalFunction>
            { { "+", new CalFunction { name="+", precedence=1,operandNumber=2,f=tokens=>new Token(tokens[1].val+tokens[0].val)} },
              { "-", new CalFunction { name="-", precedence=1,operandNumber=2,f=tokens=>new Token(tokens[1].val-tokens[0].val)} },
              { "*", new CalFunction { name="*", precedence=2,operandNumber=2,f=tokens=>new Token(tokens[1].val*tokens[0].val)} },
              { "/", new CalFunction { name="/", precedence=2,operandNumber=2,f=tokens=>new Token(tokens[1].val/tokens[0].val)} },
              { "%", new CalFunction { name="%", precedence=2,operandNumber=2,f=tokens=>new Token(tokens[1].val%tokens[0].val)} },
              { "^", new CalFunction { name="^", precedence=3,operandNumber=2,f=tokens=>new Token((decimal)Math.Pow((double)tokens[1].val, (double)tokens[0].val))}},
              { "(", new CalFunction { name="(", precedence=1000,operandNumber=0,f=null} },
              { ")", new CalFunction { name=")", precedence=-1000,operandNumber=0,f=null} },
              { ",", new CalFunction { name=",", precedence=-1,operandNumber=0,f=null} },//unsupported
              { "=", new CalFunction { name="=", precedence=0,operandNumber=2,f=tokens=>
                                            {
                                                this.symbolTable[tokens[1].op] =  GetValue(tokens[0]);
                                                tokens[1].val = GetValue(tokens[0]);
                                                return tokens[1];
                                            }  } },
              { "NEG", new CalFunction { name="NEG", precedence=4,operandNumber=1,f=tokens=>new Token(-1*tokens[0].val)} },
              { "ABS", new CalFunction { name="ABS", precedence=4,operandNumber=1,f=tokens=>new Token(Math.Abs(tokens[0].val))} },
              { "SQRT", new CalFunction { name="SQRT", precedence=4,operandNumber=1,f=tokens=>new Token((decimal)Math.Sqrt((double)tokens[0].val))} },

            };
            this.tokenPattern = tokenPattern ?? @"(?<val>\d+(\.\d+)?)|(?<op>\+|\-|\*|\/|\(|\)|\^|%|=)|(?<var>[a-z]\w*)|(?<func>[A-Z]+)";
            this.symbolTable = symbolTable ?? new Dictionary<string, Decimal>() { { "e", (Decimal)Math.E }, { "pi", (Decimal)Math.PI } };
        }

        public List<Token> GetTokens(string input)
        {
            Regex regex = new Regex(tokenPattern);
            var cleanInput = "(" + input.Replace(" ", "") + ")";
            var mc = regex.Matches(cleanInput);
            List<Token> result = new List<Token>();
            StringBuilder sb = new StringBuilder();
            foreach (Match m in mc)
            {
                Token token = null;
                if (m.Groups["op"].Success || m.Groups["func"].Success)
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
            throw new Exception("fail to get value");
        }

        private void Compute(Token t, Stack<Token> opStack, Stack<Token> valStack)
        {
            if (opStack.Count == 0)
                return;
            if (valStack.Count == 0)
                return;
            while (opStack.Count > 0 && precedenceTable[t.op].precedence <= precedenceTable[opStack.Peek().op].precedence && (opStack.Peek().op != "("))
            {
                Token opToken = opStack.Pop();
                if (precedenceTable[opToken.op].f != null)
                {
                    List<Token> parameters = new List<Token>();
                    for (int i = 0; i < precedenceTable[opToken.op].operandNumber; i++)
                    {
                        parameters.Add(valStack.Pop());
                    }
                    Token result = precedenceTable[opToken.op].f(parameters);
                    valStack.Push(result);
                }
            }
        }

        public Decimal EvaluateExpression(string expr)
        {
            var Tokens = GetTokens(expr);
            return EvaluateExpression(Tokens);
        }

        public Decimal EvaluateExpression(List<Token> tokens)
        {
            Stack<Token> opStack = new Stack<Token>();
            Stack<Token> valStack = new Stack<Token>();
            valStack.Push(new Token(0m));
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
            return GetValue(valStack.Pop());
        }
    }
}
