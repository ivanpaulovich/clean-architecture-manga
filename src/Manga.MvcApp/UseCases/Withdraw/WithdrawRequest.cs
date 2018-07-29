namespace Manga.MvcApp.UseCases.Withdraw
{
    using System;

    public sealed class WithdrawRequest
    {
        public Guid AccountId { get; set; }
        public float Amount { get; set; }
    }
}
