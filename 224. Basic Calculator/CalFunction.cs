using System;
using System.Collections.Generic;

namespace _224.Basic_Calculator
{
    public class CalFunction
    {
        public string name;
        public int precedence;
        public int operandNumber;
        public Func<List<Token>, Token> f;
    }
}
