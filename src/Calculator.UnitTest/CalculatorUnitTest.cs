using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        [DataRow("1 + 1", 2)]
        [DataRow("2 * 2", 4)]
        [DataRow("6 / 2", 3)]
        [DataRow("11 + 23", 34)]
        [DataRow("11.1 + 23", 34.1)]
        public void Calculate_SingleOperatorExpression_ReturnExpectedResult(string expression, double expectedResult)
        {
            double result = Program.Calculate(expression);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("1 + 2 + 3", 6)]
        [DataRow("1 + 1 * 3", 4)]
        [DataRow("2 * 3 + 1", 7)]
        [DataRow("1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10", 55)]        
        public void Calculate_MultipleOperatorExpression_ReturnExpectedResult(string expression, double expectedResult)
        {
            double result = Program.Calculate(expression);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("( 11.5 + 15.4 ) + 10.1", 37)]
        [DataRow("23 - ( 29.3 - 12.5 )", 6.2)]
        [DataRow("( 1 / 2 ) - 1 + 1", 0.5)]
        [DataRow("( 1 + 1 ) ( 2 * 4 )", 16)]
        [DataRow("36 - ( 1 + 1 ) ( 2 * 4 ) + 18", 38)]
        public void Calculate_BracketExpression_ReturnExpectedResult(string expression, double expectedResult)
        {
            double result = Program.Calculate(expression);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("10 - ( 2 + 3 * ( 7 - 5 ) )", 2)]
        [DataRow("( 2 + 3 * ( 7 - 5 ) ) + 1", 9)]
        [DataRow("( 2 + 3 * ( 7 - 5 * ( 4 + 3 ) ) ) + 1", -81)]
        public void Calculate_NestedBracketExpression_ReturnExpectedResult(string expression, double expectedResult)
        {
            double result = Program.Calculate(expression);
            Assert.AreEqual(expectedResult, result);
        }
    }
}