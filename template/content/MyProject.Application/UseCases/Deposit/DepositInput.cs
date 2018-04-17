namespace MyProject.Application.UseCases.Deposit
{
    using System;

    public class DepositInput
    {
        public Guid AccountId { get; private set; }
        public Double Amount { get; private set; }

        public DepositInput(Guid accountId, double amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
