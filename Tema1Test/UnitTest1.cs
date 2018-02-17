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
            Assert.AreEqual(6, evaluator.eval("1+2+3"));
        }
    }
}
