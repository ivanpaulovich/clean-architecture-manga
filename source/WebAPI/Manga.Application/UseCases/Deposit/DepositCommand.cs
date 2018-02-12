namespace Manga.Application.UseCases.Deposit
{
    using System;

    public class DepositCommand
    {
        public Guid AccountId { get; private set; }
        public Double Amount { get; private set; }

        public DepositCommand(Guid accountId, double amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
