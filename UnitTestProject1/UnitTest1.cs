using System;
using System.Collections.Generic;
using _224.Basic_Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod0()
        {

            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1+2^30");
            Assert.AreEqual(5 + 2, Tokens.Count);//+2 for auto add ( )
        }
        [TestMethod]
        public void TestMethod1()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var result = jswCalculator.GetTokens("(1+43)");
            Assert.AreEqual(5 + 2, result.Count);//+2 for auto add ( )
        }
        [TestMethod]
        public void TestMethod2()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var result = jswCalculator.GetTokens("(1+(43+515 +2)- 35)+( 26 +8)");
            Assert.AreEqual(19 + 2, result.Count);//+2 for auto add( )
        }
        [TestMethod]
        public void TestMethod3()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var result = jswCalculator.GetTokens("1");
            Assert.AreEqual(1 + 2, result.Count);//+2 for auto add( )
        }

        [TestMethod]
        public void TestMethod4()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1+2");
            Assert.AreEqual(3, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod5()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1+2+3");
            Assert.AreEqual(6, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod6()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1+2*3");
            Assert.AreEqual(7, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod7()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1+2*3+4");
            Assert.AreEqual(11, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod8()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1+2*3-4");
            Assert.AreEqual(3, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod9()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("(1+2)*3-4");
            Assert.AreEqual(5, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod10()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("(1+2)*(9-4)");
            Assert.AreEqual(15, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod11()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("(1+(43+515 +2)- 35)+( 26 +8)");
            Assert.AreEqual(560, jswCalculator.EvaluateExpression(Tokens));
        }

        [TestMethod]
        public void TestMethod12()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("2-(5-6-7)");
            Assert.AreEqual(10, jswCalculator.EvaluateExpression(Tokens));
        }

        [TestMethod]
        public void TestMethod13()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("2-4-(8+2-6+(8+4-(1)+8-10))");
            Assert.AreEqual(-15, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod14()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("2^3");
            Assert.AreEqual(8, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod15()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1+2^3*2-(5*2)");
            Assert.AreEqual(7, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod16()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1+2^10");
            Assert.AreEqual(1025, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod17()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("15%4");
            Assert.AreEqual(3, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod18()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("(2+3*5)%4");
            Assert.AreEqual(1, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod19()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("a=1");
            Assert.AreEqual(1, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod20()
        {
            JswCalculator jswCalculator = new JswCalculator();
            jswCalculator.EvaluateExpression("a=1");
            Assert.AreEqual(3, jswCalculator.EvaluateExpression("2+a"));
        }

        [TestMethod]
        public void TestMethod21()
        {
            JswCalculator jswCalculator = new JswCalculator();
            jswCalculator.EvaluateExpression("a7=1 + 2 ^ 3 * 2 - (5 * 2)");
            Assert.AreEqual(574, jswCalculator.EvaluateExpression("(1 + (43+ a7 + 515 + 2) - 35) + (26 + 8)+a7"));
        }

        [TestMethod]
        public void TestMethod22()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens1 = jswCalculator.GetTokens("a7=1 + 2 ^ 3 * 2 - (5 * 2)");
            jswCalculator.EvaluateExpression(Tokens1);
            var Tokens2 = jswCalculator.GetTokens("a574=(1 + (43+ a7 + 515 + 2) - 35) + (26 + 8)+a7");
            jswCalculator.EvaluateExpression(Tokens2);
            var Tokens3 = jswCalculator.GetTokens("a595=a574 + 3*a7");
            Assert.AreEqual(595, jswCalculator.EvaluateExpression(Tokens3));
        }

        [TestMethod]
        public void TestMethod23()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens1 = jswCalculator.GetTokens("1.5+2.1");
            jswCalculator.EvaluateExpression(Tokens1);
            Assert.AreEqual(3.6m, jswCalculator.EvaluateExpression(Tokens1));
        }

        [TestMethod]
        public void TestMethod24()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1*(1.349+2.33)*0.3-1.0*4");
            Assert.AreEqual(-2.8963m, jswCalculator.EvaluateExpression(Tokens));
        }

        [TestMethod]
        public void TestMethod25()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("2.0^3.5");
            Assert.AreEqual(11.3137084989848m, jswCalculator.EvaluateExpression(Tokens));
        }

        [TestMethod]
        public void TestMethod26()
        {
            Dictionary<string, decimal> saved = new Dictionary<string, decimal> { { "a", 1.1m } };
            JswCalculator jswCalculator = new JswCalculator(null, null, saved);
            var Tokens = jswCalculator.GetTokens("2+a");
            Assert.AreEqual(3.1m, jswCalculator.EvaluateExpression(Tokens));
        }

        [TestMethod]
        public void TestMethod27()
        {
            Dictionary<string, OperatorFunction> specialPrecedence = new Dictionary<string, OperatorFunction> {
              { "+", new OperatorFunction { name="+", precedence=2,operandNumber=2,f=tokens=>new Token(tokens[1].val+tokens[0].val)} },
              { "-", new OperatorFunction { name="-", precedence=2,operandNumber=2,f=tokens=>new Token(tokens[1].val-tokens[0].val)} },
              { "*", new OperatorFunction { name="*", precedence=1,operandNumber=2,f=tokens=>new Token(tokens[1].val*tokens[0].val)} },
              { "/", new OperatorFunction { name="/", precedence=1,operandNumber=2,f=tokens=>new Token(tokens[1].val/tokens[0].val)} },
              { "(", new OperatorFunction { name="(", precedence=1000,operandNumber=0,f=null} },
              { ")", new OperatorFunction { name=")", precedence=-1000,operandNumber=0,f=null} },};
            JswCalculator jswCalculator = new JswCalculator(specialPrecedence, null, null);
            var Tokens = jswCalculator.GetTokens("1+2*3+4");
            Assert.AreEqual((1 + 2) * (3 + 4), jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod28()
        {
            string syntax = @"(?<val>\d+\.\d+)|(?<op>\+|\-|\*|\/|\(|\)|\^|%|=)|(?<var>[A-Za-z]\w*)";
            JswCalculator jswCalculator = new JswCalculator(null, syntax, null);
            var Tokens = jswCalculator.GetTokens("1+2*3+4");
            jswCalculator.EvaluateExpression(Tokens);
        }
        [TestMethod]
        public void TestMethod29()
        {
            string syntax = @"(?<val>\d+\.\d+)|(?<op>\+|\-|\*|\/|\(|\)|\^|%|=)|(?<var>[A-Za-z]\w*)";
            JswCalculator jswCalculator = new JswCalculator(null, syntax, null);
            var Tokens = jswCalculator.GetTokens("1.0+2.0*3.0+4.0");
            Assert.AreEqual(11m, jswCalculator.EvaluateExpression(Tokens));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod30()
        {
            string syntax = @"(?<val>\d+\.\d+)|(?<op>\+|\-|\*|\/|\(|\)|\^|%|=)|(?<var>[A-Za-z]\w*)";
            JswCalculator jswCalculator = new JswCalculator(null, syntax, null);
            var Tokens = jswCalculator.GetTokens("1.0+2.0*3.0+4");
        }

        [TestMethod]
        public void TestMethod31()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("NEG(3)");
            Assert.AreEqual(-3m, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod32()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("10+2*NEG(3)");
            Assert.AreEqual(4m, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod33()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("ABS(NEG(3))");
            Assert.AreEqual(3m, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod34()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("5*ABS(6-NEG(10))");
            Assert.AreEqual(80m, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod35()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("SQRT(16)");
            Assert.AreEqual(4m, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod36()
        {
            JswCalculator jswCalculator = new JswCalculator();
            var Tokens = jswCalculator.GetTokens("1+SQRT(16)*2");
            Assert.AreEqual(9m, jswCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod37()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(28.27433388230811m, jswCalculator.EvaluateExpression("pi*3^2"));
        }

        [TestMethod]
        public void TestMethod38()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(0.0000814939159201454283421497m, jswCalculator.EvaluateExpression("((((19) / 61))) / (65 / 97 * 88 * 75 / 81 * (70))"));
        }


        [TestMethod]
        public void TestMethod39()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(4.0807828945168009283518119874m, jswCalculator.EvaluateExpression("(59 * 32 + 69 + 72 / 86) / ((15 * 38) + (77) / 100 - 91)"));
        }

        [TestMethod]
        public void TestMethod40()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(-37m, jswCalculator.EvaluateExpression("((61) - (((98))))"));
        }

        [TestMethod]
        public void TestMethod41()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(-299.68616600790513833992094861m, jswCalculator.EvaluateExpression("(89) - 5 * 63 - (14) / 46 - (86) / (95 - (40)) * 6 - ((64))"));
        }

        [TestMethod]
        public void TestMethod42()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(108.94642857142857142857142857m, jswCalculator.EvaluateExpression("93 - 17 + 15 / 4 * ((6)) / (28) * 41"));
        }
        [TestMethod]
        public void TestMethod43()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(0m, jswCalculator.EvaluateExpression("0"));
        }
        [TestMethod]
        public void TestMethod44()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(7m, jswCalculator.EvaluateExpression("7"));
        }

        [TestMethod]
        public void TestMethod45()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(-3m, jswCalculator.EvaluateExpression("-3"));
        }
        [TestMethod]
        public void TestMethod46()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(-10m, jswCalculator.EvaluateExpression("-3-7"));
        }
        [TestMethod]
        public void TestMethod47()
        {
            JswCalculator jswCalculator = new JswCalculator();
            Assert.AreEqual(-4m, jswCalculator.EvaluateExpression("-3-(1))"));
        }

        [TestMethod]
        public void TestMethod48()
        {
            JswCalculator jswCalculator = new JswCalculator();
            jswCalculator.customizingVariable = name => { return "myvar" == name ? 7524m : 0m; };
            Assert.AreEqual(7529m, jswCalculator.EvaluateExpression("5+myvar"));
        }

        [TestMethod]
        public void TestMethod49()
        {
            JswCalculator jswCalculator = new JswCalculator();
            jswCalculator.customizingVariable = name => { return "notmyvar" == name ? 7524m : 0m; };
            Assert.AreEqual(5m, jswCalculator.EvaluateExpression("5+myvar"));
        }

        Dictionary<string, string> tables = new Dictionary<string, string>() { { "t1", "3+t2-t4" }, { "t2", "8+t3" }, { "t3", "100" }, { "t4", "50" } };

        private decimal RecursiveCustomizingVariable(string name)
        {
            if (tables.ContainsKey(name))
            {
                decimal r = 0m;
                if (decimal.TryParse(tables[name], out r))
                {
                    return r;
                }
                else
                {
                    JswCalculator tmpCalculator = new JswCalculator();
                    tmpCalculator.customizingVariable = RecursiveCustomizingVariable;
                    r = tmpCalculator.EvaluateExpression(tables[name]);
                    return r;
                }
            }
            return 0m;
        }

        [TestMethod]
        public void TestMethod50()
        {

            JswCalculator jswCalculator = new JswCalculator();
            jswCalculator.customizingVariable = RecursiveCustomizingVariable;
            Assert.AreEqual(65m, jswCalculator.EvaluateExpression("4+t1"));
        }

        [TestMethod]
        public void TestMethod51()
        {

            JswCalculator jswCalculator = new JswCalculator();
            jswCalculator.customizingVariable = RecursiveCustomizingVariable;
            Assert.AreEqual(3721m, jswCalculator.EvaluateExpression("t3+t1*t1-2*t4"));
        }

    }
}
