namespace WebApi.UseCases.V1.Transactions.Transfer
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     Transfer Response.
    /// </summary>
    public sealed class TransferResponse
    {
        /// <summary>
        ///     Transfer Response constructor.
        /// </summary>
        public TransferResponse(DebitModel transaction) => this.Transaction = transaction;

        /// <summary>
        ///     Gets Transaction.
        /// </summary>
        [Required]
        public DebitModel Transaction { get; }
    }
}
