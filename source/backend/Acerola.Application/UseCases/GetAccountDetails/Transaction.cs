namespace Acerola.Application.UseCases.GetAccountDetails
{
    using System;
    public class Transaction
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
