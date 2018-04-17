namespace MyProject.Application.Outputs
{
    using System;
    public class TransactionOutput
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
