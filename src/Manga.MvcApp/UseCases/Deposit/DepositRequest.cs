namespace Manga.MvcApp.UseCases.Deposit
{
    using System;

    public sealed class DepositRequest
    {
        public Guid AccountId { get; set; }
        public float Amount { get; set; }
    }
}
