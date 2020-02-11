namespace WebApi.UseCases.V1.Transfer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public sealed class TransferResponse
    {
        public TransferResponse(decimal amount, string description, DateTime transactionDate, decimal updatedBalance)
        {
            this.Amount = amount;
            this.Description = description;
            this.TransactionDate = transactionDate;
            this.UpdateBalance = updatedBalance;
        }

        [Required] public decimal Amount { get; }

        [Required] public string Description { get; }

        [Required] public DateTime TransactionDate { get; }

        [Required] public decimal UpdateBalance { get; }
    }
}
