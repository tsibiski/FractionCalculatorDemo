namespace FractionCalculator
{
    public class Operand : IPieceOfEquation
    {
        public int WholeNumber { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public Operand(int Numerator, int Denominator, int WholeNumber = 0)
        {
            this.WholeNumber = WholeNumber;
            this.Numerator = Numerator;
            this.Denominator = Denominator;
        }

        public (int Numerator, int Denominator) GetFraction()
        {
            return new(Numerator, Denominator);
        }

        public Operation GetOperationType()
        {
            return Operation.None;
        }

        public string GetParenthesisCharacter()
        {
            return string.Empty;
        }
    }
}