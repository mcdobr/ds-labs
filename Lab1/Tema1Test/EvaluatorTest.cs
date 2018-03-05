using Tema1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tema1Test
{
    [TestClass]
    public class CalculatorTest
    {
        private const double EPS = 1e-6;
        private static Evaluator evaluator = new Evaluator();

        [TestMethod]
        public void testEvalRegular()
        {
            Assert.AreEqual(134217735, evaluator.eval("7 + 2 ^ 3 ^ 3"));
            Assert.AreEqual(6, evaluator.eval("1 + 2 +3"));
            Assert.AreEqual(2, evaluator.eval("(4 + 2 * 5) / (1 + 3 * 2)"));
            Assert.AreEqual(35.8, evaluator.eval("15 + 72 / (13 + 2) + 2^2^2"));
            Assert.AreEqual(40, evaluator.eval("((((1 + 2) + 5*4 + 32/2 + 1)))"));
            Assert.AreEqual(3, evaluator.eval("(0 - 12) % (2 + 3)"));

            Assert.AreEqual(31.003533398375, evaluator.eval("3.1415 ^ 3"), EPS);
        }

        [TestMethod]
        public void restEvalDivisionByZero()
        {
            const string divisionMsg = "Division by zero.";

            Assert.AreEqual(double.NaN, evaluator.eval("1 / 0"));
            Assert.AreEqual(divisionMsg, evaluator.getInvalidExpressionMessage());

            Assert.AreEqual(double.NaN, evaluator.eval("1 / (2 - 2)"));
            Assert.AreEqual(divisionMsg, evaluator.getInvalidExpressionMessage());
        }
    }
}
