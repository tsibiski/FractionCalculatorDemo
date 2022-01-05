using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using FractionCalculator;
using System.Diagnostics;
using System.Threading;

namespace FractionCalculatorAutomationTests
{
    [TestClass]
    public class CalculatorAutomationTests
    {
        protected static WindowsDriver<WindowsElement> Driver { get; set; }

        [ClassInitialize]
        public static void ClassSetup(TestContext tc)
        {
            CleanUpProcesses();
            Process.Start("C:\\Program Files (x86)\\Windows Application Driver\\WinAppDriver.exe");
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\source\\repos\\FractionCalculator\\FractionCalculator\\bin\\Debug\\net48\\FractionCalculator.exe");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            Driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestMethod]
        public void DivisionWithParenthesisAtStart()
        {
            Click(CalculatorPageObject.Button_OpenParenthesis);
            Click(CalculatorPageObject.Button_1);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Add);
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_CloseParenthesis);
            Click(CalculatorPageObject.Button_Divide);
            Click(CalculatorPageObject.Button_1);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_7);
            Click(CalculatorPageObject.Button_Add);
            Click(CalculatorPageObject.Button_1);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Solve);

            WindowsElement resultText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Result);
            string result = resultText.Text.Replace("Result:", string.Empty).Trim();
            WindowsElement equationText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Equation);
            string equation = equationText.Text.Replace("Result:", string.Empty).Trim();
            string expectedResult = "4 2/5";
            Assert.IsTrue(result == expectedResult, $"The equation \"{equation}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void MultiplicationWithParenthesisInCenter()
        {
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Add);
            Click(CalculatorPageObject.Button_OpenParenthesis);
            Click(CalculatorPageObject.Button_1);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Multiply);
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_CloseParenthesis);
            Click(CalculatorPageObject.Button_Divide);
            Click(CalculatorPageObject.Button_1);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_7);
            Click(CalculatorPageObject.Button_Add);
            Click(CalculatorPageObject.Button_1);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Solve);

            WindowsElement resultText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Result);
            string result = resultText.Text.Replace("Result:", string.Empty).Trim();
            WindowsElement equationText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Equation);
            string equation = equationText.Text.Replace("Result:", string.Empty).Trim();
            string expectedResult = "1 4/25";
            Assert.IsTrue(result == expectedResult, $"The equation \"{equation}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void MultiplicationWithParenthesisAtEnd()
        {
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Add);
            Click(CalculatorPageObject.Button_1);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_7);
            Click(CalculatorPageObject.Button_Divide);
            Click(CalculatorPageObject.Button_OpenParenthesis);
            Click(CalculatorPageObject.Button_1);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Multiply);
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_CloseParenthesis);
            Click(CalculatorPageObject.Button_Solve);

            WindowsElement resultText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Result);
            string result = resultText.Text.Replace("Result:", string.Empty).Trim();
            WindowsElement equationText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Equation);
            string equation = equationText.Text.Replace("Result:", string.Empty).Trim();
            string expectedResult = "2 13/70";
            Assert.IsTrue(result == expectedResult, $"The equation \"{equation}\" returns a result of \"{result}\" and should equal \"{expectedResult}\".");
        }

        [TestMethod]
        public void ErrorMessageDisplayedWhenUsingWholeNumbers()
        {
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Multiply);

            WindowsElement resultText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Error);
            Assert.IsTrue(resultText.Text == FractionCalculator.FractionCalculator.WHOLE_NUMBERS_ERROR_TEXT,
                $"Error should contain the text \"{FractionCalculator.FractionCalculator.WHOLE_NUMBERS_ERROR_TEXT}\". Actual error is \"{resultText.Text}\".");
        }

        [TestMethod]
        public void ErrorMessageDisplayedWhenStartingEquationWithOperator()
        {
            Click(CalculatorPageObject.Button_Multiply);

            WindowsElement resultText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Error);
            Assert.IsTrue(resultText.Text == FractionCalculator.FractionCalculator.EQUATION_CAN_ONLY_START_WITH_THESE,
                $"Error should contain the text \"{FractionCalculator.FractionCalculator.EQUATION_CAN_ONLY_START_WITH_THESE}\". Actual error is \"{resultText.Text}\".");
        }

        [TestMethod]
        public void ErrorMessageDisplayedWhenNotAddingOpenParenthesisAfterOperator()
        {
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_OpenParenthesis);

            WindowsElement resultText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Error);
            Assert.IsTrue(resultText.Text == FractionCalculator.FractionCalculator.OPEN_PARENTHESIS_ERROR,
                $"Error should contain the text \"{FractionCalculator.FractionCalculator.OPEN_PARENTHESIS_ERROR}\". Actual error is \"{resultText.Text}\".");
        }

        [TestMethod]
        public void ErrorMessageDisplayedWhenNotAddingCloseParenthesisAfterOperand()
        {
            Click(CalculatorPageObject.Button_OpenParenthesis);
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Multiply);
            Click(CalculatorPageObject.Button_CloseParenthesis);

            WindowsElement resultText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Error);
            Assert.IsTrue(resultText.Text == FractionCalculator.FractionCalculator.CLOSED_PARENTHESIS_ERROR,
                $"Error should contain the text \"{FractionCalculator.FractionCalculator.CLOSED_PARENTHESIS_ERROR}\". Actual error is \"{resultText.Text}\".");
        }

        [TestMethod]
        public void ErrorMessageDisplayedWhenSolvingEquationWithUnequalOpenAndCloseParenthesis()
        {
            Click(CalculatorPageObject.Button_OpenParenthesis);
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Multiply);
            Click(CalculatorPageObject.Button_Solve);

            WindowsElement resultText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Error);
            Assert.IsTrue(resultText.Text == FractionCalculator.FractionCalculator.ALL_OPEN_PARENTHESIS_MUST_BE_CLOSED,
                $"Error should contain the text \"{FractionCalculator.FractionCalculator.ALL_OPEN_PARENTHESIS_MUST_BE_CLOSED}\". Actual error is \"{resultText.Text}\".");
        }
    
        [TestMethod]
        public void ErrorMessageDisplayedWhenSelectingTwoOperatorsInSuccession()
        {
            Click(CalculatorPageObject.Button_2);
            Click(CalculatorPageObject.Button_Fraction);
            Click(CalculatorPageObject.Button_5);
            Click(CalculatorPageObject.Button_Multiply);
            Click(CalculatorPageObject.Button_Multiply);

            WindowsElement resultText = Driver.FindElementByAccessibilityId(CalculatorPageObject.Label_Error);
            Assert.IsTrue(resultText.Text == FractionCalculator.FractionCalculator.OPERATOR_MUST_BE_FOLLOWED_BY_ERROR,
                $"Error should contain the text \"{FractionCalculator.FractionCalculator.OPERATOR_MUST_BE_FOLLOWED_BY_ERROR}\". Actual error is \"{resultText.Text}\".");
        }

        private void Click(string button)
        {
            Driver.FindElementByAccessibilityId(button).Click();
            Thread.Sleep(750);
        }

        [TestCleanup]
        public void TearDownTest()
        {
            Click(CalculatorPageObject.Button_Clear);
            Click(CalculatorPageObject.Button_Clear);
        }

        [ClassCleanup]
        public static void TearDownClass()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
            CleanUpProcesses();
        }

        private static void CleanUpProcesses()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("WinAppDriver");
                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        process.Kill();
                    }
                }
                processes = Process.GetProcessesByName("FractionCalculator");
                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        process.Kill();
                    }
                }
            }
            catch { }
        }
    }
}

