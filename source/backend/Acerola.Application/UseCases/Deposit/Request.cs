namespace Acerola.Application.UseCases.Deposit
{
    using System;

    public class Request
    {
        public Guid AccountId { get; private set; }
        public Double Amount { get; private set; }

        public Request(Guid accountId, double amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
