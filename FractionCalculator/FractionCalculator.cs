namespace FractionCalculator
{
    public partial class FractionCalculator : Form
    {
        public FractionCalculator()
        {
            Instance = this;
            InitializeComponent();
        }

        private enum InputType { Operand, OpenParenthesis, CloseParenthesis, Operator, Divisor }

        private bool Validate(InputType inputType)
        {
            labelError.Text = string.Empty;
            bool isFractionPrepared = !string.IsNullOrEmpty(CalculatorCore.CurrentFraction.Numerator) &&
                !string.IsNullOrEmpty(CalculatorCore.CurrentNumber);
            bool existingPieces = CalculatorCore.CurrentEquation.PiecesOfEquation.Any();
            Type? typeOfLastEquationPiece = existingPieces ? CalculatorCore.CurrentEquation.PiecesOfEquation.Last().GetType() : null;

            // We queue fractions before adding them to the equation. If a fraction is complete and we are chosing an operator, then we will automatically add the fraction to the equation.
            if (isFractionPrepared && inputType == InputType.Operator)
            {
                typeOfLastEquationPiece = typeof(Operand);
            }

            if (!isFractionPrepared && !string.IsNullOrEmpty(CalculatorCore.CurrentNumber) && inputType != InputType.Operand && inputType != InputType.Divisor && !labelCurrentFraction.Text.Contains("/"))
            {
                labelError.Text = "Whole numbers cannot be used in the fraction calculator. Add whole number values in the form of a fraction such as \"10/5\", which would be \"2\"";
                return false;
            }

            if (!existingPieces && !isFractionPrepared)
            {
                if (inputType == InputType.Operator || inputType == InputType.CloseParenthesis)
                {
                    labelError.Text = "An equation can only start with a fraction or open parenthesis.";
                    return false;
                }
            }
            else 
            {
                // Validate that the next input type is not the same as the last, which would indicate an invalid equation.
                if (typeOfLastEquationPiece != typeof(Operator) && (inputType == InputType.OpenParenthesis))
                {
                    labelError.Text = "An open parenthesis can only be added after an operator.";
                    return false;
                }
                if (typeOfLastEquationPiece != typeof(Operand) && inputType == InputType.CloseParenthesis && !isFractionPrepared)
                {
                    labelError.Text = "A close parenthesis can only be added after a fraction.";
                    return false;
                }
                if (typeOfLastEquationPiece == typeof(Parenthesis) && !((Parenthesis)CalculatorCore.CurrentEquation.PiecesOfEquation.Last()).IsOpenParenthesis && inputType != InputType.Operator)
                {
                    labelError.Text = "An operator must follow a close parenthesis";
                    return false;
                }
                if (typeOfLastEquationPiece == typeof(Operand) && inputType == InputType.Operand)
                {
                    labelError.Text = "A fraction must be followed by a parenthesis or operator.";
                    return false;
                }
                if (typeOfLastEquationPiece == typeof(Operator) && inputType == InputType.Operator)
                {
                    labelError.Text = "An operator must be followed by a parenthesis or fraction.";
                    return false;
                }
                if (typeOfLastEquationPiece == typeof(Parenthesis) && (inputType == InputType.OpenParenthesis || inputType == InputType.CloseParenthesis))
                {
                    labelError.Text = "A parenthesis must be followed by an operator or fraction.";
                    return false;
                }
            }

            // If a closed parenthesis is selected, make sure that the number of open parenthesis would match the number of closed parenthesis, or else the equation is invalid.
            if (inputType == InputType.CloseParenthesis)
            {
                int openParenthesis = CalculatorCore.CurrentEquation.PiecesOfEquation.FindAll(x => x.GetType() == typeof(Parenthesis) && ((Parenthesis)x).IsOpenParenthesis).Count;
                int closedParenthesis = CalculatorCore.CurrentEquation.PiecesOfEquation.FindAll(x => x.GetType() == typeof(Parenthesis) && !((Parenthesis)x).IsOpenParenthesis).Count + 1;
                if (openParenthesis != closedParenthesis)
                {
                    labelError.Text = "A close parenthesis must have a matching open parenthesis located earlier in the formation of the equation.";
                    return false;
                }
            }
            else if (inputType == InputType.Divisor && labelCurrentFraction.Text.EndsWith("/"))
            {
                labelError.Text = "You must choose a denominator for the current fraction being entered.";
                return false;
            }
            else if (inputType == InputType.Divisor && labelCurrentFraction.Text.Contains("/"))
            {
                labelError.Text = "Choose an operator to add the current fraction to the equation.";
                return false;
            }
            else if (inputType == InputType.Divisor && string.IsNullOrEmpty(CalculatorCore.CurrentNumber))
            {
                labelError.Text = "A numerator must be selected before the fraction divisior can be entered.";
                return false;
            }
            return true;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            // We are handling the number as a string, so do not append leading zeros.
            if (CalculatorCore.CurrentNumber.Length > 0)
            {
                CalculatorCore.CurrentNumber += "0";
                labelCurrentFraction.Text += "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            CalculatorCore.CurrentNumber += "1";
            labelCurrentFraction.Text += "1";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            CalculatorCore.CurrentNumber += "2";
            labelCurrentFraction.Text += "2";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            CalculatorCore.CurrentNumber += "3";
            labelCurrentFraction.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            CalculatorCore.CurrentNumber += "4";
            labelCurrentFraction.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            CalculatorCore.CurrentNumber += "5";
            labelCurrentFraction.Text += "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            CalculatorCore.CurrentNumber += "6";
            labelCurrentFraction.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            CalculatorCore.CurrentNumber += "7";
            labelCurrentFraction.Text += "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            CalculatorCore.CurrentNumber += "8";
            labelCurrentFraction.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operand))
                return;
            CalculatorCore.CurrentNumber += "9";
            labelCurrentFraction.Text += "9";
        }
        private void buttonFraction_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Divisor))
                return;
            if (!string.IsNullOrEmpty(CalculatorCore.CurrentFraction.Denominator))
            {
                return;
            }
            else
            {
                CalculatorCore.CurrentFraction = (CalculatorCore.CurrentNumber, string.Empty);
                labelCurrentFraction.Text = $"Current Fraction: {CalculatorCore.CurrentNumber}/";
            }
            CalculatorCore.CurrentNumber = string.Empty;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            labelCurrentFraction.Text = "Current Fraction: ";
            labelEquation.Text = "Equation: ";
            labelResult.Text = "Result: ";
            CalculatorCore.FullReset();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operator))
                return;
            UpdateCurrentFraction();
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Add));
            CalculatorCore.ResetForNextPieceOfEquation();
        }
        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operator))
                return;
            UpdateCurrentFraction();
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Substract));
            CalculatorCore.ResetForNextPieceOfEquation();
        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operator))
                return;
            UpdateCurrentFraction();
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Multiply));
            CalculatorCore.ResetForNextPieceOfEquation();
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.Operator))
                return;
            UpdateCurrentFraction();
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Operator(Operation.Divide));
            CalculatorCore.ResetForNextPieceOfEquation();
        }
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            UpdateCurrentFraction();
            CalculatorCore.ResetForNextPieceOfEquation();
            labelResult.Text = CalculatorCore.CurrentEquation.Solve();
        }

        private void UpdateCurrentFraction()
        {
            CalculatorCore.CurrentFraction = (CalculatorCore.CurrentFraction.Numerator, CalculatorCore.CurrentNumber);
            CalculatorCore.CurrentNumber = string.Empty;
            if (string.IsNullOrEmpty(CalculatorCore.CurrentFraction.Denominator))
                return;
            Operand piece = new Operand(int.Parse(CalculatorCore.CurrentFraction.Numerator), int.Parse(CalculatorCore.CurrentFraction.Denominator));
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(piece);
        }

        private void buttonOpenParenthesis_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.OpenParenthesis))
                return; 
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Parenthesis(true));
            labelEquation.Text += " (";
        }
        private void buttonCloseParenthesis_Click(object sender, EventArgs e)
        {
            if (!Validate(InputType.CloseParenthesis))
                return;
            UpdateCurrentFraction();
            CalculatorCore.CurrentEquation.PiecesOfEquation.Add(new Parenthesis(false));
            CalculatorCore.ResetForNextPieceOfEquation();
        }

        private void buttonUndoLast_Click(object sender, EventArgs e)
        {
            if(CalculatorCore.CurrentEquation.PiecesOfEquation.Any())
                CalculatorCore.CurrentEquation.PiecesOfEquation.RemoveAt(CalculatorCore.CurrentEquation.PiecesOfEquation.Count -1);
            CalculatorCore.ResetForNextPieceOfEquation();
        }

        private void FractionCalculator_Load(object sender, EventArgs e)
        {

        }
    }
}