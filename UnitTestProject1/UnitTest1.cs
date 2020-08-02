using System;
using _224.Basic_Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyCalculator myCalculator = new MyCalculator();
            var result=myCalculator.GetTokens("(1+43)");
            Assert.AreEqual(5, result.Count);
        }
        [TestMethod]
        public void TestMethod2()
        {
            MyCalculator myCalculator = new MyCalculator();
            var result = myCalculator.GetTokens("(1+(43+515 +2)- 35)+( 26 +8)");
            Assert.AreEqual(19, result.Count);
        }
        [TestMethod]
        public void TestMethod3()
        {
            MyCalculator myCalculator = new MyCalculator();
            var result = myCalculator.GetTokens("1");
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void TestMethod4()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("1+2");
            Assert.AreEqual(3, myCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod5()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("1+2+3");
            Assert.AreEqual(6, myCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod6()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("1+2*3");
            Assert.AreEqual(7, myCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod7()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("1+2*3+4");
            Assert.AreEqual(11, myCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod8()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("1+2*3-4");
            Assert.AreEqual(3, myCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod9()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("(1+2)*3-4");
            Assert.AreEqual(5, myCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod10()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("(1+2)*(9-4)");
            Assert.AreEqual(15, myCalculator.EvaluateExpression(Tokens));
        }
        [TestMethod]
        public void TestMethod11()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("(1+(43+515 +2)- 35)+( 26 +8)");
            Assert.AreEqual(560, myCalculator.EvaluateExpression(Tokens));
        }

        [TestMethod]
        public void TestMethod12()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("2-(5-6-7)");
            Assert.AreEqual(10, myCalculator.EvaluateExpression(Tokens));
        }

        [TestMethod]
        public void TestMethod13()
        {
            MyCalculator myCalculator = new MyCalculator();
            var Tokens = myCalculator.GetTokens("2-4-(8+2-6+(8+4-(1)+8-10))");
            Assert.AreEqual(-15, myCalculator.EvaluateExpression(Tokens));
        }
    }
}
