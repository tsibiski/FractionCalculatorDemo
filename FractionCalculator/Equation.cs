using System.Text;

namespace FractionCalculator
{

	public class Equation
	{
		public List<IPieceOfEquation> PiecesOfEquation { get; set; } = new List<IPieceOfEquation>();

		public string GetEquationText()
		{
			StringBuilder equationText = new StringBuilder();
			foreach (IPieceOfEquation piece in PiecesOfEquation)
			{
				if (piece.GetType() == typeof(Operand))
				{
					(int Numerator, int Denominator) fraction = piece.GetFraction();
					equationText.Append($"{fraction.Numerator}/{fraction.Denominator}");
				}
				else if (piece.GetType() == typeof(Parenthesis))
				{
					equationText.Append(piece.GetParenthesisCharacter());
				}
				else
				{
					equationText.Append(GetOperatorCharacter(piece.GetOperationType()));
				}
				equationText.Append(" ");
			}
			return equationText.ToString().Trim();
		}

		protected string GetOperatorCharacter(Operation Operator)
		{
			switch (Operator)
			{
				case Operation.Add:
					return "+";
				case Operation.Substract:
					return "-";
				case Operation.Multiply:
					return "*";
				case Operation.Divide:
					return "/";
			}
			return string.Empty;
		}

		public string Solve()
		{
			List<IPieceOfEquation> ModifiedEquation = new List<IPieceOfEquation>(PiecesOfEquation);
			int parenthesisStartIndex = 0;
			int parenthesisEndIndex = 0;
			// Handle parenthesis separately and as the first order of operations.
			while (ModifiedEquation.FindAll(x => x.GetType() == typeof(Parenthesis)).Any())
			{
				parenthesisStartIndex = ModifiedEquation.FindIndex(x => x.GetType() == typeof(Parenthesis) && ((Parenthesis)x).IsOpenParenthesis);
				parenthesisEndIndex = ModifiedEquation.FindIndex(x => x.GetType() == typeof(Parenthesis) && !((Parenthesis)x).IsOpenParenthesis);
				List<IPieceOfEquation> SubEquation = ModifiedEquation.GetRange(parenthesisStartIndex + 1, parenthesisEndIndex - parenthesisStartIndex - 1);
				Operand resultingFraction = CalculateResult(SubEquation, false);
				ModifiedEquation.RemoveRange(parenthesisStartIndex, parenthesisEndIndex - parenthesisStartIndex + 1);
				ModifiedEquation.Insert(parenthesisStartIndex, resultingFraction);
			}
			Operand answer = CalculateResult(ModifiedEquation, true);
			if (answer.Numerator == 0)
				return $"Result: {answer.WholeNumber}";
			else if (answer.WholeNumber == 0)
				return $"Result: {answer.Numerator}/{answer.Denominator}";
			else
				return $"Result: {answer.WholeNumber} & {answer.Numerator}/{answer.Denominator}";
		}

		private Operand CalculateResult(List<IPieceOfEquation> equation, bool simplify)
		{
			int match = 0;
			int startIndex = 0;
			int endIndex = 0;
			Operand result = new Operand(0, 0);
			// Handle division and then multiplication within a section of the equation (which may be the whole equation or just a piece between two parenthesis).
			while (equation.FindAll(x => x.GetType() == typeof(Operator) && x.GetOperationType() == Operation.Divide).Any())
			{
				match = equation.FindIndex(x => x.GetType() == typeof(Operator) && x.GetOperationType() == Operation.Divide);
				startIndex = match - 1;
				endIndex = match + 1;
				result = CalculatePiece(equation.GetRange(startIndex, 3));
				equation.RemoveRange(startIndex, 3);
				equation.Insert(startIndex, result);
			}

			while (equation.FindAll(x => x.GetType() == typeof(Operator) && x.GetOperationType() == Operation.Multiply).Any())
			{
				match = equation.FindIndex(x => x.GetType() == typeof(Operator) && x.GetOperationType() == Operation.Multiply);
				startIndex = match - 1;
				endIndex = match + 1;
				result = CalculatePiece(equation.GetRange(startIndex, 3));
				equation.RemoveRange(startIndex, 3);
				equation.Insert(startIndex, result);
			}
			if (simplify)
				return SimplifyResult(CalculatePiece(equation));
			return CalculatePiece(equation);
		}

