
namespace FractionCalculator
{
    public class Parenthesis : IPieceOfEquation
    {
        public bool IsOpenParenthesis { get; set; }
        public Parenthesis(bool IsOpenParenthesis)
        {
            this.IsOpenParenthesis = IsOpenParenthesis;
        }
        public (int Numerator, int Denominator) GetFraction()
        {
            return new(0, 0);
        }

        public Operation GetOperationType()
        {
            return Operation.None;
        }

        public string GetParenthesisCharacter()
        {
            return IsOpenParenthesis ? "(" : ")";
        }
    }
}