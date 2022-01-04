
namespace FractionCalculator
{
    public interface IPieceOfEquation
    {
        public (int Numerator, int Denominator) GetFraction();
        public Operation GetOperationType();
        public string GetParenthesisCharacter();
    }
}