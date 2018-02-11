namespace Manga.Application.UseCases.Withdraw
{
    using System;
    public class Request
    {
        public Guid AccountId { get; }
        public Double Amount { get; }

        public Request(Guid accountId, double amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
