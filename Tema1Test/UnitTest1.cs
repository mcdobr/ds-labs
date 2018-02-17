using Tema1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tema1Test
{
    [TestClass]
    public class CalculatorTest
    {
        private static Evaluator evaluator = new Evaluator();

        [TestMethod]
        public void testEvalRegular()
        {
            Assert.AreEqual(134217735, evaluator.eval("7 + 2 ^ 3 ^ 3"));
            Assert.AreEqual(6, evaluator.eval("1 + 2 +3"));
            Assert.AreEqual(2, evaluator.eval("(4 + 2 * 5) / (1 + 3 * 2)"));
            Assert.AreEqual(35.8, evaluator.eval("15 + 72 / (13 + 2) + 2^2^2"));
        }
    }
}
