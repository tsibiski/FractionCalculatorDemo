using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionCalculator;

namespace FractionCalculatorTests
{
    [TestClass]
    public class CalculatorUnitTests
    {
        [TestCleanup]
        public void TestCleanUp()
        {
            CalculatorCore.CurrentEquation.PiecesOfEquation = new System.Collections.Generic.List<IPieceOfEquation>();
        }

        [TestMethod]
        public void DivisionWithParenthesisAtStart()
        {
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Parenthesis(true));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(2, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Parenthesis(false));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Divide));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 7));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            string result = CalculatorCore.CurrentEquation.Solve().Replace("Result:", string.Empty).Trim();
            string expectedResult = "4 2/5";
            Assert.IsTrue(result == expectedResult, $"The equation \"{CalculatorCore.CurrentEquation.GetEquationText()}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void MultiplicationWithParenthesisInCenter()
        {
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(2, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Parenthesis(true));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Multiply));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(2, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Parenthesis(false));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Divide));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 7));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            string result = CalculatorCore.CurrentEquation.Solve().Replace("Result:", string.Empty).Trim();
            string expectedResult = "1 4/25";
            Assert.IsTrue(result == expectedResult, $"The equation \"{CalculatorCore.CurrentEquation.GetEquationText()}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void MultiplicationWithParenthesisAtEnd()
        {
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(2, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 7));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Divide));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Parenthesis(true));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Multiply));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(2, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Parenthesis(false));
            string result = CalculatorCore.CurrentEquation.Solve().Replace("Result:", string.Empty).Trim();
            string expectedResult = "2 13/70";
            Assert.IsTrue(result == expectedResult, $"The equation \"{CalculatorCore.CurrentEquation.GetEquationText()}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void DivisionWithAddition()
        {
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(2, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Divide));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 7));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            string result = CalculatorCore.CurrentEquation.Solve().Replace("Result:", string.Empty).Trim();
            string expectedResult = "3 1/5";
            Assert.IsTrue(result == expectedResult, $"The equation \"{CalculatorCore.CurrentEquation.GetEquationText()}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void MultiplicationWithAddition()
        {
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(2, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Multiply));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 7));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            string result = CalculatorCore.CurrentEquation.Solve().Replace("Result:", string.Empty).Trim();
            string expectedResult = "16/35";
            Assert.IsTrue(result == expectedResult, $"The equation \"{CalculatorCore.CurrentEquation.GetEquationText()}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void AdditionOnly()
        {
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(2, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 7));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            string result = CalculatorCore.CurrentEquation.Solve().Replace("Result:", string.Empty).Trim();
            string expectedResult = "33/35";
            Assert.IsTrue(result == expectedResult, $"The equation \"{CalculatorCore.CurrentEquation.GetEquationText()}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void SubtractionOnly()
        {
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 8));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Substract));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(5, 25));
            string result = CalculatorCore.CurrentEquation.Solve().Replace("Result:", string.Empty).Trim();
            string expectedResult = "-3/40";
            Assert.IsTrue(result == expectedResult, $"The equation \"{CalculatorCore.CurrentEquation.GetEquationText()}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void AdditionAndSubtraction()
        {
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(2, 5));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Substract));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 7));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operand(1, 5));
            string result = CalculatorCore.CurrentEquation.Solve().Replace("Result:", string.Empty).Trim();
            string expectedResult = "23/35";
            Assert.IsTrue(result == expectedResult, $"The equation \"{CalculatorCore.CurrentEquation.GetEquationText()}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }
    }
}

/*


    result = runCalc("1/8 + 5/24")
    if result != "1/3":
        print(colored.red("Failure FRACTION SIMPLIFICATION TEST: 1/8 + 5/24" + " returns result \"" + result + "\" when it should return " + " \"1/3\""))
        allTestsPass = False
    if allTestsPass:
        print(colored.green("All Calculator Tests Pass"))
 */