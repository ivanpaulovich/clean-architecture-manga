namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    public class Credit : Domain.Accounts.Credits.Credit
    {
        public Credit(
            IAccount account,
            PositiveMoney amountToDeposit,
            DateTime transactionDate)
        {
            AccountId = account.Id;
            Amount = amountToDeposit;
            TransactionDate = transactionDate;
        }

        protected Credit()
        {
        }

        public AccountId AccountId { get; protected set; }
    }
}
