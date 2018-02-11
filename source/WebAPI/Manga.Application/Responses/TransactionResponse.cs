namespace Manga.Application.Responses
{
    using System;
    public class TransactionResponse
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
