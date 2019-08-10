namespace Manga.WebApi.UseCases.Deposit
{
    using System;
    public sealed class DepositRequest
    {
        public Guid AccountId { get; set; }
        public Double Amount { get; set; }
    }
}