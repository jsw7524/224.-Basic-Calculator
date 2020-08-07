using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _224.Basic_Calculator
{

    public class Solution
    {
        public int Calculate(string s)
        {
            JswCalculator JswCalculator = new JswCalculator();
            var Tokens = JswCalculator.GetTokens(s);
            return int.Parse(JswCalculator.EvaluateExpression(Tokens).ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Example
            //JswCalculator JswCalculator = new JswCalculator();
            //var Tokens = JswCalculator.GetTokens("2-4-(8+2-6+(8+4-(1)+8-10))");
            //JswCalculator.EvaluateExpression(Tokens);
        }
    }
}
