
namespace FractionCalculator
{
    public class Operator : IPieceOfEquation
    {
        public Operator(Operation Operation)
        {
            this.Operation = Operation;
        }
        public Operation Operation { get; set; }
        public (int Numerator, int Denominator) GetFraction()
        {
            return new(0, 0);
        }

        public Operation GetOperationType()
        {
            return Operation;
        }

        public string GetParenthesisCharacter()
        {
            return string.Empty;
        }
    }
}