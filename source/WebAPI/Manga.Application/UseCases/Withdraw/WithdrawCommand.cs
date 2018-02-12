namespace Manga.Application.UseCases.Withdraw
{
    using System;
    public class WithdrawCommand
    {
        public Guid AccountId { get; }
        public Double Amount { get; }

        public WithdrawCommand(Guid accountId, double amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
