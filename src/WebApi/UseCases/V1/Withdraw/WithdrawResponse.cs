namespace WebApi.UseCases.V1.Withdraw
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    public sealed class WithdrawResponse
    {
        public WithdrawResponse(
            DebitModel debitModel,
            decimal updatedBalance)
        {
            this.Transaction = debitModel;
            this.UpdateBalance = updatedBalance;
        }

        [Required] public DebitModel Transaction { get; }

        [Required] public decimal UpdateBalance { get; }
    }
}
