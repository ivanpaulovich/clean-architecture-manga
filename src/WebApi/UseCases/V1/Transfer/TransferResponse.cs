namespace WebApi.UseCases.V1.Transfer
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    public sealed class TransferResponse
    {
        public TransferResponse(DebitModel transaction, decimal updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdateBalance = updatedBalance;
        }

        [Required] public DebitModel Transaction { get; }

        [Required] public decimal UpdateBalance { get; }
    }
}
