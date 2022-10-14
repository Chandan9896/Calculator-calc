namespace BasicCalculatorServer.Model
{
    public class CalculatorDbModel
    {
        public Guid Id { get; set; }

        public double fnum { get; set; }

        public double snum { get; set; }

        public string otr { get; set; }

        public double res { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
