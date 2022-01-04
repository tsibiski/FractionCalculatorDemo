
namespace FractionCalculator
{
	public enum Operation { None, Divide, Multiply, Add, Substract }

	public static class CalculatorCore
	{
		public static string CurrentNumber { get; set; } = string.Empty;
		public static Operation CurrentOperation { get; set; }
		public static (string Numerator, string Denominator) CurrentFraction { get; set; }
		public static Equation CurrentEquation { get; set; } = new Equation();

		public static void ResetForNextPieceOfEquation()
		{
			FractionCalculator.Instance.labelEquation.Text = $"Equation: {CurrentEquation.GetEquationText()}";
			FractionCalculator.Instance.labelCurrentFraction.Text = $"Current Fraction: ";
			CurrentNumber = string.Empty;
			CurrentFraction = (string.Empty, string.Empty);
			CurrentOperation = Operation.None;
		}

		public static void FullReset()
		{
			ResetForNextPieceOfEquation();
			CurrentEquation = new Equation();
		}
	}
}