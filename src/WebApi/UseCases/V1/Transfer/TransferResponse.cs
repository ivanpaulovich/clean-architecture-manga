namespace WebApi.UseCases.V1.Transfer
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
        public TransferResponse(DebitModel transaction, decimal updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdateBalance = updatedBalance;
        }

        /// <summary>
        ///     Gets Transaction.
        /// </summary>
        [Required]
        public DebitModel Transaction { get; }

        /// <summary>
        ///     Gets Update Balance.
        /// </summary>
        [Required]
        public decimal UpdateBalance { get; }
    }
}