		private Operand CalculatePiece(List<IPieceOfEquation> equation)
		{
			int lastNumerator = 0;
			int lastDenominator = 0;
			int nextNumerator = 0;
			int nextDenominator = 0;
			Operation instruction = Operation.None;
			IPieceOfEquation lastItem = equation.First();
			for (int x = 0; x < equation.Count; x++)
			{
				if (x == 0)
					continue;

				// Save the instruction for the next Operand.
				IPieceOfEquation item = equation[x];
				if (item.GetOperationType() != Operation.None)
				{
					instruction = item.GetOperationType();
					continue;
				}

				// Calculate the current fraction against the current sum of previous fractions.

				lastNumerator = lastItem.GetFraction().Numerator;
				lastDenominator = lastItem.GetFraction().Denominator;
				nextNumerator = item.GetFraction().Numerator;
				nextDenominator = item.GetFraction().Denominator;

				// Determine the lowest common denominator
				int lowestCommonDenominator = 0;
				int currentDenominatorValue = 0;
				while (lowestCommonDenominator == 0)
				{
					currentDenominatorValue += 1;
					if (currentDenominatorValue % lastDenominator == 0 && currentDenominatorValue % nextDenominator == 0)
					{
						lowestCommonDenominator = currentDenominatorValue;
						break;
					}
				}

				if (instruction != Operation.Divide && instruction != Operation.Multiply)
				{
					// Update numerator values based on lowest common denominator
					lastNumerator = lastNumerator * (currentDenominatorValue / lastDenominator);
					nextNumerator = nextNumerator * (currentDenominatorValue / nextDenominator);
				}
				int resultNumerator = 0;

				if (instruction == Operation.Divide)
				{
					// Divide the fractions using multiplication of inverted next fraction              
					resultNumerator = lastNumerator * nextDenominator;
					currentDenominatorValue = lastDenominator * nextNumerator;
				}
				if (instruction == Operation.Multiply)
				{
					// Multiply the fractions
					resultNumerator = lastNumerator * nextNumerator;
					currentDenominatorValue = lastDenominator * nextDenominator;
				}
				if (instruction == Operation.Add)
				{
					// Add the fractions
					resultNumerator = lastNumerator + nextNumerator;
				}
				if (instruction == Operation.Substract)
				{
					// Subtract the fractions
					resultNumerator = lastNumerator - nextNumerator;
				}
				lastItem = new Operand(resultNumerator, currentDenominatorValue);
			}
			return (Operand)lastItem;
		}

		public Operand SimplifyResult(Operand result)
		{
			Operand newFraction = result;
			// Simplify into a whole number and a remaining fraction

			bool numeratorIsNegative = result.Numerator < 0;
			int numerator = Math.Abs(result.Numerator);
			int denominator = result.Denominator;
			int wholeNumCount = (int)Math.Floor((decimal)numerator / denominator);
			int adjustedNumerator = numerator - (denominator * wholeNumCount);

			// Simplify fractions down to lowest possible denominator
			int currentCommonDivisor = denominator + 1;
			int lowestCommonDivisor = currentCommonDivisor;

			while (currentCommonDivisor > 2)
			{
				currentCommonDivisor -= 1;
				if (denominator % currentCommonDivisor == 0 && adjustedNumerator % currentCommonDivisor == 0)
				{
					lowestCommonDivisor = currentCommonDivisor;
					denominator = denominator / lowestCommonDivisor;
					adjustedNumerator = adjustedNumerator / lowestCommonDivisor;
				}
			}

			if (numeratorIsNegative)
				adjustedNumerator = adjustedNumerator * -1;

			// Simplify to whole number and simplified fraction of whole
			if (wholeNumCount == 0 && lowestCommonDivisor != denominator)
			{
				newFraction = new Operand(adjustedNumerator, denominator);
			}
			else if (wholeNumCount > 0)
			{
				newFraction = new Operand(0, 0, wholeNumCount);
				if (adjustedNumerator != 0)
					newFraction = new Operand(adjustedNumerator, denominator, wholeNumCount);
			}
			return newFraction;
		}
	}

}