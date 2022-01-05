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

        public const string WHOLE_NUMBERS_ERROR_TEXT = "Whole numbers cannot be used in the fraction calculator. Add whole number values in the form of a fraction such as \"10/5\", which would be \"2\"";
        public const string EQUATION_CAN_ONLY_START_WITH_THESE = "An equation can only start with a fraction or open parenthesis.";
        public const string OPEN_PARENTHESIS_ERROR = "An open parenthesis can only be added after an operator.";
        public const string ALL_OPEN_PARENTHESIS_MUST_BE_CLOSED = "All open parenthesis must be closed before the equation can be solved.";
        public const string CLOSED_PARENTHESIS_ERROR = "A close parenthesis can only be added after a fraction.";
        public const string OPERATOR_MUST_FOLLOW_CLOSED_PARENTHESIS_ERROR = "An operator must follow a close parenthesis";
        public const string FRACTION_MUST_BE_FOLLOWED_BY_ERROR = "A fraction must be followed by a parenthesis or operator.";
        public const string OPERATOR_MUST_BE_FOLLOWED_BY_ERROR = "An operator must be followed by a parenthesis or fraction.";
        public const string PARENTHESIS_MUST_BE_FOLLOWED_BY_ERROR = "A parenthesis must be followed by an operator or fraction.";
        public const string OPEN_PARENTHESIS_MUST_HAVE_MATCHING_CLOSE = "A close parenthesis must have a matching open parenthesis located earlier in the formation of the equation.";
        public const string MUST_CHOOSE_DENOMINATOR_ERROR = "You must choose a denominator for the current fraction being entered.";
        public const string CHOOSE_OPERATOR_ERROR = "Choose an operator to add the current fraction to the equation.";
        public const string NUMBER_MUST_BE_SELECTED_ERROR = "A numerator must be selected before the fraction divisior can be entered.";
        public const string EQUATION_CANNOT_END_WITH_AN_OPERATOR_ERROR = "An equation cannot end with an operator.";
        public const string ENTER_AN_EQUATION_ERROR = "Please enter an equation to solve.";

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
                labelError.Text = WHOLE_NUMBERS_ERROR_TEXT;
                return false;
            }

            if (!existingPieces && !isFractionPrepared)
            {
                if (inputType == InputType.Operator || inputType == InputType.CloseParenthesis)
                {
                    labelError.Text = EQUATION_CAN_ONLY_START_WITH_THESE;
                    return false;
                }
            }
            else 
            {
                // Validate that the next input type is not the same as the last, which would indicate an invalid equation.
                if (typeOfLastEquationPiece != typeof(Operator) && (inputType == InputType.OpenParenthesis))
                {
                    labelError.Text = OPEN_PARENTHESIS_ERROR;
                    return false;
                }
                if (typeOfLastEquationPiece != typeof(Operand) && inputType == InputType.CloseParenthesis && !isFractionPrepared)
                {
                    labelError.Text = CLOSED_PARENTHESIS_ERROR;
                    return false;
                }
                if (typeOfLastEquationPiece == typeof(Parenthesis) && !((Parenthesis)CalculatorCore.CurrentEquation.PiecesOfEquation.Last()).IsOpenParenthesis && inputType != InputType.Operator)
                {
                    labelError.Text = OPERATOR_MUST_FOLLOW_CLOSED_PARENTHESIS_ERROR;
                    return false;
                }
                if (typeOfLastEquationPiece == typeof(Operand) && inputType == InputType.Operand)
                {
                    labelError.Text = FRACTION_MUST_BE_FOLLOWED_BY_ERROR;
                    return false;
                }
                if (typeOfLastEquationPiece == typeof(Operator) && inputType == InputType.Operator)
                {
                    labelError.Text = labelError.Text = OPERATOR_MUST_BE_FOLLOWED_BY_ERROR;
                    return false;
                }
                if (typeOfLastEquationPiece == typeof(Parenthesis) && (inputType == InputType.OpenParenthesis || inputType == InputType.CloseParenthesis))
                {
                    labelError.Text = PARENTHESIS_MUST_BE_FOLLOWED_BY_ERROR; 
                    return false;
                }
            }

            // If a closed parenthesis is selected, make sure that the number of open parenthesis would match the number of closed parenthesis, or else the equation is invalid.
            if (inputType == InputType.CloseParenthesis)
            {
                int openParenthesis = CalculatorCore.CurrentEquation.PiecesOfEquation.FindAll(x => x.GetType() == typeof(Parenthesis) && ((Parenthesis)x).IsOpenParenthesis).Count;
                int closedParenthesis = CalculatorCore.CurrentEquation.PiecesOfEquation.FindAll(x => x.GetType() == typeof(Parenthesis) && !((Parenthesis)x).IsOpenParenthesis).Count + 1;
                if (inputType == InputType.CloseParenthesis && openParenthesis != closedParenthesis)
                {
                    labelError.Text = OPEN_PARENTHESIS_MUST_HAVE_MATCHING_CLOSE;
                    return false;
                }
            }
            else if (inputType == InputType.Divisor && labelCurrentFraction.Text.EndsWith("/"))
            {
                labelError.Text = MUST_CHOOSE_DENOMINATOR_ERROR;
                return false;
            }
            else if (inputType == InputType.Divisor && labelCurrentFraction.Text.Contains("/"))
            {
                labelError.Text = CHOOSE_OPERATOR_ERROR; 
                return false;
            }
            else if (inputType == InputType.Divisor && string.IsNullOrEmpty(CalculatorCore.CurrentNumber))
            {
                labelError.Text = NUMBER_MUST_BE_SELECTED_ERROR;
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
            if (!CalculatorCore.CurrentEquation.PiecesOfEquation.Any())
            {
                labelError.Text = ENTER_AN_EQUATION_ERROR;
                return;
            }

            // Verify that all open parenthesis have been closed.
            int openParenthesis = CalculatorCore.CurrentEquation.PiecesOfEquation.FindAll(x => x.GetType() == typeof(Parenthesis) && ((Parenthesis)x).IsOpenParenthesis).Count;
            int closedParenthesis = CalculatorCore.CurrentEquation.PiecesOfEquation.FindAll(x => x.GetType() == typeof(Parenthesis) && !((Parenthesis)x).IsOpenParenthesis).Count;
            if (openParenthesis != closedParenthesis)
            {
                labelError.Text = ALL_OPEN_PARENTHESIS_MUST_BE_CLOSED;
                return;
            }
            else if (CalculatorCore.CurrentEquation.PiecesOfEquation.Last().GetType() == typeof(Operator))
            {
                labelError.Text = EQUATION_CANNOT_END_WITH_AN_OPERATOR_ERROR;
                return;
            }
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