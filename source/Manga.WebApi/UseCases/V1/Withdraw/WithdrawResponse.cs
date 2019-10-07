namespace Manga.WebApi.UseCases.V1.Withdraw
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public sealed class WithdrawResponse
    {
        [Required]
        public decimal Amount { get; }

        [Required]
        public string Description { get; }

        [Required]
        public DateTime TransactionDate { get; }

        [Required]
        public decimal UpdateBalance { get; }

        public WithdrawResponse(
            decimal amount,
            string description,
            DateTime transactionDate,
            decimal updatedBalance)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}
