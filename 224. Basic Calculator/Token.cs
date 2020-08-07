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
}
