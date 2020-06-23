namespace WebApi.UseCases.V1.Withdraw
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     Withdraw Response.
    /// </summary>
    public sealed class WithdrawResponse
    {
        /// <summary>
        ///     Withdraw Response constructor.
        /// </summary>
        public WithdrawResponse(
            DebitModel debitModel,
            decimal updatedBalance)
        {
            this.Transaction = debitModel;
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
