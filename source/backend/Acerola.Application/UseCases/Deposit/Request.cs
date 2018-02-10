namespace Acerola.Application.UseCases.Deposit
{
    using System;

    public class Request
    {
        public Guid AccountId { get; private set; }
        public Double MoneyAmount { get; private set; }

        public Request(Guid accountId, double moneyAmount)
        {
            AccountId = accountId;

        }
    }
}
