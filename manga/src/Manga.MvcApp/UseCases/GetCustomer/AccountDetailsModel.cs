namespace Manga.MvcApp.UseCases.GetCustomer
{
    using System;

    public sealed class AccountDetailsModel
    {
        public Guid AccountId { get; }
        public double CurrentBalance { get; }

        public AccountDetailsModel(Guid accountId, double currentBalance)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
        }
    }
}
