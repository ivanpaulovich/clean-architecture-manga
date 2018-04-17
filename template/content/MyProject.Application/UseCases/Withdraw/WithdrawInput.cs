namespace MyProject.Application.UseCases.Withdraw
{
    using System;
    public class WithdrawInput
    {
        public Guid AccountId { get; }
        public Double Amount { get; }

        public WithdrawInput(Guid accountId, double amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
