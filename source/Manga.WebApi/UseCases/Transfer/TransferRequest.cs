namespace Manga.WebApi.UseCases.Transfer
{
    using System;
    public sealed class TransferRequest
    {
        public Guid OriginAccountId { get; set; }
        public Guid DestinationAccountId { get; set; }
        public Double Amount { get; set; }
    }
}